using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SerieA.WebUI.DTOs.UserDtos;
using SerieA.WebUI.Extensions;
using SerieA.WebUI.Services.Users;
using System.Data;
using System.Threading.Tasks;

namespace SerieA.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserController(IUserService _userService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> ListUser(string? search, string? role, string? status)
        {
            var users = await _userService.GetAllUserAsync();
            ViewBag.Roles = await _userService.GetRolesAsync();

            ViewBag.CurrentSearch = search;
            ViewBag.CurrentRole = role;
            ViewBag.CurrentStatus = status;

            var query = users.AsQueryable();


            if (!string.IsNullOrEmpty(search))
            {
                var searchName = search.Trim().ToLower();
                query = query.Where(x => (x.FirstName + " " + x.LastName).Contains(searchName) || x.Email.ToLower().Contains(searchName));
            }

            if (!string.IsNullOrEmpty(role))
            {
                query = query.Where(x => x.Roles.Contains(role));
            }

            if (!string.IsNullOrEmpty(status))
            {
                if (status == "active")
                {
                    query = query.Where(x => x.IsActive);
                }
                else if (status == "inactive")
                {
                    query = query.Where(x => !x.IsActive);
                }
            }


            return View(query.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDto createUserDto)
        {
            var result = await _userService.CreateUserAsync(createUserDto);
            if (!result.IsSuccess)
            {
                ModelState.Clear();
                ModelState.AddApiErrors(result);
                ViewBag.OpenCreateModal = true;
                return await ReturnListWithErrorsAsync();
            }
            return RedirectToAction(nameof(ListUser));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser(UpdateUserDto updateUserDto)
        {
            var result = await _userService.UpdateUserAsync(updateUserDto);
            if (!result.IsSuccess)
            {
                ModelState.Clear();
                ModelState.AddApiErrors(result);
                ViewBag.OpenUpdateModal = true;
                return await ReturnListWithErrorsAsync();
            }
            return RedirectToAction(nameof(ListUser));
        }


        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _userService.DeleteUserAsync(id);
            if (!result.IsSuccess)
            {
                TempData["DeleteError"] = result.Message;
            }
            return RedirectToAction(nameof(ListUser));
        }

        private async Task<IActionResult> ReturnListWithErrorsAsync()
        {
            var users = await _userService.GetAllUserAsync();
            ViewBag.Roles = await _userService.GetRolesAsync();
            return View("ListUser", users);
        }
    }
}
