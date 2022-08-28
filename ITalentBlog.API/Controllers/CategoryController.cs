using ITalentBlog.Core.DTOs;
using ITalentBlog.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITalentBlog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public IActionResult GetCategories()
        {
            var response = _categoryService.GetCategories();    

            return new ObjectResult(response) { StatusCode = response.Status };
        }
        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto request)
        {
            var response = _categoryService.CreateCategory(request);

            return new ObjectResult(response) { StatusCode = response.Status };
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var response = _categoryService.DeleteCategory(id);

            return new ObjectResult(response) { StatusCode = response.Status };
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            var response = _categoryService.GetCategoryById(id);

            return new ObjectResult(response) { StatusCode = response.Status };
        }
        [HttpPut]
        public IActionResult UpdateCategory(CategoryUpdateDto request)
        {
            var response = _categoryService.UpdateCategory(request);

            return new ObjectResult(response) { StatusCode = response.Status };
        }

        [HttpGet("ExistsCategory/{Name}")]
        public IActionResult ExistsCategory(string Name)
        {
            var response = _categoryService.ExistsCategory(Name);

            return new ObjectResult(response) { StatusCode = response.Status };
        }
    }
}
