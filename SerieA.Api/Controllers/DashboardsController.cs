using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SerieA.WebApi.Services.Dashboard;

namespace SerieA.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,Editor")]
    public class DashboardsController(IDashboardService _dashboardService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Dashboard()
        {
            var values =await _dashboardService.GetDashboardAsync();
            return Ok(values);
        }
    }
}
