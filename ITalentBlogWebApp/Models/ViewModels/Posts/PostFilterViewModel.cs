namespace ITalentBlogWebApp.Models.ViewModels.Posts
{
    public class PostFilterViewModel
    {
        public string categoryName { get; set; }
        public string query { get; set; }
        public int page { get; set; }
        public int pageSize { get; set; }

    }
}
