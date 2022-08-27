﻿using AutoMapper;
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


        [Route("Posts/{categoryName}/{id}")]
        public async Task<IActionResult> PostView(int id, string categoryName)
        {
            var posts = await _postService.GetPosts();
            var post = posts.FirstOrDefault(x => x.Id == id);

            return View(_mapper.Map<PostViewModel>(post));
        }

        public async Task<IActionResult> CreatePost()
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

        public async Task<IActionResult> DeletePost(int id)
        {
            await _postService.DeletePost(id);
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> UpdatePost(int id)
        {
            var categories = await _categoryService.GetCategories();
            ViewBag.selectList = new SelectList(categories, "Id", "Name");
            var updatedPost = await _postService.GetPostById(id);
            return View(updatedPost);
        }
        [HttpPost]
        public async Task<IActionResult> UpdatePost(PostUpdateViewModel request)
        {
            var fileName = Guid.NewGuid().ToString();
            SaveImage(request.Image, fileName);
            request.ImageName = $"{fileName}{Path.GetExtension(request.Image.FileName)}";
            await _postService.UpdatePost(request);
            return RedirectToAction("Index", "Home");
        }
    }
}