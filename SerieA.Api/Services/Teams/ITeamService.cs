using SerieA.WebApi.DTOs.TeamDtos;

namespace SerieA.WebApi.Services.Teams
{
    public interface ITeamService
    {
        Task<List<ResultTeamDto>> GetAllTeamAsync();
        Task<ResultTeamDto> GetTeamByIdAsync(int id);
        Task CreateTeamAsync(CreateTeamDto createTeamDto);
        Task UpdateTeamAsync(UpdateTeamDto updateTeamDto);
        Task DeleteTeamAsync(int id);


    }
}
