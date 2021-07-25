using Microsoft.AspNetCore.Mvc;
using OpenSchool.Web.Api.Brokers.Loggings;

namespace OpenSchool.Web.Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ILoggerManager logger;

        public ValuesController(ILoggerManager logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult Get() => Ok("Hello !");
    }
}
