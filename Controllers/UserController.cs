using System.Net;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechDistributor.Models;

namespace TechDistributor.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpGet("/Admin")]
    [Authorize(Roles = "Admin")]
    public IActionResult Admin()
    {
        var currentUser = GetCurrentUser();
        return Ok($"This is admin space,user {currentUser.Username} is recognized as {currentUser.Role}");
    }
    
    [HttpGet("/Public")]
    public IActionResult Public()
    {
        return Ok("This is public");
    }

    private User GetCurrentUser()
    {
        var identity = HttpContext.User.Identity as ClaimsIdentity;

        if (identity != null)
        {
            var userClaims = identity.Claims;

            return new User
            {
                Username = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
                Role = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Role)?.Value
            };
        }

        return null;
    }
}