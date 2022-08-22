using AutoMapper;
using ITalentBlogWebApp.Models;
using ITalentBlogWebApp.Models.ViewModels;
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
        }
    }
}
