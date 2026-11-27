using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SerieA.WebApi.Entities;
using SerieA.WebApi.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SerieA.WebApi.Services.Jwt
{
    public class JwtService(UserManager<AppUser> _userManager,
                            IOptions<JwtOptions> _jwtOptions) : IJwtService
         
    {
        
        public async Task<string> GenerateTokenAsync(AppUser user)
        {
            var jwtOptions = _jwtOptions.Value;
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email ?? ""),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}")
            };

            var roles = await _userManager.GetRolesAsync(user);
            foreach(var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            SymmetricSecurityKey symmetricSecurityKey = new(Encoding.UTF8.GetBytes(jwtOptions.Key));

            JwtSecurityToken jwtSecurityToken = new(
                issuer: jwtOptions.Issuer,
                audience: jwtOptions.Audience,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(jwtOptions.ExpireInMinutes),
                signingCredentials: new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256)
               );

            var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            return token;

        }
    }
}
