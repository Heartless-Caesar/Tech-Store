using Microsoft.AspNetCore.Mvc;
using TechDistributor.Data;

namespace TechDistributor.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly AppDbContext _context;

    public UserController(AppDbContext context)
    {
        _context = context;
    }
    
    
}