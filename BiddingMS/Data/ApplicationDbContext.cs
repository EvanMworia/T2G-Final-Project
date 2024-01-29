using BiddingMS.Models;
using Microsoft.EntityFrameworkCore;

namespace BiddingMS.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<Bid> Bids { get; set; }
    }
}
