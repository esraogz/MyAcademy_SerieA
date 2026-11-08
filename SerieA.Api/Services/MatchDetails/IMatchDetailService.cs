using SerieA.WebApi.DTOs.MatchDetailDtos;

namespace SerieA.WebApi.Services.MatchDetails
{
    public interface IMatchDetailService
    {
        Task<ResultMatchDetailDto> GetMatchDetailByIdAsync(int id);
    }
}
