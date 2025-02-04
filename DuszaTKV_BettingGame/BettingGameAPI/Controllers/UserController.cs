using BettingGameAPI.Models;
using DuszaTKVGameLib;
using DuszaTKVGameLib.DTOs.UserDTOs;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public IActionResult GetAll() => Ok(_userRepository.Values);

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            User? byId = _userRepository[id];
            if (byId != null)
                return Ok(byId);
            return NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateUserDto dto)
        {
            User user = new User(dto.Name, dto.Password);
            _userRepository.Add(user);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateUserDto dto)
        {
            User? byId = _userRepository[id];
            if (byId == null)
                return NotFound();
            byId.Points = dto.Points;
            _userRepository.Update(byId);
            return Ok(byId);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            User? byId = _userRepository[id];
            if (byId == null)
                return NotFound();
            _userRepository.Remove(byId);
            return NoContent();
        }
    }
}
