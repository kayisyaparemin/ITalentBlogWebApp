﻿using ITalentBlog.Core.Models;
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
        public Post CreatePost(Post post)
        {
            post.CreatedDate = DateTime.Now.ToString();
            _context.Posts.Add(post);
            _context.SaveChanges();
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
            _context.SaveChanges();
        }

        public void UpdatePost(Post post)
        {
            _context.Update(post);
            _context.SaveChanges();
        }

        public Post? GetById(int id)
        {
            return GetPostsWithCategoriesAndComments().FirstOrDefault(x => x.Id == id);
        }

        public void AddComment(Comment comment)
        {
            var post = _context.Posts.Find(comment.PostId);
            post.Comments.Add(comment);
            _context.SaveChanges();
        }
    }
}
