namespace ITalentBlogWebApp.Models.ViewModels.Posts
{
    public class PostIndexViewModel
    {
        public List<PostViewModel> Posts { get; set; }
        public string query { get; set; } = null;

        public int totalPage { get; set; }

        public int page { get; set; } = 1;

        public int pageSize { get; } = 6;
    }
}
