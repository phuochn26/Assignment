using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EF2.Models
{
    public class DataContext : DbContext
    {
        public DataContext() { }
        public DataContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().Property(c => c.CategoryId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Category>().HasMany(c => c.Products).WithOne(p => p.Category);
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = 1,
                CategoryName = "Category1",
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 1,
                ProductName = "Category1",
                CategoryId = 1,
            });

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}