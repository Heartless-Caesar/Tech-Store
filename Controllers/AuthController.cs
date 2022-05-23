using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    
    [HttpPost("api/register")]
    public async Task<ActionResult<User>> UserRegister(User obj)
    {
        _context.users.Add(obj);
        await _context.SaveChangesAsync();
        return Ok("User created");
    }
    
    [HttpPost("api/login")]
    [AllowAnonymous]
    public async Task<ActionResult<UserLogin>> UserLogin([FromBody]UserLogin obj)
    {
         
        
        return Ok();
    }

    public Task<User?> Authenticate(UserLogin obj)
    {
        var currentUser = _context.users.FirstOrDefaultAsync(o => o.Username.ToLower() == obj.username.ToLower() 
                                                                   && o.Password == obj.password);
        
        if (currentUser == null) return null;

        return currentUser;
    }
}