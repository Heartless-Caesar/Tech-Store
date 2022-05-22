using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TechDistributor.Data;
using TechDistributor.Models;

namespace TechDistributor.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;

    public AuthController(AppDbContext context)
    {
        _context = context;
    }
    
    [HttpPost("register")]
    public async Task<ActionResult<User>> UserRegister(UserTO obj)
    {
        
        return Ok();
    }
}