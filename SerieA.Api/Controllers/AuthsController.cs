using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SerieA.WebApi.DTOs.LoginDtos;
using SerieA.WebApi.Services.Auth;
using System.Threading.Tasks;

namespace SerieA.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController(IAuthService _authService) : ControllerBase
    {
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var result = await _authService.Login(loginDto);
            return Ok(result);
        }
    }
}
