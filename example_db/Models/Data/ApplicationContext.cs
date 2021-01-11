using Microsoft.EntityFrameworkCore;

namespace example_db.Models.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {}
    }
}