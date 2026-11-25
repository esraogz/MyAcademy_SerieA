using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SerieA.WebApi.Services.Dashboard;
using System.Threading.Tasks;

namespace SerieA.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
