using basket.Entities;
using Microsoft.EntityFrameworkCore;

namespace basket.Repository
{
    public class BasketDbContext : DbContext
    {
        public BasketDbContext(DbContextOptions<BasketDbContext> options) :base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Basket> Baskets { get; set; }

        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1,  Price = 0.80M, Quantity = 1, Description = "Butter" },
                new Product { Id = 2,  Price = 1.15M, Quantity = 1, Description = "Milk" },
                new Product { Id = 3,  Price = 1M, Quantity = 1, Description = "Bread" }
                );
        }
    }
}
