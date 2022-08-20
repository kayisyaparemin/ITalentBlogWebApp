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
        }
    }
}
