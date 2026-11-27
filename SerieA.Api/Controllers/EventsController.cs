using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SerieA.WebApi.DTOs.MatchEventItemDtos;
using SerieA.WebApi.Services.Events;

namespace SerieA.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,Editor")]
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
