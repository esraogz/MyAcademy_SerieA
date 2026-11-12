using SerieA.WebApi.DTOs.MatchEventItemDtos;

namespace SerieA.WebApi.Services.Events
{
    public interface IEventService
    {
        Task CreateEventAsync(CreateMatchEventDto createMatchEventDto);
        Task DeleteEventAsync(int id, string type);
    }
}
