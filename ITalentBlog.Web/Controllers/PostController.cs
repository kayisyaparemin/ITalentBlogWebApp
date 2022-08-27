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

        public PostController(IFileProvider fileProvider,IMapper mapper,IPostService postService)
        {
            _fileProvider = fileProvider;
            _mapper = mapper;
            _postService = postService;
        }
        public async Task<IActionResult> Index()
        {
            var posts = await _postService.GetPosts();
            return View(posts);
        }

        [Route("Posts/{categoryName}/{id}")]
        public async Task<IActionResult> PostView(int id, string categoryName)
        {
            var posts = await _postService.GetPosts();
            var post = posts.FirstOrDefault(x => x.Id == id);

            return View(_mapper.Map<PostViewModel>(post));
        }



        //public IActionResult CreatePost()
        //{
        //    var categories = _postRepository.GetCategories();
        //    ViewBag.selectList = new SelectList(categories, "Id", "Name");
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult CreatePost(PostCreateViewModel request,IFormFile Image)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        var categories = _postRepository.GetCategories();
        //        ViewBag.selectList = new SelectList(categories, "Id", "Name");
        //        return View(request);
        //    }

        //    var fileName = Guid.NewGuid().ToString();
        //    SaveImage(Image, fileName);
        //    var post = _mapper.Map<Post>(request);
        //    post.ImageName = $"{fileName}{Path.GetExtension(Image.FileName)}";
        //    _postRepository.CreatePost(post);

        //    return RedirectToAction("Index");
        //}

        //public async void SaveImage(IFormFile image, string fileName)
        //{
        //    if (image != null && image.Length > 0)
        //    {
        //        var root = _fileProvider.GetDirectoryContents("wwwroot");
        //        var imagesDirectory = root.Single(x => x.Name == "pictures");
        //        var ext = Path.GetExtension(image.FileName);
        //        var path = Path.Combine(imagesDirectory.PhysicalPath, fileName + ext);
        //        using var stream = new FileStream(path, FileMode.Create);
        //        await image.CopyToAsync(stream);

        //    }
        //}
    }
}
