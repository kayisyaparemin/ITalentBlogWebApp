using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITalentBlogWebApp.Models.ViewModels.Posts
{
    public class PostUpdateViewModel
    {
        public PostUpdateViewModel()
        {
            CreatedDate = DateTime.Now.ToShortDateString() + "-" + DateTime.Now.ToShortTimeString();
        }
        public int Id { get; set; }
        public string Title { get; set; }

        [Required, MinLength(100)]
        public string Description { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }

        public string ImageName { get; set; }

        public int CategoryId { get; set; }

        public string CreatedDate { get; }
    }
}
