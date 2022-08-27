using ITalentBlog.Web.Models;

namespace ITalentBlog.Web.Services
{
    public interface ICategoryService
    {
        Task<List<CategoryViewModel>> GetCategories();
    }
}
