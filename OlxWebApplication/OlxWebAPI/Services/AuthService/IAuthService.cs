
using LS.Helpers.Hosting.API;
using Microsoft.AspNetCore.Mvc;
using OlxCore.Entities.DTOModels;
using OlxInfrastructure.Identity;
using OlxWebAPI.Queries;

namespace OlxWebApi.Services.AuthService
{
    public interface IAuthService
    {
        Task<ExecutionResult<SignUpQueryResult>> RegisterUser(UserDTO request);
        //Task<ExecutionResult<LoginQueryResult>> LoginAsync(LoginQuery request);
    }
}
