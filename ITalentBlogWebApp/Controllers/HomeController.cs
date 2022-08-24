using AutoMapper;
using ITalentBlogWebApp.Controllers;
using ITalentBlogWebApp.Models;
using ITalentBlogWebApp.Models.Entities;
using ITalentBlogWebApp.Models.ViewModels.Contact;
using ITalentBlogWebApp.Repositories.PostRepos;
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
        [HttpPost]
        public IActionResult ContactMe(ContactViewModel request)
        {
            SendEmail(_mapper.Map<Contact>(request));
            return View();
        }

  
        private void SendEmail(Contact contact)
        {
            //some sending email codes...
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