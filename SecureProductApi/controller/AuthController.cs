using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SecureProductApi.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SecureProductApi.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;

        public AuthController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequestDto dto)
        {
            // Demo validation (replace with DB later)
            if (dto.Username != "student" || dto.Password != "test")
                return Unauthorized();

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, "student"),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["JwtKey"]));

            var token = new JwtSecurityToken(
                issuer: "SecureApi",
                audience: "SecureApiUsers",
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials:
                    new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
    }
}
