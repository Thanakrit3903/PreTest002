using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RegisterMember.Data;
using RegisterMember.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Tweetinvi.Core.Models;
using Microsoft.Extensions.Configuration;

namespace RegisterMember.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] Members request)
        {
            if (string.IsNullOrWhiteSpace(request.username) || string.IsNullOrWhiteSpace(request.passwordHash))
                return BadRequest("Username and password are required.");

            if (_context.members.Any(m => m.username == request.username))
                return Conflict("Username already exists.");

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.passwordHash);

            var user = new Members
            {
                username = request.username,
                passwordHash = passwordHash,
                createdAt = DateTime.UtcNow
            };

            _context.members.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Success" });
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(Members request)
        {
            var user = await _context.members.FirstOrDefaultAsync(u => u.username == request.username);
            if (user == null) return BadRequest("User not found.");

            if (!BCrypt.Net.BCrypt.Verify(request.passwordHash, user.passwordHash))
                return BadRequest("Wrong password.");

            string token = CreateToken(user);
            return Ok(token);
        }

        private string CreateToken(Members user)
        {
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.username) };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:Key").Value!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}