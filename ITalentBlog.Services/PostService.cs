using AutoMapper;
using ITalentBlog.Core;
using ITalentBlog.Core.DTOs.Comment;
using ITalentBlog.Core.DTOs.Post;
using ITalentBlog.Core.Models;
using ITalentBlog.Core.Repositories;
using ITalentBlog.Core.Services;
using ITalentBlog.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ITalentBlog.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PostService(IPostRepository postRepository,IMapper mapper,IUnitOfWork unitOfWork)
        {
            _postRepository = postRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public CustomResponse<string> DeletePost(int id)
        {
            if (!_postRepository.Any(id))
            {
                return CustomResponse<string>.Fail($"Id'si {id} olan ürün bulunamamıştır", 404);

            }
            _postRepository.DeletePost(id);
            _unitOfWork.Commit();
            

            return CustomResponse<string>.Success(String.Empty, 204);
        }
        public CustomResponse<PostDto> CreatePost(PostCreateDto request)
        {
            var newPost = _mapper.Map<Post>(request);
            _postRepository.CreatePost(newPost);
            _unitOfWork.Commit();

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
            _unitOfWork.Commit();

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
            _unitOfWork.Commit();

            var newCommentDto = _mapper.Map<CreateCommentDto>(newComment);

            return CustomResponse<CreateCommentDto>.Success(newCommentDto, 201);
        }

        public CustomResponse<PostsPagedDto> GetPostsWithPaged(int page, int pageSize)
        {
            var (posts,totalCount) = _postRepository.GetPostsWithPaged(page, pageSize);

            var ListedPosts = _mapper.Map<List<PostDto>>(posts);

            int totalPage = (int)Math.Ceiling((decimal)totalCount / pageSize);

            var pagedPosts = new PostsPagedDto { ListedPosts = ListedPosts, totalPage = totalPage };

            return CustomResponse<PostsPagedDto>.Success(pagedPosts, 200);
        }

        public CustomResponse<bool> ExistsTitle(string Title)
        {
            var IsExısts = _postRepository.ExistsTitle(Title);

            return CustomResponse<bool>.Success(IsExısts, 200);
        }

        public CustomResponse<PostsPagedDto> GetPostsWithPagedFilteredByCategory(int page, int pageSize, string categoryName)
        {
            var (posts, totalCount) = _postRepository.GetPostsWithPagedFilteredByCategory(page, pageSize,categoryName);

            var ListedPosts = _mapper.Map<List<PostDto>>(posts);

            int totalPage = (int)Math.Ceiling((decimal)totalCount / pageSize);

            var pagedPosts = new PostsPagedDto { ListedPosts = ListedPosts, totalPage = totalPage };

            return CustomResponse<PostsPagedDto>.Success(pagedPosts, 200);
        }
    }
}
