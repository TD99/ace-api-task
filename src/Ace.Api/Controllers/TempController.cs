using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Tcraft.Ace.Api.Models;
using Tcraft.Ace.Api.Properties;

namespace Tcraft.Ace.Api.Controllers
{
    [ApiController]
    [Route("api/temp")]
    public class TempController : ControllerBase
    {
        [HttpGet]
        [SwaggerOperation(Summary = "GetTemp", Description = "Converts a temperature from Celsius to Kelvin or from Kelvin to Celsius.")]
        [SwaggerResponse(200, "OK", typeof(Temperature))]
        [SwaggerResponse(400, "Bad Request", typeof(string))]
        public IActionResult GetTemp([FromQuery] double? celsius, [FromQuery] double? kelvin)
        {
            var request = HttpContext.Request;
            var baseUrl = $"{request.Scheme}://{request.Host}{request.Path}";

            if (celsius.HasValue)
                return Ok(Temperature.FromCelsius(celsius.Value));

            if (kelvin.HasValue)
                return Ok(Temperature.FromKelvin(kelvin.Value));

            var message = string.Format(Resources.InvalidTemperatureConversionRequest, baseUrl);

            return BadRequest(message);
        }
    }

}
