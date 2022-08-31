using AutoMapper;
using ITalentBlog.Web.Models;
using ITalentBlog.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System.Xml.Linq;

namespace ITalentBlog.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IFileProvider _fileProvider;
        private readonly IMapper _mapper;
        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;

        public CategoryController(IFileProvider fileProvider, IMapper mapper, IPostService postService, ICategoryService categoryService)
        {
            _fileProvider = fileProvider;
            _mapper = mapper;
            _postService = postService;
            _categoryService = categoryService;
        }
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCategory(CategoryCreateViewModel request)
        {
            _categoryService.CreateCategory(request);
            return RedirectToAction("AdminPanel", "Home");
        }

        public IActionResult DeleteCategory(int id,string confirm_value)
        {
            if (confirm_value == "Yes")
            {
                _categoryService.DeleteCategory(id);
                return RedirectToAction("AdminPanel", "Home");
            }

            return RedirectToAction("EditCategories", "Category");
        }
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var category = await _categoryService.GetCategoryById(id);
            return View(category);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(CategoryUpdateViewModel request)
        {
            var category = await _categoryService.UpdateCategory(request);
            return RedirectToAction("AdminPanel", "Home");
        }
        public async Task<IActionResult> AnyCategoryName(string Name)
        {
            var IsExısts = await _categoryService.ExistsCategory(Name);
            if (IsExısts)
            {
                return Json("This category name already exists");
            }
            return Json(true);
        }
        public async Task<IActionResult> EditCategories()
        {
            var categories = await _categoryService.GetCategories();
            return View(categories);
        }
    }
}
