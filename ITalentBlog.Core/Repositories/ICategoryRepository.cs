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
        public List<Category> GetCategories();

        public void CreateCategory(Category category);

        public void DeleteCategory(int id);
        public bool Any(int id);

        public Category? GetCategoryById(int id);
        public void UpdateCategory(Category category);

        public bool ExistsCategory(string Name);


    }
}
