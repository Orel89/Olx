using AutoMapper;
using LS.Helpers.Hosting.API;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OlxCore.Entities;
using OlxCore.Entities.DTOModels;
using OlxCore.Interfaces.Services;
using OlxWebApplication.Models;
using OlxWebApplication.Models.User;
using OlxWebApplication.Models.ViewModels;
using System.Diagnostics;
using System.Text;

namespace OlxWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRestService _restService;
        private readonly IMapper _mapper;

        public HomeController(
            ILogger<HomeController> logger,
            IRestService restService,
            IMapper mapper)
        {
            _logger = logger;
            _restService = restService;
            _mapper = mapper;
        }


        public async Task<IActionResult> Index(ResearchViewModel rvm)
        {
            var user = ControllerContext.HttpContext.Session.GetString("Name");

            ViewBag.Account = user;

            try
            {
                var query = $"{Constants.API.HOST_URL}/category/get_all_categories";

                var response = await _restService.RequestAsync<ExecutionResult<List<Category>>>(HttpMethod.Get, query);

                if (response.Success)
                {

                    ViewBag.Categories = _mapper.Map<List<Category>, List<CategoryViewModel>>(response.Value);
                }
                else
                {

                    ViewBag.Categories = new CategoryViewModel { Id = Guid.Empty, Name = response.Messages?.FirstOrDefault()?.ToString() ?? "CATEGORIES_NOT_FOUND" };
                }
            }
            catch (Exception ex)
            {

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