using ITalentBlog.Core.Models;
using ITalentBlog.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITalentBlog.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public bool Any(int id)
        {
            return _context.Categories.Any(c => c.Id == id);    
        }

        public void CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            var deletedCategory = _context.Categories.Find(id);
            _context.Remove(deletedCategory);
            _context.SaveChanges();
        }

        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Category? GetCategoryById(int id)
        {
            return _context.Categories.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateCategory(Category category)
        {
            _context.Update(category);
            _context.SaveChanges();
        }
    }
}
