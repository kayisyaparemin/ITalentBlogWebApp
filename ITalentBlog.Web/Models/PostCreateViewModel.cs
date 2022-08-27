namespace ITalentBlog.Web.Models
{
    public class PostCreateViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
        public int CategoryId { get; set; }
        public string CreatedDate { get; set; }
    }
}
