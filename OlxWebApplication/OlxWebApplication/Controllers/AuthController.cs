using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using OlxCore.Entities.DTOModels;
using OlxWebApplication.Models.User;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Net;
using System.Text;
using LS.Helpers.Hosting.API;
using OlxWebAPI.Queries;

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
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Registration()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Registration(SignUpUserModel user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        ExecutionResult<SignUpQueryResult> apiResponse = new();

        //        ControllerContext.HttpContext.Session.SetString("Name", user.UserName);

        //        var userDTO = _mapper.Map<SignUpUserModel, UserDTO>(user);

        //        var queryUrl = "https://localhost:44369/auth/registration";

        //        using (var client = new HttpClient())
        //        {

        //            var request = new HttpRequestMessage(HttpMethod.Post, queryUrl);

        //            var json = JsonConvert.SerializeObject(user);

        //            if (user is IEnumerable<KeyValuePair<string, string>> body)
        //            {
        //                request.Content = new FormUrlEncodedContent(body);
        //            }
        //            else
        //            {
        //                request.Content = new StringContent(json, Encoding.UTF8, "application/json");
        //            }

        //            var response = await client.SendAsync(request);

        //            if (response.IsSuccessStatusCode)
        //            {
        //                var result = response.Content.ReadAsStringAsync().Result;

        //                apiResponse = JsonConvert.DeserializeObject<ExecutionResult<SignUpQueryResult>>(result);
        //                return View();
        //            }
        //            else
        //            {
        //                throw new Exception("Failed to get Data from API");
        //            }
        //        }
        //    }
        //    return RedirectPermanent("../Home/Index");
        //}

        [HttpPost]
        public IActionResult Registration(SignUpUserModel user)
        {
            if (ModelState.IsValid)
            {
                //byte[] arr = new byte[] { 0, 1, 1, 2, 0 };
                //user.Avatar = arr;
                //userService.Add(user);
                //ControllerContext.HttpContext.Session.SetString("Name", user.Login);
                return RedirectPermanent("../Home/Index");
            }
            return View();
        }
    }
}
