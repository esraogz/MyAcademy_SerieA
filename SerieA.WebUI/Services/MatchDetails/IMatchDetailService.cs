using SerieA.WebUI.DTOs.MatchDetailDtos;

namespace SerieA.WebUI.Services.MatchDetails
{
    public interface IMatchDetailService
    {
        Task<ResultMatchDetailDto> GetMatchDetailByIdAsync(int id);
    }
}
