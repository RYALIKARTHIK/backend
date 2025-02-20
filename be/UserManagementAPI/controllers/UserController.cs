using Microsoft.AspNetCore.Mvc;
using UserManagementAPI.Models;
using UserManagementAPI.Data;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly AppDbContext _context;

    public UserController(AppDbContext context)
    {
        _context = context;
    }

    // ✅ Test API
    [HttpGet("test")]
    public IActionResult TestApi()
    {
        return Ok(new { message = "Hello from API!" });
    }

    // ✅ API to accept user details and store in DB
    [HttpPost("add")]
    public async Task<IActionResult> AddUser([FromBody] User user)
    {
        if (user == null)
        {
            return BadRequest("User data is required.");
        }

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return Ok(new { message = "User added successfully!", user });
    }
}
