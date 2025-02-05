using BettingGameAPI.Models;
using DuszaTKVGameLib;
using DuszaTKVGameLib.DTOs.UserDTOs;
using FluentValidation;
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
        private readonly IValidator<CreateUserDto> _validator;
        public UserController(IDataStore dataStore, IValidator<CreateUserDto> validator)
        {
            _userRepository = dataStore.Users;
            _validator = validator;
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
                var result = _validator.Validate(dto);
                if (!result.IsValid) return BadRequest(result);

                User user = new User(dto.Name, dto.Password);
                _userRepository.Add(user);
                return Ok(user);
            }catch(Exception ex) { return BadRequest(ex.Message); }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateUserDto dto)
        {
            User? byId = _userRepository[id];
            if (byId == null)
                return NotFound();
            byId.Points = dto.Points;
            _userRepository.Update(byId);
            return NoContent();
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
