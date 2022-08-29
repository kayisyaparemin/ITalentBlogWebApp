namespace ITalentBlog.Web.Models
{
    public class PostViewPageModel
    {
        public PostViewModel Post { get; set; }
        public PostViewModel NextPost { get; set; }
        public PostViewModel PreviousPost { get; set; }
    }
}
