using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Tcraft.Ace.Api.Core;

namespace Tcraft.Ace.Api.Controllers
{
    [ApiController]
    [Route("api/number")]
    public class NumberController : ControllerBase
    {
        [HttpGet]
        [SwaggerOperation(Summary = "GetFibonacciNumber", Description = "Generates the nth Fibonacci number.")]
        [SwaggerResponse(200, "OK", typeof(long))]
        [SwaggerResponse(400, "Bad Request", typeof(string))]
        public IActionResult GetNumber([FromQuery] int n)
        {
            if (n is < 0 or > 50)
            {
                return BadRequest(Properties.Resources.FibonacciNumberNotInRange);
            }

            var number = Utils.Fibonacci(n);
            return Ok(new { number });
        }
    }
}
