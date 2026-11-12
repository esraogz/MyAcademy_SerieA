using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SerieA.WebApi.DTOs.MatchEventItemDtos;
using SerieA.WebApi.Services.Events;
using System.Threading.Tasks;

namespace SerieA.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController(IEventService _eventService) : ControllerBase
    {
        [HttpPost("CreateEvent")]
        public async Task<IActionResult> CreateEvent(CreateMatchEventDto createMatchEventDto)
        {
            await _eventService.CreateEventAsync(createMatchEventDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id, string type)
        {
            await _eventService.DeleteEventAsync(id,type);
            return Ok();
        }
    }
}
