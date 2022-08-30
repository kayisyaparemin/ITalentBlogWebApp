using ITalentBlog.Core.DTOs;
using ITalentBlog.Core.DTOs.Post;
using ITalentBlog.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITalentBlog.Core.Repositories
{
    public interface IPostRepository
    {
        public Post CreatePost(Post post);

        public List<Post> GetPostsWithCategoriesAndComments();

        public bool Any(int id);

        public void DeletePost(int id);

        public void UpdatePost(Post post);

        public Post? GetById(int id);

        public void AddComment(Comment comment);

        public (List<Post>,int) GetPostsWithPaged(int page,int pageSize);
        public (List<Post>,int) GetPostsWithPagedFilteredByCategory(int page,int pageSize,string categoryName);

        public bool ExistsTitle(string Title);
    }
}
