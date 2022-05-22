using System.ComponentModel.DataAnnotations;

namespace TechDistributor.Models;

public class Product
{
    [Key]
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;
    
    public string Description { get; set; } = string.Empty;
    
    public int Price { get; set; }
}