using SerieA.WebUI.DTOs.MatchDetailDtos;

namespace SerieA.WebUI.Services.MatchDetails
{
    public class MatchDetailService(HttpClient _client) : IMatchDetailService
    {
        public async Task<ResultMatchDetailDto> GetMatchDetailByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<ResultMatchDetailDto>($"MatchDetails/GetDetail/{id}");
        }
    }
}
