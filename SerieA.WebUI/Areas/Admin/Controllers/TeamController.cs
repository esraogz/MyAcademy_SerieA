using Microsoft.AspNetCore.Mvc;
using SerieA.WebUI.DTOs.TeamDtos;
using SerieA.WebUI.Services.TeamServices;

namespace SerieA.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeamController(ITeamService _teamService) : Controller
    {
        public async Task<IActionResult> ListTeam()
        {
            var teams = await _teamService.GetAllTeamsAsync();
            return View(teams);
        }

        [HttpGet]
        public IActionResult CreateTeamAsync()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateTeam(CreateTeamDto createTeamDto)
        {
            await _teamService.CreateTeamAsync(createTeamDto);
            return RedirectToAction(nameof(ListTeam));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTeam(int id)
        {
            var team = await _teamService.GetTeamByIdAsync(id);
            return View(team);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTeam(UpdateTeamDto updateTeamDto)
        {
            await _teamService.UpdateTeamAsync(updateTeamDto);
            return RedirectToAction(nameof(ListTeam));
        }

        public async Task<IActionResult> DeleteTeam(int id)
        {
            await _teamService.DeleteTeamAsync(id);
            return RedirectToAction(nameof(ListTeam));
        }

    }
}
