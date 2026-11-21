using SerieA.WebUI.DTOs.MatchDtos;
using SerieA.WebUI.DTOs.Results;

namespace SerieA.WebUI.Services.Matches
{
    public interface IMatchService
    {
        Task<List<ResultMatchDto>> GetAllMatchesAsync();
        Task<ResultMatchDto> GetMatchByIdAsync(int id);
        Task<ApiResult?> CreateMatchAsync(CreateMatchDto createMatchDto);
        Task<ApiResult?> UpdateMatchAsync(UpdateMatchDto updateMatchDto);
        Task<ApiResult?> DeleteMatchAsync(int id);
        Task<List<ResultMatchDto>> GetMatchesByWeekAsync(int week);
    }
}
