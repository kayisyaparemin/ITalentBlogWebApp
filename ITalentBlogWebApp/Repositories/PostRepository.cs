using ITalentBlogWebApp.Models;

namespace ITalentBlogWebApp.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly AppDbContext _context;

        public PostRepository(AppDbContext context)
        {
            _context = context;
        }
        public void AddPicture(Picture picture)
        {
            _context.Pictures.Add(picture);
            _context.SaveChanges();
        }

        public void DeletePicture(int id)
        {
            var picture = _context.Pictures.Find(id);
            _context.Pictures.Remove(picture);
            _context.SaveChanges();
        }

        public List<Picture> GetPictures()
        {
            return _context.Pictures.ToList();
        }
    }
}
