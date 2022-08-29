using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITalentBlog.Core.DTOs.Post
{
    public class PostsPagedDto
    {
        public List<PostDto> ListedPosts { get; set; }
        public int totalPage { get; set; }
    }
}
