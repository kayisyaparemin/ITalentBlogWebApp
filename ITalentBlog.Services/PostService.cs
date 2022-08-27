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

        public CustomResponse<PostDto> CreatePost(PostCreateDto request)
        {
            var newPost = _mapper.Map<Post>(request);
            _postRepository.CreatePost(newPost);

            var newPostDto = _mapper.Map<PostDto>(newPost);

            return CustomResponse<PostDto>.Success(newPostDto, 201);
        }

        public CustomResponse<List<PostDto>> GetPosts()
        {
            var posts = _postRepository.GetPosts();

            var postDtoList = _mapper.Map<List<PostDto>>(posts);

            return CustomResponse<List<PostDto>>.Success(postDtoList, 200);
        }

        public CustomResponse<List<PostDto>> GetPostsWithCategories()
        {
            var posts = _postRepository.GetPostsWithCategories();

            var postDtoList = _mapper.Map<List<PostDto>>(posts);

            return CustomResponse<List<PostDto>>.Success(postDtoList, 200);
        }
    }
}
