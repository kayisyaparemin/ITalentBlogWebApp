using ITalentBlog.Core.DTOs.Comment;
using ITalentBlog.Core.DTOs.Post;
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

        [HttpGet("{pageSize}/{page}")]
        public IActionResult GetPostsWithPaged(int page,int pageSize)
        {
            var response = _postService.GetPostsWithPaged(page, pageSize);

            return new ObjectResult(response) { StatusCode = response.Status };
        }
        [HttpGet("{categoryName}/{pageSize}/{page}")]
        public IActionResult GetPostsWithPagedFilteredByCategory(int page, int pageSize,string categoryName)
        {
            var response = _postService.GetPostsWithPagedFilteredByCategory(page, pageSize,categoryName);

            return new ObjectResult(response) { StatusCode = response.Status };
        }

        [HttpGet("ExistsTitle/{Title}")]
        public IActionResult ExistsTitle(string Title)
        {
            var response = _postService.ExistsTitle(Title);

            return new ObjectResult(response) { StatusCode = response.Status };
        }


    }
}
