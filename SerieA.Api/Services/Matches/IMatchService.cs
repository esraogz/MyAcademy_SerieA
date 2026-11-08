using SerieA.WebApi.DTOs.MatchDtos;

namespace SerieA.WebApi.Services.Matches
{
    public interface IMatchService
    {
        Task<List<ResultMatchDto>> GetAllMatchAsync();
        Task CreateMatchAsync(CreateMatchDto createMatchDto);
        Task UpdateMatchAsync(UpdateMatchDto updateMatchDto);
        Task DeleteMatchAsync(int id);
        Task<ResultMatchDto> GetMatchByIdAsync(int id);
    }
}
