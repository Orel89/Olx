using AuthWebApi.Services.IdentityService;
using LS.Helpers.Hosting.API;
using Microsoft.AspNetCore.Identity;
using OlxCore.Entities.DTOModels;
using OlxCore.Enums;
using OlxInfrastructure.Identity;
using OlxWebApi.Services.AuthService;
using OlxWebAPI.Queries;
using System.Security.Claims;


namespace OlxWebAPI.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _singInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IIdentityService _identityService;

        public AuthService(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> singInManager,
            RoleManager<IdentityRole> roleManager,
            IIdentityService identityService)
        {
            _userManager = userManager;
            _singInManager = singInManager;
            _roleManager = roleManager;
            _identityService = identityService;
        }

        #region -- IAuthService implementation --

        public async Task<ExecutionResult<SignUpQueryResult>> RegisterUser(UserDTO request)
        {
            string identityErrorMessage = string.Empty;

            request.UserRole = string.IsNullOrEmpty(request.UserRole) ? Roles.Customer.ToString() : request.UserRole;

            ExecutionResult<SignUpQueryResult> result;

            var isRoleValid = Enum.TryParse(request.UserRole, false, out Roles role);

            if (isRoleValid)
            {
                var user = await _userManager.FindByNameAsync(request.UserName);

                if (user is null)
                {
                    var newUser = new ApplicationUser
                    {
                        UserName = request.UserName,
                        Email = request.Email
                    };

                    var createIdentityResult = await _userManager.CreateAsync(newUser, request.Password);

                    if (createIdentityResult.Succeeded)
                    {
                        var addToRoleIdentityResult = await _userManager.AddToRoleAsync(newUser, request.UserRole);

                        if (addToRoleIdentityResult.Succeeded)
                        {
                            var claims = new List<Claim>()
                            {
                                new Claim(ClaimTypes.Role, request.UserRole),
                            };

                            var addClaimsIdentityResult = await _userManager.AddClaimsAsync(newUser, claims);

                            if (addClaimsIdentityResult.Succeeded)
                            {
                                result = new ExecutionResult<SignUpQueryResult>(new InfoMessage($"Employee with id {request.UserName} successfully added in database"));
                            }
                            else
                            {
                                identityErrorMessage = _identityService.GetIdentityErrorMessage(addClaimsIdentityResult);

                                result = new ExecutionResult<SignUpQueryResult>(new ErrorInfo() { ErrorMessage = identityErrorMessage });
                            }
                        }
                        else
                        {
                            identityErrorMessage = _identityService.GetIdentityErrorMessage(addToRoleIdentityResult);

                            result = new ExecutionResult<SignUpQueryResult>(new ErrorInfo() { ErrorMessage = identityErrorMessage });
                        }
                    }
                    else
                    {
                        identityErrorMessage = _identityService.GetIdentityErrorMessage(createIdentityResult);

                        result = new ExecutionResult<SignUpQueryResult>(new ErrorInfo() { ErrorMessage = identityErrorMessage });
                    }
                }
                else
                {
                    result = new ExecutionResult<SignUpQueryResult>(new ErrorInfo() { ErrorMessage = "User already exist" });
                }
            }
            else
            {
                result = new ExecutionResult<SignUpQueryResult>(new ErrorInfo() { ErrorMessage = "User role not exist" });
            }

            return result;
        }

        #endregion
    }
}
