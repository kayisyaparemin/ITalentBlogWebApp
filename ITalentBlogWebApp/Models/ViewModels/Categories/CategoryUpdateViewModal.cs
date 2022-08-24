using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ITalentBlogWebApp.Models.ViewModels.Categories
{
    public class CategoryUpdateViewModal
    {
        public int Id { get; set; }
        [Remote(action: "AnyCategoryName", controller: "Admin")]
        [Required]
        public string Name { get; set; }
    }
}
