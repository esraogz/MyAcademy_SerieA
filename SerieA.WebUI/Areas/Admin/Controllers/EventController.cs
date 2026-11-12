using Microsoft.AspNetCore.Mvc;
using SerieA.WebUI.DTOs.MatchEventItemDtos;
using SerieA.WebUI.Services.Events;
using System.Threading.Tasks;

namespace SerieA.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EventController(IEventService _eventService) : Controller
    {
        public async Task<IActionResult> CreateEvent(CreateMatchEventDto createMatchEventDto)
        {
             var apiError = await _eventService.CreateEventAsync(createMatchEventDto);
            if (apiError != null)
            {
                TempData["CreateEventError"] = apiError;
            }
            return RedirectToAction("MatchDetail", "MatchDetail", new { id = createMatchEventDto.MatchId });
        }

        public async Task<IActionResult> DeleteEvent(int id, string type, int matchId)
        {
            await _eventService.DeleteEventAsync(id, type);
            return RedirectToAction("MatchDetail", "MatchDetail", new { id = matchId });
        }
    }
}
