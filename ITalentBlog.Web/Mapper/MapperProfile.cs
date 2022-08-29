using AutoMapper;
using ITalentBlog.Web.Models;

namespace ITalentBlog.Web.Mapper
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<PostUpdateViewModel, PostViewModel>().ReverseMap();
        }
    }
}
