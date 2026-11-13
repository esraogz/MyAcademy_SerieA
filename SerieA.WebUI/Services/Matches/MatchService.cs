using SerieA.WebUI.DTOs.ErrorDtos;
using SerieA.WebUI.DTOs.MatchDtos;
using System.Reflection.Metadata.Ecma335;

namespace SerieA.WebUI.Services.Matches
{
    public class MatchService(HttpClient _httpClient) : IMatchService
    {
        public async Task<string?> CreateMatchAsync(CreateMatchDto createMatchDto)
        {
            var response = await _httpClient.PostAsJsonAsync("Matches/CreateMatch", createMatchDto);
            return await ReadErrorAsync(response);
        }

        public async Task<string?> DeleteMatchAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"Matches/{id}");
            return await ReadErrorAsync(response);
        }

        public async Task<List<ResultMatchDto>> GetAllMatchesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ResultMatchDto>>("Matches/ListGetAllMatches");

        }

        public async Task<ResultMatchDto> GetMatchByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<ResultMatchDto>($"Matches/GetMatch/{id}");
        }

        public async Task<string?> UpdateMatchAsync(UpdateMatchDto updateMatchDto)
        {
            var response = await _httpClient.PutAsJsonAsync("Matches/UpdateMatch", updateMatchDto);
            return await ReadErrorAsync(response);
        }

        private async Task<string?> ReadErrorAsync(HttpResponseMessage response)
        {
            if(response.IsSuccessStatusCode)
            {
                return null;
            }
            var error = await response.Content.ReadFromJsonAsync<ApiErrorDto>();
            return error?.Detail ?? "İşlem sırasında bir hata oluştu";
        }
    }
}
