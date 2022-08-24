using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITalentBlogWebApp.Models.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Context { get; set; }
        public Post Post { get; set; }
        public int PostId { get; set; }
    }
}
