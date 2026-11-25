using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SerieA.WebApi.DTOs.UserDtos;
using SerieA.WebApi.Services.Users;
using System.Threading.Tasks;

namespace SerieA.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUserService _userService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUserAsync();
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDto createUserDto)
        {
            await _userService.CreateUserAsync(createUserDto);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UpdateUserDto updateUserDto)
        {
            await _userService.UpdateUserAsync(updateUserDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUserAsync(id);
            return Ok();
        }

        [HttpGet("GetUser/{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            return Ok(user);
        }

        [HttpPut("ToggleUserStatus")]
        public async Task<IActionResult> ToggleUserStatus(int id)
        {
            await _userService.ToggleUserStatusAsync(id);
            return Ok();
        }

        [HttpGet("GetRoles")]
        public async Task<IActionResult> GetRoles()
        {
            var roles = await _userService.GetRolesAsync();
            return Ok(roles);
        }
    }
}
