using LS.Helpers.Hosting.API;
using OlxCore.Entities.DTOModels;

namespace OlxWebApi.Services.AuthService
{
    public interface IAuthService
    {
        Task<ExecutionResult<string>> RegisterUser(UserDTO request);
        //Task<ExecutionResult<LoginQueryResult>> LoginAsync(LoginQuery request);
    }
}
