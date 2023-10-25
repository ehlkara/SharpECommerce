using SharpEcommerce.Core.Entities;
using SharpEcommerce.Core.Entities.OrderAggregate;

namespace SharpEcommerce.Core.Interfaces
{
    public interface IPaymentService
    {
        Task<CustomerBasket> CreateOrUpdatePaymentIntent(string basketId);
        Task<Order> UpdateOrderPaymentSucceeded(string paymentId);
        Task<Order> UpdateOrderPaymentFailed(string paymentId);
    }
}
