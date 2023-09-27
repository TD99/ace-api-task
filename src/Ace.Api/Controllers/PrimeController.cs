using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Tcraft.Ace.Api.Core;
using Tcraft.Ace.Api.Properties;

namespace Tcraft.Ace.Api.Controllers
{
    [ApiController]
    [Route("api/prime")]
    public class PrimeController : ControllerBase
    {
        [HttpGet]
        [SwaggerOperation(Summary = "GetPrimeNumbers", Description = "Generates a list of prime numbers up to a specified limit.")]
        [SwaggerResponse(200, "OK", typeof(List<int>))]
        [SwaggerResponse(400, "Bad Request", typeof(string))]
        public IActionResult GetPrimes([FromQuery] int limit)
        {
            var request = HttpContext.Request;
            var baseUrl = $"{request.Scheme}://{request.Host}{request.Path}";

            switch (limit)
            {
                case 0:
                    var message = string.Format(Resources.InvalidPrimeNumberLimitRequest, baseUrl);
                    return BadRequest(message);
                case < 1 or > 10000:
                    return BadRequest(Resources.PrimeNumberLimitNotInRange);
                default:
                    var primes = Utils.GeneratePrimesUpToLimit(limit);
                    return Ok(new { primes });
            }
        }
    }
}
