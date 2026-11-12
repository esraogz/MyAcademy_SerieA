using SerieA.WebApi.DTOs.MatchDetailDtos;
using SerieA.WebApi.DTOs.MatchEventItemDtos;

namespace SerieA.WebApi.Services.MatchDetails
{
    public interface IMatchDetailService
    {
        Task<ResultMatchDetailDto> GetMatchDetailByIdAsync(int id);
     
    }
}
