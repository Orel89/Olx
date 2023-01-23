using LS.Helpers.Hosting.API;
using LS.Helpers.Hosting.Extensions;
using Microsoft.AspNetCore.Mvc;
using OlxCore;
using OlxCore.Entities;
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
            ExecutionResult<IEnumerable<Category>> categoryResponse;

            var categories =  await _unitOfWork.CategoryRepository.AllAsync();

            if (categories.Any())
            {
                categoryResponse = new ExecutionResult<IEnumerable<Category>>(categories);
                return Ok(categoryResponse);
            }
            else
            {
                categoryResponse = new ExecutionResult<IEnumerable<Category>>(new ErrorInfo(Constants.CATEGORIES_NOT_FOUND));
                return this.FromExecutionResult(categoryResponse);
            }
        }
    }
}
