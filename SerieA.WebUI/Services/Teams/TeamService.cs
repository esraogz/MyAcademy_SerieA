using SerieA.WebUI.Areas.Admin.Models;
using SerieA.WebUI.DTOs.ErrorDtos;
using SerieA.WebUI.DTOs.Results;
using SerieA.WebUI.DTOs.TeamDtos;
using SerieA.WebUI.Extensions;
using System.Net.Http.Json;

namespace SerieA.WebUI.Services.TeamServices
{
    public class TeamService(HttpClient _client) : ITeamService
    {
        public async Task<ApiResult> CreateTeamAsync(CreateTeamDto createTeamDto)
        {
            var response = await _client.PostAsJsonAsync("Teams", createTeamDto);
            return await response.ToApiResultAsync();
        }

        public async Task<ApiResult> DeleteTeamAsync(int id)
        {
            var response = await _client.DeleteAsync($"Teams/{id}");
            return await response.ToApiResultAsync();
        }

        public async Task<List<ResultTeamDto>> GetAllTeamsAsync()
        {
            return await _client.GetFromJsonAsync<List<ResultTeamDto>>("Teams");
        }

        public async Task<UpdateTeamDto> GetTeamByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<UpdateTeamDto>($"Teams/{id}");
        }

        public async Task<ApiResult> UpdateTeamAsync(UpdateTeamDto updateTeamDto)
        {
            var response = await _client.PutAsJsonAsync("Teams", updateTeamDto);
            return await response.ToApiResultAsync();
        }
    }
}
