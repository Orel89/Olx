using Microsoft.AspNetCore.Mvc;
using OlxInfrastructure.Identity;

namespace OlxWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        public AuthController()
        {

        }

        [HttpPost("registration")]
        public IActionResult Registration([FromBody] ApplicationUser applicationUser)
        {
            var request = applicationUser;
            return View();
        }
    }
}
