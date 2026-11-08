using Microsoft.AspNetCore.Mvc;
using SerieA.WebUI.DTOs.MatchDtos;
using SerieA.WebUI.Services.Matches;
using SerieA.WebUI.Services.TeamServices;
using System.Threading.Tasks;

namespace SerieA.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MatchController(IMatchService _matchService,
                                 ITeamService _teamService) : Controller
    {
        public async Task<IActionResult> ListMatch()
        {
            var matches = await _matchService.GetAllMatchesAsync();
            var teams = await _teamService.GetAllTeamsAsync();
            ViewBag.Teams = teams.Where(x =>x.IsActive).ToList();
            return View(matches);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMatch(CreateMatchDto createMatchDto)
        {
            var apiError = await _matchService.CreateMatchAsync(createMatchDto);
            if (apiError != null)
            {
                TempData["CreateMatchError"] = apiError;
            }
            return RedirectToAction(nameof(ListMatch));
        }

        public async Task<IActionResult> DeleteMatch(int id)
        {
            await _matchService.DeleteMatchAsync(id);
            return RedirectToAction(nameof(ListMatch));
        }

        public async Task<IActionResult> UpdateMatch(UpdateMatchDto updateMatchDto)
        {
            var apiError = await _matchService.UpdateMatchAsync(updateMatchDto);
            if (apiError != null)
            {
                TempData["UpdateMatchError"] = apiError;
                TempData["UpdateMatchId"] = updateMatchDto.MatchId;
            }
            return RedirectToAction(nameof(ListMatch));
        }

    }
}
