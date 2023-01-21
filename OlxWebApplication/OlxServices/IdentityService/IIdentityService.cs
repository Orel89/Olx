using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;

namespace OlxServices.IdentityService
{
    public interface IIdentityService
    {
        string GetIdentityErrorMessage(IdentityResult identityResult);
    }
}