using Microsoft.AspNetCore.Mvc;
using OlxCore.Entities.DTOModels;
using LS.Helpers.Hosting.API;
using LS.Helpers.Hosting.Extensions;
using OlxWebApi.Services.AuthService;

namespace OlxWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : Controller
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AuthenticationController> _logger;
        public AuthenticationController(
            IAuthService authService,
            ILogger<AuthenticationController> logger) 
        {
            _authService= authService;
            _logger= logger;    
        }

        [HttpPost("registration")]
        //[Authorize]
        public async Task<IActionResult> RegisterUser([FromBody] UserDTO signUpQuery)
        {
            var resultOfCreatingUser = await _authService.RegisterUser(signUpQuery);

            if (!resultOfCreatingUser.Success && resultOfCreatingUser.Messages.Any())
            {
                return Ok(resultOfCreatingUser); 
            }

            return this.FromExecutionResult(resultOfCreatingUser);
        }
    }
}
