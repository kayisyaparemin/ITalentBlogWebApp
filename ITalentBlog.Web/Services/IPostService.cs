using ITalentBlog.Web.Models;

namespace ITalentBlog.Web.Services
{
    public interface IPostService
    {
        Task<List<PostViewModel>> GetPosts();


        Task<HttpResponseMessage> CreatePost(PostCreateViewModel request);

        Task<bool> DeletePost(int id);

        Task<PostUpdateViewModel> GetPostById(int id);

        Task<bool> UpdatePost(PostUpdateViewModel request);
    }
}
