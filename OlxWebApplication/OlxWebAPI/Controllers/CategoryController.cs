using Microsoft.AspNetCore.Mvc;
using OlxCore.Interfaces.Configuration;

namespace OlxWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : Controller
    {
        private IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("get_all_categories")]
        public async Task<IActionResult> GetCategories()
        {
            var categories =  await _unitOfWork.CategoryRepository.AllAsync();

            return Ok(categories);
        }
    }
}
