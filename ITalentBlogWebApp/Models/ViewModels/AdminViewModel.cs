using ITalentBlogWebApp.Models.Entities;
using ITalentBlogWebApp.Models.ViewModels.Categories;
using ITalentBlogWebApp.Models.ViewModels.Posts;

namespace ITalentBlogWebApp.Models.ViewModels
{
    public class AdminViewModel
    {
        public List<PostViewModel> Posts { get; set; }

        public List<CategoryViewModel> Categories { get; set; }
    }
}
