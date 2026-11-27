using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SerieA.WebUI.Services.MatchDetails;
using System.Threading.Tasks;

namespace SerieA.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Editor")]
    public class MatchDetailController(IMatchDetailService _matchDetailService) : Controller
    {
        public async Task<IActionResult> MatchDetail(int id)
        {
            var match = await _matchDetailService.GetMatchDetailByIdAsync(id);
            return View(match);
        }
    }
}
