using Microsoft.AspNetCore.Mvc;

namespace OpenSchool.Web.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class HomeController : ControllerBase
    {

        [HttpGet]
        public ActionResult<string> Get() => 
            Ok("Hello From Home Controller !");
    }
}
