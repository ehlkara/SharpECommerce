using Microsoft.AspNetCore.Mvc;
using SharpEcommerce.API.Errors;
using SharpEcommerce.Infrastructure.Data;

namespace SharpEcommerce.API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly EcommerceDbContext _context;

        public BuggyController(EcommerceDbContext context)
        {
            _context = context;
        }

        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest()
        {
            var thing = _context.Products.Find(42);

            if(thing == null)
            {
                return NotFound(new ApiResponse(404));
            }

            return Ok();
        }
        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            var thing = _context.Products.Find(42);

            return Ok();
        }
        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }
        [HttpGet("badrequest/{id}")]
        public ActionResult GetNotFoundRequest(int id)
        {
            return Ok();
        }
    }
}
