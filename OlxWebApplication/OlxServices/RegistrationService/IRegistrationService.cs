using Microsoft.EntityFrameworkCore.Storage;
using OlxWebApplication.Models.User;

namespace OlxWebApplication.Services.RegistrationService
{
    public interface IRegistrationService
    {
        Task<ExecutionResult<bool>> RegisterUser(SignUpUserModel request);
    }
}
