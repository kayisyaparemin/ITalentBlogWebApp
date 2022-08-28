using AutoMapper;
using ITalentBlog.Core;
using ITalentBlog.Core.DTOs;
using ITalentBlog.Core.Models;
using ITalentBlog.Core.Repositories;
using ITalentBlog.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITalentBlog.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public PostService(IPostRepository postRepository,IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }
        public CustomResponse<string> DeletePost(int id)
        {
            if (!_postRepository.Any(id))
            {
                return CustomResponse<string>.Fail($"Id'si {id} olan ürün bulunamamıştır", 404);

            }
            _postRepository.DeletePost(id);

            return CustomResponse<string>.Success(String.Empty, 204);
        }
        public CustomResponse<PostDto> CreatePost(PostCreateDto request)
        {
            var newPost = _mapper.Map<Post>(request);
            _postRepository.CreatePost(newPost);

            var newPostDto = _mapper.Map<PostDto>(newPost);

            return CustomResponse<PostDto>.Success(newPostDto, 201);
        }

        public CustomResponse<List<PostDto>> GetPostsWithCategoriesAndComments()
        {
            var posts = _postRepository.GetPostsWithCategoriesAndComments();

            var postDtoList = _mapper.Map<List<PostDto>>(posts);

            return CustomResponse<List<PostDto>>.Success(postDtoList, 200);
        }

        public CustomResponse<PostUpdateDto> UpdatePost(PostUpdateDto request)
        {
            var UpdatedPost = _mapper.Map<Post>(request);
            _postRepository.UpdatePost(UpdatedPost);

            var updatedPostDto = _mapper.Map<PostUpdateDto>(UpdatedPost);

            return CustomResponse<PostUpdateDto>.Success(updatedPostDto, 201);
        }

        public CustomResponse<PostDto> GetPostById(int id)
        {
            var post = _postRepository.GetById(id);

            var postDto = _mapper.Map<PostDto>(post);

            return CustomResponse<PostDto>.Success(postDto, 200);
        }

        public CustomResponse<CreateCommentDto> AddComment(CreateCommentDto request)
        {
            var newComment = _mapper.Map<Comment>(request);
            _postRepository.AddComment(newComment);

            var newCommentDto = _mapper.Map<CreateCommentDto>(newComment);

            return CustomResponse<CreateCommentDto>.Success(newCommentDto, 201);
        }

       
    }
}
