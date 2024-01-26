using ArtProducts.Models;
using Microsoft.EntityFrameworkCore;

namespace ArtProducts.Database
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base (options)
        {
            
        }
        public DbSet<ArtPiece> ArtPieces { get; set; }
    }
}
