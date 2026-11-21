using SerieA.WebApi.DTOs.StandingDtos;

namespace SerieA.WebApi.Services.Standings
{
    public interface IStandingService
    {
        Task<List<ResultStandingDto>> GetAllStandingsAsync();
    }
}
