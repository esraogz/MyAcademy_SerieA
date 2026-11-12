using SerieA.WebUI.DTOs.ErrorDtos;
using SerieA.WebUI.DTOs.MatchEventItemDtos;

namespace SerieA.WebUI.Services.Events
{
    public class EventService(HttpClient _client) : IEventService
    {
        public async Task<string?> CreateEventAsync(CreateMatchEventDto createMatchEventDto)
        {
            var response = await _client.PostAsJsonAsync("Events/CreateEvent", createMatchEventDto);
            return await ReadErrorAsync(response);
        }

        public async Task<string?> DeleteEventAsync(int id, string type)
        {
            var response = await _client.DeleteAsync($"Events/{id}?type={type}");
            return await ReadErrorAsync(response);
        }

        private async Task<string?> ReadErrorAsync(HttpResponseMessage response)
        {
            if(response.IsSuccessStatusCode)
            {
                return null;
            }

            var error = await response.Content.ReadFromJsonAsync<ApiErrorDto>();
            return error?.Message ?? "İşlem sırasında bir hata oluştu";
        }
    }

    
}
