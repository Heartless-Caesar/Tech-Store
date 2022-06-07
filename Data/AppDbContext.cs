using Microsoft.EntityFrameworkCore;
using TechDistributor.Models;

namespace TechDistributor.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {} 
    
    public DbSet<User> Users { get; set; } = null!;

    public DbSet<Product> Products { get; set; } = null!;
}