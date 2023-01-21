using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage;
using OlxInfrastructure.Identity;
using OlxServices.IdentityService;
using OlxWebApplication.Models.User;
using System.Data;
using System.Security.Claims;

namespace OlxWebApplication.Services.RegistrationService
{
    public class RegistrationService : IRegistrationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _singInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IRegistrationService _registrationService;
        private readonly IIdentityService _identityService;
        public RegistrationService(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> singInManager,
            RoleManager<IdentityRole> roleManager,
            IRegistrationService registrationService,
            IIdentityService identityService)
        {
            _userManager = userManager;
            _singInManager = singInManager;
            _roleManager = roleManager;
            _registrationService = registrationService;
            _identityService = identityService;
        }

        #region -- IRegistrationService implementation --

        public async Task<ExecutionResult<bool>> RegisterUser(SignUpUserModel request)
        {
            string identityErrorMessage = string.Empty;
            ExecutionResult<bool> result;


                var employee = await _userManager.FindByNameAsync(request.UserName);

                if (employee is null)
                {
                    var newEmployee = new ApplicationUser
                    {
                        UserName = request.UserName,
                        Us
                        Email = request.Email
                    };

                    var createIdentityResult = await _userManager.CreateAsync(newEmployee, request.Password);

                    if (createIdentityResult.Succeeded)
                    {
                        var addToRoleIdentityResult = await _userManager.AddToRoleAsync(newEmployee, request.EmployeeRole);

                        if (addToRoleIdentityResult.Succeeded)
                        {
                            var claims = new List<Claim>()
                            {
                                new Claim(ClaimTypes.NameIdentifier, request.EmployeeId),
                                new Claim(ClaimTypes.Role, request.EmployeeRole),
                            };

                            var addClaimsIdentityResult = await _userManager.AddClaimsAsync(newEmployee, claims);

                            if (addClaimsIdentityResult.Succeeded)
                            {
                                result = new ExecutionResult<SignUpQueryResult>(new InfoMessage($"Employee with id {request.EmployeeId} successfully added in database"));
                                // result.Success = true; is a must have ?
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
                    result = new ExecutionResult<SignUpQueryResult>(new ErrorInfo() { ErrorMessage = "Employee already exist" });
                }

            return result;
        }
    }

        #endregion
    }
}
