using SerieA.WebUI.DTOs.DashboardDtos;

namespace SerieA.WebUI.Services.Dashboard
{
    public class DashboardService(HttpClient _client) : IDashboardService
    {
        public async Task<ResultDashboardDto> GetDashboardAsync()
        {
            return await _client.GetFromJsonAsync<ResultDashboardDto>("Dashboards");
        }
    }
}
