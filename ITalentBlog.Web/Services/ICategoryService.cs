using ITalentBlog.Web.Models;

namespace ITalentBlog.Web.Services
{
    public interface ICategoryService
    {
        Task<List<CategoryViewModel>> GetCategories();

        Task<HttpResponseMessage> CreateCategory(CategoryCreateViewModel request);

        Task<bool> DeleteCategory(int id);

        Task<CategoryUpdateViewModel> GetCategoryById(int id);

        Task<bool> UpdateCategory(CategoryUpdateViewModel request);
    }
}
