namespace ITalentBlog.Web.Models
{
    public class CommentCreateViewModel
    {
       
        public int PostId { get; set; }

        public string Name { get; set; }

        public string Message { get; set; }
    }
}
