using ITalentBlogWebApp.Models;

namespace ITalentBlogWebApp.Repositories
{
    public interface IPostRepository
    {
        public List<Picture> GetPictures();

        public void AddPicture(Picture picture);

        public void DeletePicture(int id);
    }
}
