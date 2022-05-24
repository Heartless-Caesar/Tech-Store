using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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

    private readonly IConfiguration _config;

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
        var user = Authenticate(obj);

        if (user != null)
        {
            var token = Generate(user);
            return Ok(token);
        }
        
        return Ok();
    }

    private User Authenticate(UserLogin obj)
    {
        var currentUser = _context.users.FirstOrDefault(o => o.Username.ToLower() == obj.username.ToLower() 
                                                                  && o.Password == obj.password);

        if (currentUser != null)
        {
            return currentUser;
        }

        return null;
    }

    private string Generate(User obj)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, obj.Username)
        };
        
        return "";
    }
}