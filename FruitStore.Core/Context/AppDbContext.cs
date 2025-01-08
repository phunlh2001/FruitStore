using FruitStore.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FruitStore.Core.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=LAPTOP-U05H9B6R\\SQLEXPRESS;database=LM_FruitStore;uid=sa;pwd=123123;Encrypt=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>(b =>
            {
                b.Property(p => p.Name).HasMaxLength(100).IsRequired();
                b.Property(p => p.Description).HasMaxLength(1000).IsRequired();
                b.Property(p => p.Price).HasPrecision(18, 0).IsRequired();
            });

            builder.Entity<Category>(b =>
            {
                b.Property(c => c.Name).HasMaxLength(100).IsRequired();
            });

            builder.Entity<Product>()
                .HasOne(c => c.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.CategoryId);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
