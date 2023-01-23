using AutoMapper;
using LS.Helpers.Hosting.API;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Common;
using OlxCore.Entities.DTOModels;
using OlxCore.Interfaces.Services;
using OlxWebAPI.Queries;
using OlxWebApplication.Models;
using OlxWebApplication.Models.User;
using System.Text;

namespace OlxWebApplication.Controllers
{
    public class AuthController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper _mapper;
        private readonly IRestService _restService;

        public AuthController(
            ILogger<HomeController> logger,
            IMapper mapper,
            IRestService restService)
        {
            _logger = logger;
            _mapper = mapper;
            _restService = restService;
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(SignUpUserModel user)
        {
            if (ModelState.IsValid)
            {
                ExecutionResult<string> apiResponse;

                var userDTO = _mapper.Map<SignUpUserModel, UserDTO>(user);

                try
                {
                    var query = $"{Constants.API.HOST_URL}/authentication/registration";

                    var response = await _restService.RequestAsync<ExecutionResult<string>>(HttpMethod.Post, query, userDTO);

                    if (response.Success)
                    {
                        apiResponse = new ExecutionResult<string>(response.Value);

                        ControllerContext.HttpContext.Session.SetString("Name", user.UserName);
                        ControllerContext.HttpContext.Session.SetString("NameId", apiResponse.Value);
                    }
                    else
                    {
                        throw new Exception("Failed to get Data from API");
                    }
                }
                catch (Exception ex)
                {
                    
                }


            }
            return RedirectPermanent("../Home/Index");
        }
    }
}
