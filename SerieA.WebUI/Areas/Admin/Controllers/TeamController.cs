using Microsoft.AspNetCore.Mvc;
using SerieA.WebUI.DTOs.TeamDtos;
using SerieA.WebUI.Extensions;
using SerieA.WebUI.Services;
using SerieA.WebUI.Services.TeamServices;

namespace SerieA.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeamController(ITeamService _teamService,
                                TeamViewModelService _teamViewModelService) : Controller
    {
        public async Task<IActionResult> ListTeam(string? search, string? region, string? status)
        {
            var model = await _teamViewModelService.BuildListViewModelAsync(search,region,status);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeam(CreateTeamDto createTeamDto)
        {
            
            var result = await _teamService.CreateTeamAsync(createTeamDto);
            if (!result.IsSuccess)
            {
                ModelState.Clear();
                ModelState.AddApiErrors(result);
                ViewBag.OpenCreateModal = true;
                return View("ListTeam", await _teamViewModelService.BuildListViewModelAsync());
            }
            return RedirectToAction(nameof(ListTeam));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTeam(UpdateTeamDto updateTeamDto)
        {
            var result = await _teamService.UpdateTeamAsync(updateTeamDto);
            
            if (!result.IsSuccess)
            {
                ModelState.Clear();
                ModelState.AddApiErrors(result);
                ViewBag.OpenUpdateModal = true;
                return View("ListTeam", await _teamViewModelService.BuildListViewModelAsync()); //RedirectToAction dersek viewbag ile taşıdığımız tüm veriler silinir o yüzden return view dedik.
            }
            return RedirectToAction(nameof(ListTeam));
        }

        public async Task<IActionResult> DeleteTeam(int id)
        {
            var result = await _teamService.DeleteTeamAsync(id);
            if (!result.IsSuccess)
            {
                TempData["DeleteError"] = result.Message; // Sayfa yenilenirken hatayı taşır
            }
            return RedirectToAction(nameof(ListTeam));
        }
    }
}
