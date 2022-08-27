using ITalentBlog.Core.Models;
using ITalentBlog.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITalentBlog.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly AppDbContext _context;

        public PostRepository(AppDbContext context)
        {
            _context = context;
        }
        public List<Post> GetPosts()
        {
            return _context.Posts.ToList();
        }

        public Post CreatePost(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
            return post;
        }

        public List<Post> GetPostsWithCategories()
        {
            return _context.Posts.Include(x=>x.Category).ToList();
        }

        public bool Any(int id)
        {
            return _context.Posts.Any(x => x.Id == id);
        }

        public void DeletePost(int id)
        {
            var entity = _context.Posts.Find(id);
            _context.Posts.Remove(entity);
            _context.SaveChanges();
        }

        public void UpdatePost(Post post)
        {
            _context.Update(post);
            _context.SaveChanges();
        }

        public Post? GetById(int id)
        {
            return GetPostsWithCategories().FirstOrDefault(x => x.Id == id);
        }
    }
}
