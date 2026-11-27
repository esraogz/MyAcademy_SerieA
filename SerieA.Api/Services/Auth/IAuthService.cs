using SerieA.WebApi.DTOs.LoginDtos;

namespace SerieA.WebApi.Services.Auth
{
    public interface IAuthService
    {
        Task<TokenResponseDto> Login(LoginDto loginDto);
    }
}
