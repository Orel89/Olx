using Microsoft.AspNetCore.Mvc;
using OlxCore.Entities.DTOModels;

namespace OlxWebAPI.Controllers
{
    public class AuthenticationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("createuser")]
        public IActionResult CreateUser([FromBody] UserDTO request)
        {
            var user = request;
            return View();
        }
    }
}
