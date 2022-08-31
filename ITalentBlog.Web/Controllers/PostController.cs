using AutoMapper;
using ITalentBlog.Web.Models;
using ITalentBlog.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.FileProviders;

namespace ITalentBlog.Web.Controllers
{
    public class PostController : Controller
    {
        private readonly IFileProvider _fileProvider;
        private readonly IMapper _mapper;
        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;

        public PostController(IFileProvider fileProvider,IMapper mapper,IPostService postService,ICategoryService categoryService)
        {
            _fileProvider = fileProvider;
            _mapper = mapper;
            _postService = postService;
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            return View();
        }       
        public async Task<IActionResult> PostView(int id)
        {
            var post = await _postService.GetPostById(id);
            return View(post);
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(PostViewModel request)
        {
            request.Comment.PostId = request.Id;
            await _postService.AddComment(request.Comment);
            return RedirectToAction($"PostView", new { id = request.Id });
        }

        public async Task<IActionResult> CreatePost(string confirm_value)
        {
           
            var categories = await _categoryService.GetCategories();
                ViewBag.selectList = new SelectList(categories, "Id", "Name");
                return View();
           
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(PostCreateViewModel request)
        {
            if (!ModelState.IsValid)
            {
                var categories = await _categoryService.GetCategories();
                ViewBag.selectList = new SelectList(categories, "Id", "Name");
                return View(request);
            }

            var fileName = Guid.NewGuid().ToString();
            SaveImage(request.Image, fileName);
            request.ImageName = $"{fileName}{Path.GetExtension(request.Image.FileName)}";
            await _postService.CreatePost(request);

            return RedirectToAction("Index", "Home");
        }

        private async void SaveImage(IFormFile image, string fileName)
        {
            if (image != null && image.Length > 0)
            {
                var root = _fileProvider.GetDirectoryContents("wwwroot");
                var imagesDirectory = root.Single(x => x.Name == "pictures");
                var ext = Path.GetExtension(image.FileName);
                var path = Path.Combine(imagesDirectory.PhysicalPath, fileName + ext);
                using var stream = new FileStream(path, FileMode.Create);
                await image.CopyToAsync(stream);

            }
        }
        public async Task<IActionResult> DeletePost(string confirm_value,int id)
        {
            if (confirm_value == "Yes")
            {
                var result = await _postService.DeletePost(id);
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("EditPosts", "Post");
            
        }

        public async Task<IActionResult> UpdatePost(int id)
        {
            var categories = await _categoryService.GetCategories();
            ViewBag.selectList = new SelectList(categories, "Id", "Name");
            var updatedPost = await _postService.GetPostById(id);
            
            return View(_mapper.Map<PostUpdateViewModel>(updatedPost));
        }
        [HttpPost]
        public async Task<IActionResult> UpdatePost(PostUpdateViewModel request)
        {
            var fileName = Guid.NewGuid().ToString();
            SaveImage(request.Image, fileName);

            if(request.Image != null) { request.ImageName = $"{fileName}{Path.GetExtension(request.Image.FileName)}"; }
            
            await _postService.UpdatePost(request);
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> EditPosts()
        {
            var posts = await _postService.GetPosts();
            return View(posts);
        }

        public async Task<IActionResult> AnyPostTitle(string Title)
        {
            var IsExısts = await _postService.ExistsTitle(Title);
            if (IsExısts)
            {
                return Json("This Title already exists");
            }
            return Json(true);
        }
        public async Task<IActionResult> DeleteComment(int postId)
        {
            var post = await _postService.GetPostById(postId);

            return View(post);
        }
        [Route("/Post/{postId}/Comment/{commentId}")]
        public async Task<IActionResult> DeleteComment(int postId,int commentId)
        {
            var post = await _postService.DeleteComment(postId, commentId);

            return RedirectToAction("AdminPanel","Home"); 
        }

    }
}
