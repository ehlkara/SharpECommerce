using Microsoft.AspNetCore.Mvc;
using SharpEcommerce.API.Errors;

namespace SharpEcommerce.API.Controllers
{
    [Route("errors/{code}")]
    public class ErrorController : BaseApiController
    {
        [HttpGet]
        public IActionResult Error(int code)
        {
            return new ObjectResult(new ApiResponse(code));
        }
    }
}
