using Microsoft.AspNetCore.Identity;

namespace AuthWebApi.Services.IdentityService
{
    public interface IIdentityService
    {
        string GetIdentityErrorMessage(IdentityResult identityResult);
    }
}