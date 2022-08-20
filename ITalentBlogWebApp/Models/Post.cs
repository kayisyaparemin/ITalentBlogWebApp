using System.ComponentModel.DataAnnotations;

namespace ITalentBlogWebApp.Models
{
    public class Post
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
        
        public string ImageName { get; set; }

        public string CreatedDate => DateTime.Now.ToShortDateString() + "-" + DateTime.Now.ToShortTimeString();
    }
    }
