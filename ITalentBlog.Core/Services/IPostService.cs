using ITalentBlog.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITalentBlog.Core.Services
{
    public interface IPostService
    {
        CustomResponse<List<PostDto>> GetPosts();
        CustomResponse<List<PostDto>> GetPostsWithCategories();

        CustomResponse<PostDto> CreatePost(PostCreateDto request);

        CustomResponse<string> DeletePost(int id);

        CustomResponse<PostUpdateDto> UpdatePost(PostUpdateDto request);
        CustomResponse<PostDto> GetPostById(int id);
    }
}
