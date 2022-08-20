namespace ITalentBlogWebApp.Models
{
    public class Picture
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

    }
}
