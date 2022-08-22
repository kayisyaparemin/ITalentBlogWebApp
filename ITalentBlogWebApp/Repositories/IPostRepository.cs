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

        public bool ExistsTitle(string Title);

        public List<Category> GetCategories();

        public List<Post> PostsWithCategory();
        public (List<Post>, int) GetPostsWithPaged(int page, int pageSize);
    }
}
