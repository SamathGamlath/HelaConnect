using HelaConnect.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HelaConnect.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {
            
        }

        public DbSet<Post> Posts { get; set; }
    }
}
