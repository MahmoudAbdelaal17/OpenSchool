using Microsoft.AspNetCore.Mvc;
using OpenSchool.Web.Api.Brokers.Loggings;

namespace OpenSchool.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ILoggerManager logger;

        public ValuesController(ILoggerManager logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult index()
        {
            logger.LogInfo("Welcome From Logger");
            return Ok();
        }
    }
}
