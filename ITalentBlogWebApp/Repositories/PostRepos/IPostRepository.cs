using ITalentBlogWebApp.Models.Entities;
using System.Linq.Expressions;

namespace ITalentBlogWebApp.Repositories.PostRepos
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

        public (List<Post>, int) GetPostsWithPagedFilteredByCategory(int page, int pageSize, string categoryName);

        public (List<Post>, int) GetPostsWithPagedFilteredByQuery(int page, int pageSize, string query);
    }
}
