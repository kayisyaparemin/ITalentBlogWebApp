namespace ITalentBlogWebApp.Models.ViewModels
{
    public class PostIndexViewModel
    {
        public List<PostViewModel> Posts { get; set; }
        public string query { get; set; } = null;
        public string categoryName { get; set; } = null;

        public int totalPage { get; set; }

        public int page { get; set; } = 1;

        public int pageSize { get; } = 6;
    }
}
