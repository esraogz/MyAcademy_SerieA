using SerieA.WebUI.DTOs.TeamDtos;
using System.Net.Http.Json;

namespace SerieA.WebUI.Services.TeamServices
{
    public class TeamService(HttpClient _client) : ITeamService
    {
        public async Task CreateTeamAsync(CreateTeamDto createTeamDto)
        {
            await _client.PostAsJsonAsync("Teams", createTeamDto);
        }

        public async Task DeleteTeamAsync(int id)
        {
            await _client.DeleteAsync($"Teams/{id}");
        }

        public async Task<List<ResultTeamDto>> GetAllTeamsAsync()
        {
            return await _client.GetFromJsonAsync<List<ResultTeamDto>>("Teams");
        }

        public async Task<UpdateTeamDto> GetTeamByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<UpdateTeamDto>($"Teams/{id}");
        }

        public async Task UpdateTeamAsync(UpdateTeamDto updateTeamDto)
        {
            await _client.PutAsJsonAsync("Teams", updateTeamDto);
        }
    }
}
