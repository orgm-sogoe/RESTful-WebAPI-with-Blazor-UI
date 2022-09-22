using Microsoft.EntityFrameworkCore;
using ShopProduct.Api.Entities;

namespace ShopProduct.Api.Data
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> opt) : base(opt)
        {

        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 1,
                Name = "White Puma Sneakers",
                Description = "White Puma Sneakers - Blue durable trainers provided by Puma",
                Price = 500,
                Quantity = 100,
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 2,
                Name = "Blue Nike Trainers",
                Description = "Blue Nike Trainers - Blue durable trainers provided by Nike",
                Price = 200,
                Quantity = 110,
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 3,
                Name = "Birkenstock Sandals",
                Description = "Birkenstock Sandals - Leather sandals available in different colours and sizes",
                Price = 50,
                Quantity = 90,
            });
        }
    }
}
