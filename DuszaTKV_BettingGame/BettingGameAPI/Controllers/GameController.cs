using BettingGameAPI.Models;
using DuszaTKVGameLib;
using DuszaTKVGameLib.DTOs.GameDTOs;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BettingGameAPI.Controllers
{
    [Route("BettingGame/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly Repository<Game> _gameRepository;
        private readonly IValidator<CreateGameDto> _createValidator;
        private readonly IValidator<UpdateGameDto> _updateValidator;
        public GameController(IDataStore dataStore, 
            IValidator<CreateGameDto> createValidator,
            IValidator<UpdateGameDto> updateValidator) 
        {
            _gameRepository = dataStore.Games;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }
        // GET: api/<GameController>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get() => Ok(_gameRepository.Values);

        // GET api/<GameController>/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult Get(int id)
        {
            var game = _gameRepository[id];
            if (game == null)
                return NotFound();
            return Ok(game);
        }

        // POST api/<GameController>
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post([FromBody] CreateGameDto createDto)
        {
            if (HttpContext.User.Identity is not ClaimsIdentity identity || !int.TryParse(identity.FindFirst(ClaimTypes.Sid)?.Value, out int userId))
                return BadRequest("Something went wrong.");

            var result = _createValidator.Validate(createDto);
            if (!result.IsValid)
                return BadRequest(result.Errors);

            var game = new Game(createDto.Name, userId);
            _gameRepository.Add(game);
            return Ok(game);
        }

        // PUT api/<GameController>/5
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromBody] UpdateGameDto updateDto)
        {
            var game = _gameRepository[id];
            if (game == null)
                return NotFound();
            if (HttpContext.User.Identity is not ClaimsIdentity identity || !int.TryParse(identity.FindFirst(ClaimTypes.Sid)?.Value, out int userId))
                return BadRequest("Something went wrong.");
            if (game.OrganiserId != userId)
                return Forbid();

            var result = _updateValidator.Validate(updateDto);
            if (!result.IsValid)
                return BadRequest(result.Errors);

            game.Name = updateDto.Name;
            _gameRepository.Update(game);
            return Ok(game);
        }

        // DELETE api/<GameController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            var game = _gameRepository[id];
            if (game == null)
                return NotFound();
            if (HttpContext.User.Identity is not ClaimsIdentity identity || !int.TryParse(identity.FindFirst(ClaimTypes.Sid)?.Value, out int userId))
                return BadRequest("Something went wrong.");
            if (game.OrganiserId != userId)
                return Forbid();
            _gameRepository.Remove(game);
            return NoContent();
        }
    }
}
