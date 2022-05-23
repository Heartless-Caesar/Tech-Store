using Microsoft.EntityFrameworkCore;
using TechDistributor.Models;

namespace TechDistributor.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {} 
    
    public DbSet<User> users { get; set; }
    
    public DbSet<Product> products { get; set; }
    
}