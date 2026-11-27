using SerieA.WebUI.DTOs.LoginDtos;
using SerieA.WebUI.DTOs.Results;

namespace SerieA.WebUI.Services.Auth
{
    public interface IAuthService
    {
        Task<(ApiResult Result, TokenResponseDto? Token)> Login(LoginDto loginDto);
    }
}
