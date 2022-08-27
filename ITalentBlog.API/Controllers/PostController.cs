using ITalentBlog.Core.DTOs;
using ITalentBlog.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITalentBlog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public IActionResult GetPosts()
        {
            var response = _postService.GetPostsWithCategories();

            return new ObjectResult(response) { StatusCode = response.Status };
        }
     
        [HttpPost]
        public IActionResult CreatePost(PostCreateDto request)
        {
            var response = _postService.CreatePost(request);

            return new ObjectResult(response) { StatusCode = response.Status };
        }
        
    }
}
