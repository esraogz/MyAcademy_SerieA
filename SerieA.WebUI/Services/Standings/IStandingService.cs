using SerieA.WebUI.DTOs.Results;
using SerieA.WebUI.DTOs.StandingDtos;

namespace SerieA.WebUI.Services.Standings
{
    public interface IStandingService
    {
        Task<List<ResultStandingDto>> GetAllStandingsAsync();
    }
}
