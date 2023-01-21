using Microsoft.AspNetCore.Mvc;
using OlxCore.Entities.DTOModels;

namespace OlxWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        [HttpPost("registration")]
        //[Authorize]
        public async Task<ActionResult> RegisterUser([FromBody] UserDTO signUpQuery)
        {
            var result = signUpQuery;

            return Ok(result);
        }
    }
}
