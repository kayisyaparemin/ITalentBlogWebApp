
using Newtonsoft.Json.Linq;

namespace ITalentBlog.Web.Models
{
    public class PostViewModel
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }

        public CategoryViewModel Category { get; set; }

        public string CreatedDate { get; set; }

        public List<CommentViewModel> Comments { get; set; }

        public CommentCreateViewModel Comment { get; set; }
    }
}
