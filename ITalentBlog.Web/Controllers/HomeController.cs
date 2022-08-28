﻿using AutoMapper;
using ITalentBlog.Web.Models;
using ITalentBlog.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System.Diagnostics;

namespace ITalentBlog.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFileProvider _fileProvider;
        private readonly IMapper _mapper;
        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;

        public HomeController(ILogger<HomeController> logger,IFileProvider fileProvider, IMapper mapper, IPostService postService, ICategoryService categoryService)
        {
            _logger = logger;
            _fileProvider = fileProvider;
            _mapper = mapper;
            _postService = postService;
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            var posts = await _postService.GetPosts();
            var categories = await _categoryService.GetCategories();
            return View(new IndexViewModel() { Posts=posts,Categories=categories});
        }

        public ActionResult AdminPanel()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ContactMe()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
    }
}