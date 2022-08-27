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
    }
}
