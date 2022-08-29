using ITalentBlog.Web.Models;

namespace ITalentBlog.Web.Services
{
    public interface IPostService
    {
        Task<List<PostViewModel>> GetPosts();


        Task<HttpResponseMessage> CreatePost(PostCreateViewModel request);

        Task<bool> DeletePost(int id);

        Task<PostViewModel> GetPostById(int id);

        Task<bool> UpdatePost(PostUpdateViewModel request);

        Task<HttpResponseMessage> AddComment(CommentCreateViewModel request);

        Task<(List<PostViewModel>, int)> GetPostsWithPaged(int page, int pageSize);



    }
}
