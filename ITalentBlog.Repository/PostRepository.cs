using ITalentBlog.Core.Models;
using ITalentBlog.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        public Post CreatePost(Post post)
        {
            post.CreatedDate = DateTime.Now.ToString();
            _context.Posts.Add(post);
            return post;
        }

        public List<Post> GetPostsWithCategoriesAndComments()
        {
            return _context.Posts.Include(x=>x.Category).Include(c=>c.Comments).ToList();
        }

        public bool Any(int id)
        {
            return _context.Posts.Any(x => x.Id == id);
        }

        public void DeletePost(int id)
        {
            var entity = _context.Posts.Find(id);
            _context.Posts.Remove(entity);
        }

        public void UpdatePost(Post post)
        {
            post.CreatedDate = DateTime.Now.ToString();
            _context.Update(post);
        }

        public Post? GetById(int id)
        { 
            return GetPostsWithCategoriesAndComments().FirstOrDefault(x => x.Id == id);
        }

        public void AddComment(Comment comment)
        {
            var post = _context.Posts.Find(comment.PostId);
            post.Comments.Add(comment);
        }

        public (List<Post>, int) GetPostsWithPaged(int page, int pageSize)
        {
            var posts = GetPostsWithCategoriesAndComments();
            int totalCount = posts.Count;
            var ListedPosts = posts.Skip(pageSize * (page - 1)).Take(pageSize).ToList();
            return (ListedPosts, totalCount);
        }

        public bool ExistsTitle(string Title)
        {
            return _context.Posts.Any(x => x.Title.ToLower().Trim() == Title.ToLower().Trim());
        }

        public (List<Post>, int) GetPostsWithPagedFilteredByCategory(int page, int pageSize, string categoryName)
        {
            IQueryable<Post> posts = _context.Posts.Include(x => x.Category).Include(c => c.Comments).Where(x => x.Category.Name == categoryName);
            int totalCount = posts.Count();
            var ListedPosts = posts.Skip(pageSize * (page - 1)).Take(pageSize).ToList();
            return (ListedPosts, totalCount);
        }

        public void DeleteComment(int postId, int commentId)
        {
            var entity = GetPostsWithCategoriesAndComments().FirstOrDefault(x => x.Id == postId);
            var comment = entity.Comments.FirstOrDefault(x => x.Id == commentId);
            entity.Comments.Remove(comment);
        }
    }
}
