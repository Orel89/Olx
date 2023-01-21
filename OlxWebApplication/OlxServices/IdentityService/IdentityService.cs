using Microsoft.AspNetCore.Identity;

namespace OlxWebApplication.Services.IdentityService
{
    public class IdentityService : IIdentityService
    {

        #region -- IIdentityService implementation --

        public string GetIdentityErrorMessage(IdentityResult identityResult)
        {
            var errorMessages = string.Empty;

            if (identityResult != null && identityResult.Errors.Any())
            {
                List<IdentityError> errorList = identityResult.Errors.ToList();

                errorMessages = string.Join(", ", errorList.Select(e => e.Description));
            }

            return errorMessages;
        }

        #endregion
    }
}
