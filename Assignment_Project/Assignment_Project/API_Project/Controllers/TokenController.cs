using API_Project.DataTransferObjects;
using API_Project.Domain;
using API_Project.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly ProjectDbContext _context;

        public TokenController(IConfiguration config, ProjectDbContext context)
        {
            _configuration = config;
            _context = context;
        }

        [HttpPost("Post")]
        public async Task<IActionResult> Post(LoginDTO value)
        {
            if (value.Email != null && value.password != null)
            {
                var user = await GetUser(value.Email,value.password);

                if (user != null)
                {
                    var claims = new[] { 
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserName", user.UserName),
                        new Claim("Email", user.Email)
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else 
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet]
        private async Task<UserInfo> GetUser(string email, string password)
        {
            return await _context.UserInfos.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }
    }
}
