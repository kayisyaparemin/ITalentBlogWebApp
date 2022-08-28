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

        CustomResponse<List<PostDto>> GetPostsWithCategoriesAndComments();

        CustomResponse<PostDto> CreatePost(PostCreateDto request);

        CustomResponse<string> DeletePost(int id);

        CustomResponse<PostUpdateDto> UpdatePost(PostUpdateDto request);
        CustomResponse<PostDto> GetPostById(int id);

        CustomResponse<CreateCommentDto> AddComment(CreateCommentDto request);
    }
}
