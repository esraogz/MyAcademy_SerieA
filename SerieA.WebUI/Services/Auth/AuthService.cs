using SerieA.WebUI.DTOs.LoginDtos;
using SerieA.WebUI.DTOs.Results;
using SerieA.WebUI.Extensions;

namespace SerieA.WebUI.Services.Auth
{
    public class AuthService(HttpClient _client) : IAuthService
    {
        public async Task<(ApiResult Result, TokenResponseDto? Token)> Login(LoginDto loginDto)
        {
            var response = await _client.PostAsJsonAsync("Auths/Login", loginDto);
            var result = await response.ToApiResultAsync();
            if (!result.IsSuccess)
            {
                return (result, null);
            }

            var token = await response.Content.ReadFromJsonAsync<TokenResponseDto>();
            return (result, token);
        }
    }
}
