using System.ComponentModel.DataAnnotations;

namespace TechDistributor.Models;

public class User
{
    [Key]
    public int Id { get; set; }
    
    public string Username { get; set; } = string.Empty;
    
    public int Password { get; set; }

    public string Email { get; set; } = string.Empty;
}