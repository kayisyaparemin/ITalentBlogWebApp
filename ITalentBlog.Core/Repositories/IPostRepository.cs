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
        public List<Post> GetPosts();

        public Post CreatePost(Post post);

        public List<Post> GetPostsWithCategories();
    }
}
