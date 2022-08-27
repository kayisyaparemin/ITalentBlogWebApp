using ITalentBlog.Web.Models;

namespace ITalentBlog.Web.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _client;
        private readonly ILogger<CategoryService> _logger;

        public CategoryService(HttpClient client, ILogger<CategoryService> logger)
        {
            _client = client;
            _logger = logger;
        }
        public async Task<List<CategoryViewModel>> GetCategories()
        {
            var response = await _client.GetAsync("Category");


            var responseContent = await response.Content.ReadFromJsonAsync<Response<List<CategoryViewModel>>>();

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
