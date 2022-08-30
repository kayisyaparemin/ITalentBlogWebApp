using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITalentBlog.Core.DTOs.Comment
{
    public class CommentDto
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string Name { get; set; }

        public string Message { get; set; }

        public string CreatedDate { get; set; }
    }
}
