using ITalentBlogWebApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITalentBlogWebApp.Models.ViewModels
{
    public class PostCreateViewModel
    {
        
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public IFormFile Image { get; set; }

    }
}
