using AutoMapper;
using LS.Helpers.Hosting.API;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Common;
using OlxCore.Entities.DTOModels;
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
        public AuthController(
            ILogger<HomeController> logger,
            IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
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
                //ExecutionResult<SignUpQueryResult> apiResponse = new();

                //ControllerContext.HttpContext.Session.SetString("Name", user.UserName);

                //var userDTO = _mapper.Map<SignUpUserModel, UserDTO>(user);

                //var queryUrl = "https://localhost:48758/authentication/createuser";

                //using (var client = new HttpClient())
                //{

                //    var request = new HttpRequestMessage(HttpMethod.Post, queryUrl);

                //    var json = JsonConvert.SerializeObject(user);

                //    if (user is IEnumerable<KeyValuePair<string, string>> body)
                //    {
                //        request.Content = new FormUrlEncodedContent(body);
                //    }
                //    else
                //    {
                //        request.Content = new StringContent(json, Encoding.UTF8, "application/json");
                //    }

                //    var response = await client.SendAsync(request);

                //    if (response.IsSuccessStatusCode)
                //    {
                //        var result = response.Content.ReadAsStringAsync().Result;

                //        apiResponse = JsonConvert.DeserializeObject<ExecutionResult<SignUpQueryResult>>(result);
                //        return View();
                //    }
                //    else
                //    {
                //        throw new Exception("Failed to get Data from API");
                //    }
                //}
                var data = new List<WeatherModel>();
                using (var client = new HttpClient())
                {
                    var result = await client.GetAsync("https://localhost:44369/weatherforecast");
                    if (result.IsSuccessStatusCode)
                    {
                        var model = await result.Content.ReadAsStringAsync();
                        data = JsonConvert.DeserializeObject<List<WeatherModel>>(model);
                        return View(data);
                    }
                    else
                    {
                        throw new Exception("Failed to get Data from API");
                    }
                }
            }
            return RedirectPermanent("../Home/Index");
        }


    }
}
