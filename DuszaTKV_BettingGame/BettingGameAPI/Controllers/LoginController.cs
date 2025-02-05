using BettingGameAPI.Models;
using BettingGameAPI.Options;
using DuszaTKVGameLib;
using DuszaTKVGameLib.DTOs.UserDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.CodeDom;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BettingGameAPI.Controllers
{
    [AllowAnonymous]
    [Route("BettingGame/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly Repository<User> _userRepository;
        private readonly JwtOptions jwtOptions;
        public LoginController(IDataStore dataStore, IOptions<JwtOptions> options)
        {
            _userRepository = dataStore.Users;
            jwtOptions = options.Value;
        }

        [HttpPost]
        public IActionResult Login([FromBody] CreateUserDto user)
        {
            User? byName = _userRepository.Values.FirstOrDefault(u => u.Name == user.Name);
            if (byName == null)
                return BadRequest("Invalid username or password");
            try
            {
                User login = new User(user.Name, user.Password);
                if (byName.Password.HashedPassword != login.Password.HashedPassword)
                    return BadRequest("Invalid username or password");
            }catch { return BadRequest("Invalid username or password"); }

            string role = byName.Name == "administrator" ? "Admin" : "User";
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Key));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.Sid, byName.Id.ToString()),
                new Claim(ClaimTypes.NameIdentifier, byName.Name),
                new Claim(ClaimTypes.Role, role)
            };

            var token = new JwtSecurityToken(
                jwtOptions.Issuer,
                jwtOptions.Audience,
                claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
            );
            var tokenStr = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(new{Id = byName.Id, Token = tokenStr});
        }
    }
}
