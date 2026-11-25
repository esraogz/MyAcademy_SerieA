using Microsoft.AspNetCore.Mvc;
using SerieA.WebUI.Services.Dashboard;
using System.Threading.Tasks;

namespace SerieA.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController(IDashboardService _dashboardService) : Controller
    {
        public async Task<IActionResult> Dashboard()
        {
            var result = await _dashboardService.GetDashboardAsync();
            return View(result);
        }
    }
}
