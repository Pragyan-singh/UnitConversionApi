using Microsoft.AspNetCore.Mvc;
using UnitConversionSystem.Core.Models;
using UnitConversionSystem.Core.Services;

namespace UnitConversionSystem.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")] // Production API versioning convention
    public class ConversionController : ControllerBase
    {
        private readonly ConversionEngine _conversionEngine;

        // Injected automatically via DI container configured in Program.cs
        public ConversionController(ConversionEngine conversionEngine)
        {
            _conversionEngine = conversionEngine;
        }

        [HttpPost("convert")]
        public ActionResult<ConversionResult> Convert([FromBody] ConversionRequest request)
        {
            if (request == null)
            {
                return BadRequest("Invalid or missing request payload.");
            }

            // Calls core business rules to map and execute calculations
            var result = _conversionEngine.ProcessConversion(request);
            
            return Ok(result);
        }
    }
}
