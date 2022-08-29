namespace ITalentBlog.Web.Models
{
    public class PostPagedViewModel
    {
        public List<PostViewModel> ListedPosts { get; set; }
        public int totalPage { get; set; }
    }
}
