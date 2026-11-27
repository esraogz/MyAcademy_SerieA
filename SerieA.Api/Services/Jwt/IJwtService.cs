using SerieA.WebApi.Entities;

namespace SerieA.WebApi.Services.Jwt
{
    public interface IJwtService
    {
        Task<string> GenerateTokenAsync(AppUser user);
    }
}
