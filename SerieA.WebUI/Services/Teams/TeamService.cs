using SerieA.WebUI.Areas.Admin.Models;
using SerieA.WebUI.DTOs.ErrorDtos;
using SerieA.WebUI.DTOs.TeamDtos;
using System.Net.Http.Json;

namespace SerieA.WebUI.Services.TeamServices
{
    public class TeamService(HttpClient _client) : ITeamService
    {
        public async Task<string?> CreateTeamAsync(CreateTeamDto createTeamDto)
        {
            var response = await _client.PostAsJsonAsync("Teams", createTeamDto);
            return await ReadErrorAsync(response);
        }

        public async Task<string?> DeleteTeamAsync(int id)
        {
            var response = await _client.DeleteAsync($"Teams/{id}");
            return await ReadErrorAsync(response);
        }

        public async Task<List<ResultTeamDto>> GetAllTeamsAsync()
        {
            return await _client.GetFromJsonAsync<List<ResultTeamDto>>("Teams");
        }

        public async Task<UpdateTeamDto> GetTeamByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<UpdateTeamDto>($"Teams/{id}");
        }

        public async Task<string?> UpdateTeamAsync(UpdateTeamDto updateTeamDto)
        {
            var response = await _client.PutAsJsonAsync("Teams", updateTeamDto);
            return await ReadErrorAsync(response);
        }

        //API'deki GlobalExceptionHandler'dan gelen mesajı okuyan merkezi metot:
        private async Task<string?> ReadErrorAsync(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                return null;
            }
            var error = await response.Content.ReadFromJsonAsync<ApiErrorDto>();
            return error?.Message ?? "İşlem sırasında bir hata oluştu";
        }
    }
}
