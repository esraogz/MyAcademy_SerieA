using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SerieA.WebUI.Services.Standings;
using System.Threading.Tasks;

namespace SerieA.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Editor")]
    public class StandingController(IStandingService _standingService) : Controller
    {
        public async Task<IActionResult> GetStanding()
        {
            var standing = await _standingService.GetAllStandingsAsync();
            return View(standing);
        }
    }
}
