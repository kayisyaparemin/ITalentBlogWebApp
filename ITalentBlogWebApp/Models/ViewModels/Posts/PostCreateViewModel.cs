using ITalentBlogWebApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;
using System.Web.Mvc;
using RemoteAttribute = Microsoft.AspNetCore.Mvc.RemoteAttribute;

namespace ITalentBlogWebApp.Models.ViewModels.Posts
{

    public class PostCreateViewModel
    {
        public PostCreateViewModel()
        {
            CreatedDate = DateTime.Now.ToShortDateString() + "-" + DateTime.Now.ToShortTimeString();
        }
        [Remote(action: "AnyPostTitle", controller: "post")]
        public string Title { get; set; }

        [Required, MinLength(100)]
        public string Description { get; set; }
        [Required]
        public IFormFile Image { get; set; }

        public int CategoryId { get; set; }

        public string CreatedDate { get; }

    }
}
