using BettingGameAPI.Models;
using DuszaTKVGameLib;
using DuszaTKVGameLib.DTOs.BetDTOs;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BettingGameAPI.Controllers
{
    [Route("BettingGame/[controller]")]
    [ApiController]
    public class BetController : ControllerBase
    {
        private readonly Repository<Bet> _betRepository;
        private readonly Repository<Game> _gameRepository;
        private readonly Repository<User> _userRepository;
        private readonly IValidator<CreateBetDto> _createValidator;
        private readonly IValidator<UpdateBetDto> _updateValidator;
        public BetController(IDataStore dataStore,
            IValidator<CreateBetDto> createValidator,
            IValidator<UpdateBetDto> updateValidator)
        {
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _betRepository = dataStore.Bets;
            _userRepository = dataStore.Users;
            _gameRepository = dataStore.Games;  
        }

        // GET api/<BetController>/5
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id)
        {
            var bet = _betRepository[id];
            if (bet == null)
                return NotFound();
            if (HttpContext.User.Identity is not ClaimsIdentity identity || !int.TryParse(identity.FindFirst(ClaimTypes.Sid)?.Value, out int userId))
                return BadRequest("Something went wrong.");
            if (userId != bet.UserId)
                return Forbid();
            return Ok(bet);
        }

        // POST api/<BetController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] CreateBetDto createDto)
        {
            if (HttpContext.User.Identity is not ClaimsIdentity identity || !int.TryParse(identity.FindFirst(ClaimTypes.Sid)?.Value, out int userId))
                return BadRequest("Something went wrong.");
            var game = _gameRepository[createDto.GameId];
            if (game == null)
                return BadRequest("Game with the given ID doesn't exist.");
            if (_userRepository[createDto.UserId] == null)
                return BadRequest("User with the given ID doesn't exist.");
            if (userId == game.OrganiserId || userId != createDto.UserId)
                return Forbid();

            var result = _createValidator.Validate(createDto);
            if (!result.IsValid)
                return BadRequest(result.Errors);

            var bet = new Bet(createDto.UserId, createDto.GameId, createDto.Result, createDto.Subject, createDto.EventId, createDto.Stake);
            _betRepository.Add(bet);
            return Ok(bet);
        }

        // PUT api/<BetController>/5
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromBody] UpdateBetDto updateDto)
        {
            var bet = _betRepository[id];
            if (bet == null)
                return NotFound();

            if (HttpContext.User.Identity is not ClaimsIdentity identity || !int.TryParse(identity.FindFirst(ClaimTypes.Sid)?.Value, out int userId))
                return BadRequest("Something went wrong.");
            if (userId != bet.UserId)
                return Forbid();

            var result = _updateValidator.Validate(updateDto);
            if (!result.IsValid)
                return BadRequest(result.Errors);

            bet.Stake = updateDto.Stake;
            bet.Result = updateDto.Result;
            bet.Subject = updateDto.Subject;
            _betRepository.Update(bet);
            return Ok(bet);
        }

        // DELETE api/<BetController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            var bet = _betRepository[id];
            if (bet == null)
                return NotFound();
            if (HttpContext.User.Identity is not ClaimsIdentity identity || !int.TryParse(identity.FindFirst(ClaimTypes.Sid)?.Value, out int userId))
                return BadRequest("Something went wrong.");
            if (userId != bet.UserId)
                return Forbid();

            _betRepository.Remove(bet);
            return NoContent();
        }
    }
}
