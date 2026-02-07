using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Backend.Models.Tasks> Tasks { get; set; }
        public DbSet<Backend.Models.Users> Users { get; set; }
    }
}
