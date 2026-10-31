using SerieA.WebUI.DTOs.TeamDtos;

namespace SerieA.WebUI.Services.TeamServices
{
    public interface ITeamService
    {
        public Task<List<ResultTeamDto>> GetAllTeamsAsync();
        public Task<UpdateTeamDto> GetTeamByIdAsync(int id);
        public Task CreateTeamAsync(CreateTeamDto createTeamDto);
        public Task UpdateTeamAsync(UpdateTeamDto updateTeamDto);
        public Task DeleteTeamAsync(int id);
    }
}
