using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ITalentBlog.Web.Models
{
    public class PostUpdateViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public string ImageName { get; set; }
        public int CategoryId { get; set; }
        public string CreatedDate { get; set; }
        public IFormFile Image { get; set; }
    }
}
