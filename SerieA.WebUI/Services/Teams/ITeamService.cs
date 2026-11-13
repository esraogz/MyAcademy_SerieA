using SerieA.WebUI.Areas.Admin.Models;
using SerieA.WebUI.DTOs.Results;
using SerieA.WebUI.DTOs.TeamDtos;

namespace SerieA.WebUI.Services.TeamServices
{
    public interface ITeamService
    {
        public Task<List<ResultTeamDto>> GetAllTeamsAsync();
        public Task<UpdateTeamDto> GetTeamByIdAsync(int id);
        public Task<ApiResult> CreateTeamAsync(CreateTeamDto createTeamDto);
        public Task<ApiResult> UpdateTeamAsync(UpdateTeamDto updateTeamDto);
        public Task<ApiResult> DeleteTeamAsync(int id);
    }
}
