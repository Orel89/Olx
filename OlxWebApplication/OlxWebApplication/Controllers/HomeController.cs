using Microsoft.AspNetCore.Mvc;
using OlxWebApplication.Models;
using OlxWebApplication.Models.User;
using System.Diagnostics;

namespace OlxWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Registration()
        {
            return View();
        }

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

        public IActionResult Index()
        {
            var user = ControllerContext.HttpContext.Session.GetString("Name");

            ViewBag.Account = user;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}