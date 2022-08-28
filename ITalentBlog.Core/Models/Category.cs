using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITalentBlog.Core.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CreatedDate { get; init; } = DateTime.Now.ToString();

        public ICollection<Post> Posts { get; set; }
    }
}
