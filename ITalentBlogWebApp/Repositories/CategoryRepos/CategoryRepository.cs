using ITalentBlogWebApp.Models;
using ITalentBlogWebApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ITalentBlogWebApp.Repositories.CategoryRepos
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }
        public void AddCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();

        }
        public void DeleteCategory(int id)
        {
            var category = _context.Categories.Find(id);
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }
        public bool ExistsCategory(string name)
        {
            return _context.Categories.Any(x=>x.Name == name);
        }

        public Category GetCategoryById(int id)
        {
            return _context.Categories.Find(id);

        }
    }
}
