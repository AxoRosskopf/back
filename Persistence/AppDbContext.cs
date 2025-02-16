using Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Item> Items { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Item>()
                .HasKey(i => i.Id);

            modelBuilder.Entity<Item>()
                .Property(i => i.Name)
                .IsRequired();

            modelBuilder.Entity<Item>()
                .Property(i => i.Description)
                .IsRequired();

            modelBuilder.Entity<Item>()
                .Property(i => i.Status)
                .IsRequired();

            modelBuilder.Entity<Item>()
                .Property(i => i.Stock)
                .IsRequired();

            modelBuilder.Entity<Item>()
                .Property(i => i.Image)
                .IsRequired();

            modelBuilder.Entity<Item>()
                .Property(i => i.CreatedAt)
                .IsRequired();

            modelBuilder.Entity<Item>()
                .Property(i => i.UpdatedAt)
                .IsRequired();
        }

    }
}
