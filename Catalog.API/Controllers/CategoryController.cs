using Catalog.Application.Dtos;
using Catalog.Application.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route("/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly CreateCategory _createCategory;

        public CategoryController(CreateCategory createCategory)
        {
            _createCategory = createCategory;
        }

        public IActionResult Get()
        {
            return Ok("Catalog Module");
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] CreateCategoryRequest request)
        {
            await _createCategory.Execute(request.CategoryName);
            return Ok("Category created...");
        }
    }
}