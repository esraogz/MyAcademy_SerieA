using SerieA.WebUI.DTOs.Results;
using SerieA.WebUI.DTOs.UserDtos;

namespace SerieA.WebUI.Services.Users
{
    public interface IUserService
    {
        Task<List<ResultUserDto>> GetAllUserAsync();
        Task<ApiResult> CreateUserAsync(CreateUserDto createUserDto);
        Task<ApiResult> UpdateUserAsync(UpdateUserDto updateUserDto);
        Task<ApiResult> DeleteUserAsync(int id);
        Task<ResultUserDto> GetUserByIdAsync(int id);
        Task<ApiResult> ToggleUserStatusAsync(int userId);
        Task<List<ResultRoleDto>> GetRolesAsync();
    }
}
