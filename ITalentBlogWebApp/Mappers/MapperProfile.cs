using AutoMapper;
using ITalentBlogWebApp.Models.Entities;
using ITalentBlogWebApp.Models.ViewModels.Categories;
using ITalentBlogWebApp.Models.ViewModels.Contact;
using ITalentBlogWebApp.Models.ViewModels.Posts;
using static System.Net.Mime.MediaTypeNames;

namespace ITalentBlogWebApp.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<PostCreateViewModel, Post>().ReverseMap();
            CreateMap<PostViewModel,Post>().ReverseMap();
            CreateMap<PostUpdateViewModel, Post>().ReverseMap();
            CreateMap<ContactViewModel, Contact>().ReverseMap();
            CreateMap<CategoryViewModel, Category>().ReverseMap();
            CreateMap<CategoryCreateViewModel, Category>().ReverseMap();
            CreateMap<CategoryUpdateViewModal, Category>().ReverseMap();
        }
    }
}
