using AutoMapper;
using ITalentBlogWebApp.Models;
using ITalentBlogWebApp.Models.ViewModels;
using ITalentBlogWebApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using static System.Net.Mime.MediaTypeNames;

namespace ITalentBlogWebApp.Controllers
{
    public class FileController : Controller
    {
        private readonly IFileProvider _fileProvider;
        private readonly IMapper _mapper;
        private readonly IPostRepository _postRepository;

        public FileController(IFileProvider fileProvider, IMapper mapper, IPostRepository postRepository)
        {
            _fileProvider = fileProvider;
            _mapper = mapper;
            _postRepository = postRepository;
        }
        public IActionResult PictureSave()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> PictureSave(PictureViewModel request)
        {
            if (request.picture != null && request.picture.Length > 0)
            {
                var root = _fileProvider.GetDirectoryContents("wwwroot");
                var imagesDirectory = root.Single(x => x.Name == "pictures");
                var path = Path.Combine(imagesDirectory.PhysicalPath, request.picture.FileName);
                using var stream = new FileStream(path, FileMode.Create);
                await request.picture.CopyToAsync(stream);
            }
            var picture = _mapper.Map<Picture>(request);
            _postRepository.AddPicture(picture);

            return View();
        }
    }
}
