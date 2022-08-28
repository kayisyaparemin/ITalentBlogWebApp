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
            var response = _postService.GetPostsWithCategoriesAndComments();

            return new ObjectResult(response) { StatusCode = response.Status };
        }
     
        [HttpPost]
        public IActionResult CreatePost(PostCreateDto request)
        {
            var response = _postService.CreatePost(request);

            return new ObjectResult(response) { StatusCode = response.Status };
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePost(int id)
        {
            var response = _postService.DeletePost(id);

            return new ObjectResult(response) { StatusCode = response.Status };
        }

        [HttpPut]
        public IActionResult UpdatePost(PostUpdateDto request)
        {
            var response = _postService.UpdatePost(request);

            return new ObjectResult(response) { StatusCode = response.Status };
        }

        [HttpGet("{id}")]
        public IActionResult GetPostById(int id)
        {
            var response = _postService.GetPostById(id);

            return new ObjectResult(response) { StatusCode = response.Status };
        }
        [Route("[action]")]
        [HttpPost]
        public IActionResult AddComment(CreateCommentDto request)
        {
            var response = _postService.AddComment(request);

            return new ObjectResult(response) { StatusCode = response.Status };
        }

    }
}
