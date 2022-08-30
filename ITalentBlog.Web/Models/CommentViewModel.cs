namespace ITalentBlog.Web.Models
{
    public class CommentViewModel
    {
        public int PostId { get; set; }

        public string Name { get; set; }
        public string Message { get; set; }

        public string CreatedDate { get; set; }
    }
}
