using InternetShop.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace InternetShop.Data.Context
{
    public class InternetShopDbContext : DbContext
    {
        public InternetShopDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
    }
}
