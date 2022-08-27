using ITalentBlog.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITalentBlog.Core.Repositories
{
    public interface ICategoryRepository
    {
        public void AddCategory(Category category);
        public void UpdateCategory(Category category);
        public void DeleteCategory(int id);
        public List<Category> GetCategories();
        public bool ExistsCategory(string name);

        public Category? GetCategoryById(int id);
    }
}
