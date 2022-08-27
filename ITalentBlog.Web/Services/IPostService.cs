using ITalentBlog.Web.Models;

namespace ITalentBlog.Web.Services
{
    public interface IPostService
    {
        Task<List<PostViewModel>> GetPosts();


        Task<HttpResponseMessage> Create(PostCreateViewModel request);
    }
}
