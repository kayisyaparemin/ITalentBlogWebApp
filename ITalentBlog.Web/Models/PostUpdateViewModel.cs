namespace ITalentBlog.Web.Models
{
    public class PostUpdateViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
        public int CategoryId { get; set; }
        public string CreatedDate { get; set; }
        public IFormFile Image { get; set; }
    }
}
