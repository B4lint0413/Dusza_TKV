using BettingGameAPI.Models;
using DuszaTKVGameLib;
using DuszaTKVGameLib.DTOs.EventDTOs;
using DuszaTKVGameLib.DTOs.UserDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop.Infrastructure;
using System.Security.Claims;

namespace BettingGameAPI.Controllers
{
    [Route("BettingGame/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly Repository<Event> _eventRepository;
        private readonly Repository<Game> _gameRepository;

        public EventController(IDataStore dataStore)
        {
            _gameRepository = dataStore.Games;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAll() => Ok(_eventRepository.Values);

        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Event? byId = _eventRepository[id];
            if (byId != null)
                return Ok(byId);
            return NotFound();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] CreateEventDto dto)
        {
            if (HttpContext.User.Identity is not ClaimsIdentity identity)
                return BadRequest("Something went wrong.");
            var game = _gameRepository[dto.GameId];
            if (game == null) return BadRequest("Game doesn't exist");
            if (!int.TryParse(identity.FindFirst(ClaimTypes.Sid)?.Value, out int userId)
                || userId != game.OrganiserId)
                return Forbid();

            try
            {
                Event newEvent = new Event(dto.Name, dto.Subject, dto.GameId);
                _eventRepository.Add(newEvent);
                return Ok(newEvent);
            }catch(Exception ex) { return BadRequest(ex.Message); }
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateEventDto dto)
        {
            Event? byId = _eventRepository[id];
            if (byId == null)
                return NotFound();

            if (HttpContext.User.Identity is not ClaimsIdentity identity)
                return BadRequest("Something went wrong.");
            if (!int.TryParse(identity.FindFirst(ClaimTypes.Sid)?.Value, out int userId)
                || userId != byId.Game.OrganiserId)
                return Forbid();

            byId.Result = dto.Result;
            _eventRepository.Update(byId);
            return Ok(byId);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Event? byId = _eventRepository[id];
            if (byId == null)
                return NotFound();

            if (HttpContext.User.Identity is not ClaimsIdentity identity)
                return BadRequest("Something went wrong.");
            if (!int.TryParse(identity.FindFirst(ClaimTypes.Sid)?.Value, out int userId)
                || userId != byId.Game.OrganiserId)
                return Forbid();

            _eventRepository.Remove(byId);
            return NoContent();
        }
    }
}
