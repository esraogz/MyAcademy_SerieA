using SerieA.WebUI.DTOs.MatchDtos;

namespace SerieA.WebUI.Services.Matches
{
    public interface IMatchService
    {
        Task<List<ResultMatchDto>> GetAllMatchesAsync();
        Task<ResultMatchDto> GetMatchByIdAsync(int id);
        Task<string?> CreateMatchAsync(CreateMatchDto createMatchDto);
        Task<string?> UpdateMatchAsync(UpdateMatchDto updateMatchDto);
        Task<string?> DeleteMatchAsync(int id);
    }
}
