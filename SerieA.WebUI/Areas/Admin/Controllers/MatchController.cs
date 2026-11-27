using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SerieA.WebUI.DTOs.MatchDtos;
using SerieA.WebUI.Extensions;
using SerieA.WebUI.Services.Matches;
using SerieA.WebUI.Services.TeamServices;
using System.Threading.Tasks;

namespace SerieA.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Editor")]
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
            var result = await _matchService.CreateMatchAsync(createMatchDto);
            if(!result.IsSuccess)
            {
                ModelState.Clear();
                ModelState.AddApiErrors(result);
                ViewBag.OpenCreateModal = true;
                return await ReturnListWithErrorsAsync();
            }
            return RedirectToAction(nameof(ListMatch));
        }

        public async Task<IActionResult> DeleteMatch(int id)
        {
            var result = await _matchService.DeleteMatchAsync(id);
            if (!result.IsSuccess)
            {
                TempData["DeleteError"] = result.Message; 
            }
            return RedirectToAction(nameof(ListMatch));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMatch(UpdateMatchDto updateMatchDto)
        {
            var result = await _matchService.UpdateMatchAsync(updateMatchDto);
            if (!result.IsSuccess)
            {
                ModelState.Clear();
                ModelState.AddApiErrors(result);
                ViewBag.OpenUpdateModal = true;
                return await ReturnListWithErrorsAsync();
            }
            return RedirectToAction(nameof(ListMatch));
        }

        
        public async Task<IActionResult> GetMatchesByWeek(int week = 11)
        {
            ViewBag.Week = week;
            var result = await _matchService.GetMatchesByWeekAsync(week);
            return View(result);
        }



        private async Task<IActionResult> ReturnListWithErrorsAsync()
        {
            var matches = await _matchService.GetAllMatchesAsync();
            var teams = await _teamService.GetAllTeamsAsync();
            ViewBag.Teams = teams.Where(x => x.IsActive).ToList();
            return View("ListMatch", matches);
        }

    }
}
