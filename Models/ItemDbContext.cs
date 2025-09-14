// imports Entity Framework Core functionality needed for database operations.
using Microsoft.EntityFrameworkCore;

namespace MyShop.Models;

//This class represents the database context used by Entity Framework Core.
public class ItemDbContext : DbContext
{
    // Constructor that accepts DbContextOptions to configure the context.
    public ItemDbContext(DbContextOptions<ItemDbContext> options) : base(options)
    {
        // creates an empty database in case it does not exist
        // Database.EnsureCreated();
    }

    public DbSet<Item> Items { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
    }

}