using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITalentBlog.Core.DTOs
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }

        public CategoryDto Category { get; set; }

        public string CreatedDate { get; set; }

        public List<CommentDto> Comments { get; set; } = new List<CommentDto>();
    }
}
