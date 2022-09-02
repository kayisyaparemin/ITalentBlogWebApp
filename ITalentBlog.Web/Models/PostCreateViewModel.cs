using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ITalentBlog.Web.Models
{
    public class PostCreateViewModel
    {
        [Remote(action:"AnyPostTitle",controller:"Post")]
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public string ImageName { get; set; }
        public int CategoryId { get; set; }
        public string CreatedDate { get; set; }
        [Required]
        [AllowedExtensions(new string[] { ".jpg", ".png",".jpeg" })]
        public IFormFile Image { get; set; }
    }
}
