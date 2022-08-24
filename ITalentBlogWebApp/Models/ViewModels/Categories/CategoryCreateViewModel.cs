using Microsoft.Build.Framework;
using ITalentBlogWebApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;
using System.Web.Mvc;
using RemoteAttribute = Microsoft.AspNetCore.Mvc.RemoteAttribute;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace ITalentBlogWebApp.Models.ViewModels.Categories
{
    public class CategoryCreateViewModel
    {
        [Remote(action:"AnyCategoryName",controller:"Admin")]
        [Required]
        public string Name { get; set; }
    }
}
