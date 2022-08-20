using ITalentBlogWebApp.Models;
using System.Linq.Expressions;

namespace ITalentBlogWebApp.Repositories
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

        public Post GetById(int id)
        {
            return _context.Posts.Find(id);
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

    }
}
