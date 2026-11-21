using SerieA.WebUI.DTOs.Results;
using SerieA.WebUI.DTOs.StandingDtos;

namespace SerieA.WebUI.Services.Standings
{
    public class StandingService(HttpClient _client) : IStandingService
    {
        public async Task<List<ResultStandingDto>> GetAllStandingsAsync()
        {
            return await _client.GetFromJsonAsync<List<ResultStandingDto>>("Standings");
        }
    }
}
