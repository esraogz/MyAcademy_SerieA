using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SerieA.WebUI.Areas.Admin.Models;
using SerieA.WebUI.DTOs.TeamDtos;
using SerieA.WebUI.Services;
using SerieA.WebUI.Services.TeamServices;
using System.Configuration;

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
            var model = await _teamViewModelService.BuildListViewModelAsync();
            var apiError = await _teamService.CreateTeamAsync(createTeamDto);
            if (apiError != null)
            {
                ViewBag.ApiError = apiError;
                ViewBag.OpenCreateModal = true;
                
                return View("ListTeam", model);
            }
            return RedirectToAction(nameof(ListTeam));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTeam(UpdateTeamDto updateTeamDto)
        {
            var apiError = await _teamService.UpdateTeamAsync(updateTeamDto);
            var model = await _teamViewModelService.BuildListViewModelAsync();
            if (apiError != null)
            {
                ViewBag.ApiError = apiError;
                ViewBag.OpenCreateModal = true;
                
                return View("ListTeam", model); //RedirectToAction dersek viewbag ile taşıdığımız tüm veriler silinir o yüzden return view dedik.
            }
            return RedirectToAction(nameof(ListTeam));
        }

        public async Task<IActionResult> DeleteTeam(int id)
        {
            var apiError = await _teamService.DeleteTeamAsync(id);
            if (apiError != null)
            {
                TempData["DeleteError"] = apiError; // Sayfa yenilenirken hatayı taşır
            }
            return RedirectToAction(nameof(ListTeam));
        }
    }
}
