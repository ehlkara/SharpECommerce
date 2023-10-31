using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharpEcommerce.API.Errors;
using SharpEcommerce.Core.Entities;
using SharpEcommerce.Core.Entities.OrderAggregate;
using SharpEcommerce.Core.Interfaces;
using Stripe;

namespace SharpEcommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : BaseApiController
    {
        private readonly string _whSecret;
        private readonly IPaymentService _paymentService;
        private readonly ILogger<PaymentsController> _logger;

        public PaymentsController(IPaymentService paymentService, ILogger<PaymentsController> logger, IConfiguration config)
        {
            _paymentService = paymentService;
            _logger = logger;
            _whSecret = config.GetSection("StripeSettings:WhSecret").Value;
        }

        [Authorize]
        [HttpPost("{basketId}")]
        public async Task<ActionResult<CustomerBasket>> CreateOrUpdatePaymentIntent(string basketId)
        {
            var basket = await _paymentService.CreateOrUpdatePaymentIntent(basketId);

            if (basket == null) return BadRequest(new ApiResponse(400, "Problem with your basket"));

            return basket;
        }

        [HttpPost("webhook")]
        public async Task<ActionResult> StripeWebHook()
        {
            var json = await new StreamReader(Request.Body).ReadToEndAsync();

            var stripeEvent = EventUtility.ConstructEvent(
    json,
    Request.Headers["Stripe-Signature"],
    _whSecret,
    300,
    (long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds,
    false);

            PaymentIntent intent;
            Order order;

            switch (stripeEvent.Type)
            {
                case "payment_intent.succeeded":
                    intent = (PaymentIntent)stripeEvent.Data.Object;
                    _logger.LogInformation("Payment succeeded: ", intent.Id);
                    // TODO: update the order with the new status
                    order = await _paymentService.UpdateOrderPaymentSucceeded(intent.Id);
                    _logger.LogInformation("Order updated to payment received: ", order.Id);
                    break;
                case "payment_intent.payment_failed":
                    intent = (PaymentIntent)stripeEvent.Data.Object;
                    _logger.LogInformation("Payment failed: ", intent.Id);
                    // TODO: update the order with the new status
                    order = await _paymentService.UpdateOrderPaymentFailed(intent.Id);
                    _logger.LogInformation("Order updated to payment failed: ", order.Id);
                    break;
            }

            return new EmptyResult();
        }
    }
}
