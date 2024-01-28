using ArtHouses_Cartegory_.Models;
using Microsoft.EntityFrameworkCore;

namespace ArtHouses_Cartegory_.Database
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }
    }
}
