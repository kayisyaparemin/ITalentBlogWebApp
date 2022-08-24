using AutoMapper;
using ITalentBlogWebApp.Models.Entities;
using ITalentBlogWebApp.Models.ViewModels;
using ITalentBlogWebApp.Models.ViewModels.Categories;
using ITalentBlogWebApp.Models.ViewModels.Posts;
using ITalentBlogWebApp.Repositories.CategoryRepos;
using ITalentBlogWebApp.Repositories.PostRepos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ITalentBlogWebApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public AdminController(IPostRepository postRepository,IMapper mapper,ICategoryRepository categoryRepository)
        {
            _postRepository = postRepository;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {
            var postList = _mapper.Map<List<PostViewModel>>(_postRepository.PostsWithCategory());
            var categories = _mapper.Map<List<CategoryViewModel>>(_postRepository.GetCategories()); //bu metodu category reposuna da yaz
            return View(new AdminViewModel() { Posts = postList,Categories=categories});
        }

        public IActionResult CreateCategory()
        {
            return View() ;
        }

        [HttpPost]
        public IActionResult CreateCategory(CategoryCreateViewModel request)
        {
            _categoryRepository.AddCategory(_mapper.Map<Category>(request));
            return RedirectToAction("Index");
        }

        public IActionResult AnyCategoryName(string Name)
        {
            if (_categoryRepository.ExistsCategory(Name))
            {
                return Json("This category name already exists");
            }
            return Json(true);
        }

        public IActionResult DeleteCategory(int id)
        {
            _categoryRepository.DeleteCategory(id);
            return RedirectToAction("Index");
        }
        public IActionResult UpdateCategory(int id)
        {
            var updateCategory = _categoryRepository.GetCategoryById(id);
            var updateViewModal = _mapper.Map<CategoryUpdateViewModal>(updateCategory);
            return View(updateViewModal);
        }
        [HttpPost]
        public IActionResult UpdateCategory(CategoryUpdateViewModal request)
        {
            _categoryRepository.UpdateCategory(_mapper.Map<Category>(request));
            return RedirectToAction("Index");
        }
    }
}
