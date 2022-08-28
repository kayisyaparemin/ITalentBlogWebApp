using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ITalentBlog.Web.Models
{
    public class CategoryCreateViewModel
    {
        [Remote(action:"AnyCategoryName",controller:"Category")]
        [Required]
        public string Name { get; set; }
    }
}
