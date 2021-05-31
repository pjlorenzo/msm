using basket.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
