using BettingGameAPI.Models;
using DuszaTKVGameLib;
using DuszaTKVGameLib.DTOs.EventDTOs;
using DuszaTKVGameLib.DTOs.UserDTOs;
using Microsoft.AspNetCore.Mvc;

namespace BettingGameAPI.Controllers
{
    [Route("BettingGame/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly Repository<Event> _eventRepository;

        public EventController(IDataStore dataStore)
        {
            _eventRepository = dataStore.Events;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_eventRepository.Values);

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Event? byId = _eventRepository[id];
            if (byId != null)
                return Ok(byId);
            return NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateEventDto dto)
        {
            Event newEvent = new Event(dto.Name, dto.Subject, dto.GameName);
            _eventRepository.Add(newEvent);
            return Ok(newEvent);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateEventDto dto)
        {
            Event? byId = _eventRepository[id];
            if (byId == null)
                return NotFound();
            byId.Result = dto.Result;
            _eventRepository.Update(byId);
            return Ok(byId);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Event? byId = _eventRepository[id];
            if (byId == null)
                return NotFound();
            _eventRepository.Remove(byId);
            return NoContent();
        }
    }
}
