using ITalentBlogWebApp.Models;
using ITalentBlogWebApp.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ITalentBlogWebApp.Repositories.PostRepos
{
    public class PostRepository : IPostRepository
    {
        private readonly AppDbContext _context;

        public PostRepository(AppDbContext context)
        {
            _context = context;
        }

        public void CreatePost(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
        }

        public void DeletePost(int id)
        {
            var removePost = _context.Posts.Find(id);
            _context.Posts.Remove(removePost);
            _context.SaveChanges();
        }

        public bool ExistsTitle(string Title)
        {
            return _context.Posts.Any(x => x.Title == Title);
        }

        public Post GetById(int id)
        {
            return _context.Posts.Find(id);
        }

        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public List<Post> GetPosts()
        {
            return _context.Posts.ToList();
        }

        public void UpdatePost(Post post)
        {
            _context.Update(post);
            _context.SaveChanges();
        }
        public List<Post> PostsWithCategory()
        {
            return _context.Posts.Include(x => x.Category).ToList();
        }
        public (List<Post>, int) GetPostsWithPaged(int page, int pageSize)
        {
            var posts = PostsWithCategory();
            int totalCount = posts.Count;
            var ListedPosts = posts.Skip(pageSize * (page - 1)).Take(pageSize).ToList();
            return (ListedPosts, totalCount);

        }
        public (List<Post>, int) GetPostsWithPagedFilteredByCategory(int page, int pageSize, string categoryName)
        {
            var posts = PostsWithCategory().Where(x => x.Category.Name == categoryName).ToList();
            int totalCount = posts.Count;
            var ListedPosts = posts.Skip(pageSize * (page - 1)).Take(pageSize).ToList();
            return (ListedPosts, totalCount);

        }

        public (List<Post>, int) GetPostsWithPagedFilteredByQuery(int page, int pageSize, string query)
        {
            var posts = PostsWithCategory().Where(x => x.Description.ToLower().Contains(query.ToLower()) || x.Title.ToLower().Contains(query.ToLower())).ToList();
            int totalCount = posts.Count;
            var ListedPosts = posts.Skip(pageSize * (page - 1)).Take(pageSize).ToList();
            return (ListedPosts, totalCount);

        }



    }
}
