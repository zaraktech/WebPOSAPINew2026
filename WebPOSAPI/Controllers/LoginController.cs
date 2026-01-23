using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebAPI.Models;
using WebAPI.ViewModels;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly AppDBContext _context;
        private readonly IConfiguration _config;
        private readonly ILogger<LoginController> _logger;

        public LoginController(AppDBContext context, IConfiguration config, ILogger<LoginController> logger)
        {
            _context = context;
            _config = config;
            _logger = logger;
        }

        [HttpPost]


        public async Task<IActionResult> Login([FromBody] LoginViewModel login)
        {
            if (login == null)
                return BadRequest("Invalid client request");

            var user = await _context.UserLogins
                .Include(u => u.Role)
                .FirstOrDefaultAsync(x => x.Username == login.Username && x.Password == login.Password);

            if (user == null)
            {
                return Unauthorized("Invalid username or password");
            }

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:SecretKey"]));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role.RoleName)
            };

            var tokenOptions = new JwtSecurityToken(
     issuer: _config["JwtSettings:Issuer"],
     audience: _config["JwtSettings:Audience"],
     claims: claims,
     expires: DateTime.UtcNow.AddHours(2), // <- Use UtcNow
     signingCredentials: signinCredentials
 );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return Ok(new
            {
                Token = tokenString,
                user.Username,
                Role = user.Role.RoleName
            });
        }
    }
}
