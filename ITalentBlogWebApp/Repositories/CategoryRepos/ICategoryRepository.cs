using ITalentBlogWebApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ITalentBlogWebApp.Repositories.CategoryRepos
{
    public interface ICategoryRepository
    {
        public void AddCategory(Category category);
        public void UpdateCategory(Category category);
        public void DeleteCategory(int id);

        public bool ExistsCategory(string name);

        public Category GetCategoryById(int id);
    }
}
