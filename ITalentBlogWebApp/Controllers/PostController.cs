using AutoMapper;
using ITalentBlogWebApp.Models;
using ITalentBlogWebApp.Models.ViewModels;
using ITalentBlogWebApp.Repositories;
using ITalentITalentBlogWebApp.Controllers;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(PostCreateViewModel request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            var fileName = Guid.NewGuid().ToString();
            SaveImage(request.Image,fileName);
            var Post = _mapper.Map<Post>(request);
            Post.ImageName = fileName + Path.GetExtension(request.Image.FileName);
            _postRepository.CreatePost(Post);

            return RedirectToAction(nameof(HomeController.Index));
        }

        public async void SaveImage(IFormFile image,string fileName)
        {
            if (image != null && image.Length > 0)
            {
                var root = _fileProvider.GetDirectoryContents("wwwroot");
                var imagesDirectory = root.Single(x => x.Name == "pictures");
                var ext = Path.GetExtension(image.FileName);
                var path = Path.Combine(imagesDirectory.PhysicalPath,fileName.ToString()+ext);
                using var stream = new FileStream(path, FileMode.Create);
                await image.CopyToAsync(stream);
               
            }

           
        }
  
    }
}

