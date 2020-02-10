using System.Threading.Tasks;
using Eonet.Services.Dtos;
using Eonet.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EONET_Back.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet("")]
        public async Task<IActionResult> Get([FromQuery] QueryOptions queryOptions)
        {
            var events = await _eventService.FindAsync(queryOptions);
            return Ok(events);
        }

        [HttpGet("{eventId}")]
        public async Task<IActionResult> Get(string eventId)
        {
            var eventDto = await _eventService.FindById(eventId);
            if (eventDto == null) return NotFound();
            return Ok(eventDto);
        }
    }
}
