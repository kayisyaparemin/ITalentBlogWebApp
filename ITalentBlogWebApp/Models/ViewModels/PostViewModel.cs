using System.Text;

namespace ITalentBlogWebApp.Models.ViewModels
{
    public class PostViewModel
    {
        public PostViewModel()
        {
            Random r = new Random();

            modelId = GetRandomString(r, 10); 
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }

        public Category Category { get; set; }

        public string modelId { get; }

        public string CreatedDate { get; set; }

        public string GetRandomString(Random rnd, int length)
        {
            string charPool = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            StringBuilder rs = new StringBuilder();

            while (length > 0)
            {
                rs.Append(charPool[(int)(rnd.NextDouble() * charPool.Length)]);
                length--;
            }
            return rs.ToString();
        }
    }
}
