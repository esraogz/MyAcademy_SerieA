using SerieA.WebUI.DTOs.DashboardDtos;

namespace SerieA.WebUI.Services.Dashboard
{
    public interface IDashboardService
    {
        Task<ResultDashboardDto> GetDashboardAsync();
    }
}
