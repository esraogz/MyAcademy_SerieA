using SerieA.WebUI.DTOs.ErrorDtos;
using SerieA.WebUI.DTOs.MatchDtos;
using SerieA.WebUI.DTOs.Results;
using SerieA.WebUI.Extensions;
using System.Reflection.Metadata.Ecma335;

namespace SerieA.WebUI.Services.Matches
{
    public class MatchService(HttpClient _httpClient) : IMatchService
    {
        public async Task<ApiResult> CreateMatchAsync(CreateMatchDto createMatchDto)
        {
            var response = await _httpClient.PostAsJsonAsync("Matches/CreateMatch", createMatchDto);
            return await response.ToApiResultAsync();
        }

        public async Task<ApiResult?> DeleteMatchAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"Matches/{id}");
            return await response.ToApiResultAsync();
        }

        public async Task<List<ResultMatchDto>> GetAllMatchesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ResultMatchDto>>("Matches/ListGetAllMatches");

        }

        public async Task<ResultMatchDto> GetMatchByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<ResultMatchDto>($"Matches/GetMatch/{id}");
        }

        public async Task<List<ResultMatchDto>> GetMatchesByWeekAsync(int week)
        {
            return await _httpClient.GetFromJsonAsync<List<ResultMatchDto>>($"Matches/GetMatches/{week}");
        }

        public async Task<ApiResult?> UpdateMatchAsync(UpdateMatchDto updateMatchDto)
        {
            var response = await _httpClient.PutAsJsonAsync("Matches/UpdateMatch", updateMatchDto);
            return await response.ToApiResultAsync();
        }
    }
}
