using ITalentBlog.Web.Models;

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
        public Task<HttpResponseMessage> Create(PostCreateViewModel request)
        {
            throw new NotImplementedException();
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
    }
}