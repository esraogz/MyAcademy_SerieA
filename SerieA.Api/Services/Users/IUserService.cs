using SerieA.WebApi.DTOs.UserDtos;

namespace SerieA.WebApi.Services.Users
{
    public interface IUserService
    {
        Task<List<ResultUserDto>> GetAllUserAsync();
        Task CreateUserAsync(CreateUserDto createUserDto);
        Task UpdateUserAsync(UpdateUserDto updateUserDto);
        Task DeleteUserAsync(int id);
        Task<ResultUserDto> GetUserByIdAsync(int id);
        Task ToggleUserStatusAsync(int userId);
        Task<List<ResultRoleDto>> GetRolesAsync();
    }
}
