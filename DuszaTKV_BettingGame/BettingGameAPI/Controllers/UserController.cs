using BettingGameAPI.Models;
using DuszaTKVGameLib;
using DuszaTKVGameLib.DTOs.UserDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BettingGameAPI.Controllers
{
    [Route("BettingGame/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly Repository<User> _userRepository;

        public UserController(IDataStore dataStore)
        {
            _userRepository = dataStore.Users;
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (HttpContext.User.Identity is not ClaimsIdentity identity)
                return BadRequest("Something went wrong.");
            if (!int.TryParse(identity.FindFirst(ClaimTypes.Sid)?.Value, out int userId) || userId != id)
                return Forbid();

            User? byId = _userRepository[id];
            if (byId != null)
                return Ok(byId);
            return NotFound();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Post([FromBody] CreateUserDto dto)
        {
            try
            {
                User user = new User(dto.Name, dto.Password);
                _userRepository.Add(user);
                return Ok(user);
            }catch(Exception ex) { return BadRequest(ex.Message); }
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (HttpContext.User.Identity is not ClaimsIdentity identity)
                return BadRequest("Something went wrong.");
            if (!int.TryParse(identity.FindFirst(ClaimTypes.Sid)?.Value, out int userId) || userId != id)
                return Forbid();

            User? byId = _userRepository[id];
            if (byId == null)
                return NotFound();
            _userRepository.Remove(byId);
            return NoContent();
        }
    }
}
