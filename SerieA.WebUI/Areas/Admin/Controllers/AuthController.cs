using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using SerieA.WebUI.DTOs.LoginDtos;
using SerieA.WebUI.Extensions;
using SerieA.WebUI.Services.Auth;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SerieA.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthController(IAuthService _authService) : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            if(User.Identity?.IsAuthenticated == true)
            {
                return RedirectToAction("Dashboard", "Dashboard");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var (result,tokenResponseDto) = await _authService.Login(loginDto);
            if (!result.IsSuccess || tokenResponseDto is null)
            {
                ModelState.Clear();
                ModelState.AddApiErrors(result);
                ViewBag.ApiError = result.Message;
                return View();
            }


            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(tokenResponseDto.Token);

            var claims = jwtToken.Claims.ToList();

            claims.Add(new Claim("Token", tokenResponseDto.Token));

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = tokenResponseDto.ExpireTime.ToUniversalTime()
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

            return RedirectToAction("Dashboard", "Dashboard");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Auth", new { area = "Admin" });
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
