using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SerieA.WebApi.Services.Standings;
using System.Threading.Tasks;

namespace SerieA.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,Editor")]
    public class StandingsController(IStandingService _standingService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetStandings()
        {
            var standing = await _standingService.GetAllStandingsAsync();
            return Ok(standing);
        }
    }
}
