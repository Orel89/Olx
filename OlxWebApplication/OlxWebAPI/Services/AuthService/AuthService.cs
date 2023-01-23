using AuthWebApi.Services.IdentityService;
using LS.Helpers.Hosting.API;
using Microsoft.AspNetCore.Identity;
using OlxCore;
using OlxCore.Entities.DTOModels;
using OlxCore.Enums;
using OlxInfrastructure.Data;
using OlxInfrastructure.Identity;
using OlxWebApi.Services.AuthService;
using System.Security.Claims;

namespace OlxWebAPI.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _singInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _dbContext;
        private readonly IIdentityService _identityService;
        private readonly ILogger<AuthService> _logger;

        public AuthService(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> singInManager,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext dbContext,
            IIdentityService identityService,
            ILogger<AuthService> logger)
        {
            _userManager = userManager;
            _singInManager = singInManager;
            _roleManager = roleManager;
            _identityService = identityService;
            _dbContext = dbContext;
            _logger = logger;
        }

        #region -- IAuthService implementation --

        public async Task<ExecutionResult<string>> RegisterUser(UserDTO request)
        {
            ExecutionResult<string> result;

            string identityErrorMessage = string.Empty;

            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    request.UserRole = string.IsNullOrEmpty(request.UserRole) ? Roles.Customer.ToString() : request.UserRole;

                    var isRoleValid = Enum.TryParse(request.UserRole, false, out Roles role);

                    if (isRoleValid)
                    {
                        var user = await _userManager.FindByEmailAsync(request.Email);

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
                                        await _dbContext.SaveChangesAsync();
                                        transaction.Commit();
                                        result = new ExecutionResult<string>(newUser.Id);
                                    }
                                    else
                                    {
                                        identityErrorMessage = _identityService.GetIdentityErrorMessage(addClaimsIdentityResult);
                                        throw new Exception(identityErrorMessage);
                                    }
                                }
                                else
                                {
                                    identityErrorMessage = _identityService.GetIdentityErrorMessage(addToRoleIdentityResult);
                                    throw new Exception(identityErrorMessage);
                                }
                            }
                            else
                            {
                                identityErrorMessage = _identityService.GetIdentityErrorMessage(createIdentityResult);
                                throw new Exception(identityErrorMessage);
                            }
                        }
                        else
                        {
                            throw new ArgumentException(Constants.USER_EMAIL_ALREADY_EXIST);
                        }
                    }
                    else
                    {
                        throw new ArgumentException(Constants.ROLE_NOT_FOUND);
                    }

                }
                catch (ArgumentException ex)
                {
                    transaction.Rollback();
                    result = new ExecutionResult<string>(new InfoMessage(ex.Message));
                    result.Success = false;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    var message = $"Error while executing {nameof(RegisterUser)}";
                    result = new ExecutionResult<string>(new ErrorInfo(message));
                }
            }

            return result;
        }

        #endregion
    }
}
