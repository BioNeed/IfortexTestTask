using Microsoft.EntityFrameworkCore;
using TestTask.DataAccess.Database.Configurations;
using TestTask.DataAccess.Models;

namespace TestTask.DataAccess.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                assembly: GetType().Assembly,
                predicate: p => p.Namespace == typeof(UserConfiguration).Namespace);
        }
    }
}
