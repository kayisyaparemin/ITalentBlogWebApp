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

        public async Task<HttpResponseMessage> CreateCategory(CategoryCreateViewModel request)
        {
            return await _client.PostAsJsonAsync<CategoryCreateViewModel>("Category", request);
        }

        public async Task<bool> DeleteCategory(int id)
        {
            var response = await _client.DeleteAsync($"Category/{id}");

            return response.IsSuccessStatusCode;
        }

        public async Task<CategoryUpdateViewModel> GetCategoryById(int id)
        {

            var response = await _client.GetAsync($"Category/{id}");


            var responseContent = await response.Content.ReadFromJsonAsync<Response<CategoryUpdateViewModel>>();

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

        public async Task<bool> UpdateCategory(CategoryUpdateViewModel request)
        {
            var response = await _client.PutAsJsonAsync("Category", request);

            return response.IsSuccessStatusCode;

        }

        public async Task<bool> ExistsCategory(string Name)
        {

            var response = await _client.GetAsync($"Category/ExistsCategory/{Name}");


            var responseContent = await response.Content.ReadFromJsonAsync<Response<bool>>();

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
