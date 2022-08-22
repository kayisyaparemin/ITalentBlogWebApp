using AutoMapper;
using ITalentBlogWebApp.Models;
using ITalentBlogWebApp.Models.ViewModels;
using ITalentBlogWebApp.Repositories;
using ITalentITalentBlogWebApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.FileProviders;

namespace ITalentBlogWebApp.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostRepository _postRepository;
        private readonly IFileProvider _fileProvider;
        private readonly IMapper _mapper;

        public PostController(IPostRepository postRepository,IFileProvider fileProvider,IMapper mapper)
        {
            _postRepository = postRepository;
            _fileProvider = fileProvider;
            _mapper = mapper;
        }
        public IActionResult Index(int page=1)
        {
            var pageSize = 6;
            var postList = _mapper.Map<List<PostViewModel>>(_postRepository.GetPostsWithPaged(page, pageSize).Item1);
            var totalCount = _postRepository.GetPostsWithPaged(page, pageSize).Item2;
            int totalPage = (int)Math.Ceiling((decimal)totalCount / pageSize);
            ViewBag.totalPage = totalPage;
            ViewBag.page = page;
            return View(postList);
        }

        public async void SaveImage(IFormFile image,string fileName)
        {
            if (image != null && image.Length > 0)
            {
                var root = _fileProvider.GetDirectoryContents("wwwroot");
                var imagesDirectory = root.Single(x => x.Name == "pictures");
                var ext = Path.GetExtension(image.FileName);
                var path = Path.Combine(imagesDirectory.PhysicalPath,fileName+ext);
                using var stream = new FileStream(path, FileMode.Create);
                await image.CopyToAsync(stream);
               
            }  
        }

        public IActionResult AnyPostTitle(string Title)
        {
            if (_postRepository.ExistsTitle(Title))
            {
               return Json("This title is already exists");
            }

            return Json(true);        
        }

        public IActionResult CreatePost()
        {
            var categories = _postRepository.GetCategories();
            ViewBag.selectList = new SelectList(categories, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult CreatePost(PostCreateViewModel request)
        {
            if (!ModelState.IsValid)
            {
                var categories = _postRepository.GetCategories();
                ViewBag.selectList = new SelectList(categories, "Id", "Name");
                return View(request);
            }

            var fileName = Guid.NewGuid().ToString();
            SaveImage(request.Image, fileName);
            var post = _mapper.Map<Post>(request);
            post.ImageName = $"{fileName}{Path.GetExtension(request.Image.FileName)}";
            _postRepository.CreatePost(post);
            
            return RedirectToAction("Index");
        }
        public IActionResult UpdateDeletePost()
        {
            return View();
        }
        public IActionResult AdminPanel()
        {
            var postList = _mapper.Map<List<PostViewModel>>(_postRepository.PostsWithCategory());
            return View(postList);

        }

        public IActionResult DeletePost(int id)
        {
            _postRepository.DeletePost(id);
            return RedirectToAction("Index");
        }

        public IActionResult UpdatePost(int id)
        {
            var categories = _postRepository.GetCategories();
            ViewBag.selectList = new SelectList(categories, "Id", "Name");
            var updatePostView = _mapper.Map<PostUpdateViewModel>(_postRepository.GetById(id));
            return View(updatePostView);
        }
        [HttpPost]
        public IActionResult UpdatePost(PostUpdateViewModel request)
        {
            var updatedPost = _mapper.Map<Post>(request);

            if (request.Image != null)
            {
                var fileName = Guid.NewGuid().ToString();
                SaveImage(request.Image, fileName);
                updatedPost.ImageName = $"{fileName}{Path.GetExtension(request.Image.FileName)}";
            }
            _postRepository.UpdatePost(updatedPost);
            return RedirectToAction("Index");
        }

        
    }
}

