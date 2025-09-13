// imports Entity Framework Core functionality needed for database operations.
using Microsoft.EntityFrameworkCore;
namespace MyShop.Models;


//This class represents the database context used by Entity Framework Core.
public class ItemDbContext : DbContext
{
    // Constructor that accepts DbContextOptions to configure the context.
    public ItemDbContext(DbContextOptions<ItemDbContext> options)
        : base(options)
    {
        // creates an empty database in case it does not exist
        Database.EnsureCreated();
    }

    public DbSet<Item> Items { get; set; }
}