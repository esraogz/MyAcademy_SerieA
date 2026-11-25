using SerieA.WebApi.DTOs.DashboardDtos;

namespace SerieA.WebApi.Services.Dashboard
{
    public interface IDashboardService
    {
        Task<ResultDashboardDto> GetDashboardAsync();
    }
}
