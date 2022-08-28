using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITalentBlog.Core.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public Post Post { get; set; }
        public int PostId { get; set; }
        public string CreatedDate { get; init; } = DateTime.Now.ToString();


    }
}
