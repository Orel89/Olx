using LS.Helpers.Hosting.API;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OlxCore.Entities;
using OlxWebApplication.Models;
using OlxWebApplication.Models.User;
using System.Diagnostics;
using System.Text;

namespace OlxWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public async Task<IActionResult> Index()
        {
            ExecutionResult<List<Category>> categoryResponse = new();

            List<Category> categories = new List<Category>();

            var user = ControllerContext.HttpContext.Session.GetString("Name");

            ViewBag.Account = user;

            var queryUrl = "http://localhost:5220/category/get_all_categories";

            using (var client = new HttpClient())
            {

                var request = new HttpRequestMessage(HttpMethod.Get, queryUrl);

                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;

                    categories = JsonConvert.DeserializeObject<List<Category>>(result);
                    ViewBag.Categories = categories;
                }
                else
                {
                    throw new Exception("Failed to get Data from API");
                }
            }

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