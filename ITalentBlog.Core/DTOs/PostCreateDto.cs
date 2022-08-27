using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITalentBlog.Core.DTOs
{
    public class PostCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
        public int CategoryId { get; set; }
        public string CreatedDate { get; set; }
    }
}
