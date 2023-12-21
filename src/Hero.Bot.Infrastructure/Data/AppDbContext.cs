using Hero.Bot.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hero.Bot.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.SetTableName(entity.DisplayName());
            }
        }

        public DbSet<User> Users { get; set; } = null!;
    }
}
