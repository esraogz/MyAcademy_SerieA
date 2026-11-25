using SerieA.WebUI.DTOs.Results;
using SerieA.WebUI.DTOs.UserDtos;
using SerieA.WebUI.Extensions;
using System.Net.Http.Json;

namespace SerieA.WebUI.Services.Users
{
    public class UserService(HttpClient _client) : IUserService
    {
        public async Task<ApiResult> CreateUserAsync(CreateUserDto createUserDto)
        {
            var response = await _client.PostAsJsonAsync("Users", createUserDto);
            return await response.ToApiResultAsync();
        }

        public async Task<ApiResult> DeleteUserAsync(int id)
        {
            var response = await _client.DeleteAsync($"Users/{id}");
            return await response.ToApiResultAsync();
        }

        public async Task<List<ResultUserDto>> GetAllUserAsync()
        {
            return await _client.GetFromJsonAsync<List<ResultUserDto>>("Users");
        }

        public async Task<List<ResultRoleDto>> GetRolesAsync()
        {
            return await _client.GetFromJsonAsync<List<ResultRoleDto>>("Users/GetRoles");
        }

        public async Task<ResultUserDto> GetUserByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<ResultUserDto>($"Users/GetUser/{id}");
        }

        public async Task<ApiResult> ToggleUserStatusAsync(int userId)
        {
            var response = await _client.PutAsync($"Users/ToggleUserStatus?id={userId}", null);
            return await response.ToApiResultAsync();
        }

        public async Task<ApiResult> UpdateUserAsync(UpdateUserDto updateUserDto)
        {
            var response = await _client.PutAsJsonAsync("Users", updateUserDto);
            return await response.ToApiResultAsync();
        }
    }
}
