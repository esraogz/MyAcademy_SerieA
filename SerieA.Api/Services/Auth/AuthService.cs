using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using SerieA.WebApi.DTOs.LoginDtos;
using SerieA.WebApi.Entities;
using SerieA.WebApi.Exceptions;
using SerieA.WebApi.Options;
using SerieA.WebApi.Services.Jwt;
using SerieA.WebApi.Services.Users;

namespace SerieA.WebApi.Services.Auth
{
    public class AuthService(UserManager<AppUser> _userManager,
                             IJwtService _jwtService,
                             IOptions<JwtOptions> _jwtOptions) : IAuthService
    {
        private readonly JwtOptions _jwtOptions = _jwtOptions.Value;
        public async Task<TokenResponseDto> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if(user is null)
            {
                throw new NotFoundException("Böyle bir kullanıcı bulunamadı");
            }
            var result = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if(!result)
            {
                throw new BadRequestException("Kullanıcı adı/şifre hatalı");
            }
            if (user.IsActive == false)
            {
                throw new BadRequestException("Hesabınız pasif durumdadır. Lütfen yönetici ile iletişime geçin.");
            }

            var token = await _jwtService.GenerateTokenAsync(user);
            return new TokenResponseDto{Token = token,
                        ExpireTime = DateTime.UtcNow.AddMinutes(_jwtOptions.ExpireInMinutes)};
        }
    }
}
