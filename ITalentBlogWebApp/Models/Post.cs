using System.ComponentModel.DataAnnotations;

namespace ITalentBlogWebApp.Models
{
    public class Post
    {
        public int Id { get; set; }

        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public string ImageName { get; set; }

        public string CreatedDate { get; set; }

        public Category Category { get; set; }

        public int CategoryId { get; set; }
    }
    }
