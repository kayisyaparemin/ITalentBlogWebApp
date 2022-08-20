using ITalentBlogWebApp.Models;
using System.Linq.Expressions;

namespace ITalentBlogWebApp.Repositories
{
    public interface IPostRepository
    {
        public List<Post> GetPosts();

        public void CreatePost(Post post);

        public void UpdatePost(Post post);

        public Post GetById(int id);

        public void DeletePost(int id);


    }
}
