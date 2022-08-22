using AutoMapper;
using ITalentBlogWebApp.Controllers;
using ITalentBlogWebApp.Models;
using ITalentBlogWebApp.Models.ViewModels;
using ITalentBlogWebApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
namespace ITalentITalentBlogWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger,IPostRepository postRepository,IMapper mapper)
        {
            _logger = logger;
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ContactMe()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult About()
        {
            return View();
        }
    }
}