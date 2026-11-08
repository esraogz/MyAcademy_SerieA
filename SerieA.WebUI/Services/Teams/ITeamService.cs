using SerieA.WebUI.Areas.Admin.Models;
using SerieA.WebUI.DTOs.TeamDtos;

namespace SerieA.WebUI.Services.TeamServices
{
    public interface ITeamService
    {
        public Task<List<ResultTeamDto>> GetAllTeamsAsync();
        public Task<UpdateTeamDto> GetTeamByIdAsync(int id);
        public Task<string?> CreateTeamAsync(CreateTeamDto createTeamDto);
        public Task<string?> UpdateTeamAsync(UpdateTeamDto updateTeamDto);
        public Task<string?> DeleteTeamAsync(int id);
    }
}
