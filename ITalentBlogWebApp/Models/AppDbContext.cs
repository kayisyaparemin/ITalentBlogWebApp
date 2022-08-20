using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace ITalentBlogWebApp.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Picture> Pictures { get; set; }
    }
}
