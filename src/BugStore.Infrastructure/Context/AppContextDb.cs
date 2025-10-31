using BugStore.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BugStore.Infra.Context;
public class AppContextDb : DbContext
{
    public AppContextDb(DbContextOptions<AppContextDb> options) : base(options) { }    
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderLine> OrderLines { get; set; }
    public DbSet<Product> Products { get; set; }
      
}
