using Microsoft.EntityFrameworkCore;
using WebTool.Core.Entities;

namespace WebTool.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(NorthwindDbContext).Assembly);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }

    }
}
