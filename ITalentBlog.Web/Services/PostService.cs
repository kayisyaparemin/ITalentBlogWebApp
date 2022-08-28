using ITalentBlog.Web.Models;
using System.Net.Http.Json;

namespace ITalentBlog.Web.Services
{
    public class PostService : IPostService
    {
        private readonly HttpClient _client;
        private readonly ILogger<PostService> _logger;

        public PostService(HttpClient client, ILogger<PostService> logger)
        {
            _client = client;
            _logger = logger;
        }
        public async Task<HttpResponseMessage> CreatePost(PostCreateViewModel request)
        {
            return await _client.PostAsJsonAsync<PostCreateViewModel>("Post", request);
        }
        public async Task<List<PostViewModel>> GetPosts()
        {

            var response = await _client.GetAsync("Post");


            var responseContent = await response.Content.ReadFromJsonAsync<Response<List<PostViewModel>>>();

            if (response.IsSuccessStatusCode)
            {

                return responseContent.Data;


            }

            foreach (var item in responseContent.Errors)
            {
                _logger.LogError(item);
            }
            throw new Exception("İşlem gerçekleşirken bir hata meydana geldi.");
        }
        public async Task<bool> DeletePost(int id)
        {
            var response = await _client.DeleteAsync($"Post/{id}");

            return response.IsSuccessStatusCode;
        }
        public async Task<PostUpdateViewModel> GetPostById(int id)
        {

            var response = await _client.GetAsync($"Post/{id}");


            var responseContent = await response.Content.ReadFromJsonAsync<Response<PostUpdateViewModel>>();

            if (response.IsSuccessStatusCode)
            {

                return responseContent.Data;


            }

            foreach (var item in responseContent.Errors)
            {
                _logger.LogError(item);
            }
            throw new Exception("İşlem gerçekleşirken bir hata meydana geldi.");
        }
        public async Task<bool> UpdatePost(PostUpdateViewModel request)
        {
            var response = await _client.PutAsJsonAsync("Post",request);

            return response.IsSuccessStatusCode;

        }

        public async Task<HttpResponseMessage> AddComment(CommentCreateViewModel request)
        {
            return await _client.PostAsJsonAsync<CommentCreateViewModel>("Post/AddComment", request);
        }


    }
}