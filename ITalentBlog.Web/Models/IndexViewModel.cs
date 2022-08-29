namespace ITalentBlog.Web.Models
{
    public class IndexViewModel
    {
        public List<PostViewModel> Posts { get; set; }

        public int TotalPage { get; set; }

        public int Page { get; set; }

        public List<CategoryViewModel> Categories { get; set; }


    }
}
