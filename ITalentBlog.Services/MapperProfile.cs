using AutoMapper;
using ITalentBlog.Core.DTOs.Category;
using ITalentBlog.Core.DTOs.Comment;
using ITalentBlog.Core.DTOs.Post;
using ITalentBlog.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITalentBlog.Services
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Post, PostDto>().ReverseMap();
            CreateMap<Post, PostCreateDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Post, PostUpdateDto>().ReverseMap();
            CreateMap<Category, CategoryCreateDto>().ReverseMap();
            CreateMap<Category, CategoryUpdateDto>().ReverseMap();
            CreateMap<Comment, CreateCommentDto>().ReverseMap();
            CreateMap<CommentDto, Comment>().ReverseMap();
        }
    }
}
