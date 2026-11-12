using SerieA.WebUI.DTOs.MatchEventItemDtos;

namespace SerieA.WebUI.Services.Events
{
    public interface IEventService
    {
        Task<string?> CreateEventAsync(CreateMatchEventDto createMatchEventDto);
        Task<string?> DeleteEventAsync(int id, string type);
    }
}
