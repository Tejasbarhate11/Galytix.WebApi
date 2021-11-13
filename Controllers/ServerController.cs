using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Galytix.WebApi.Controllers
{
    [ApiController]
    [Route("/api")]
    public class ServerController : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Get()
        { 
            return Ok("hello tejas!");
        }
    }
}
