using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using SerieA.WebApi.Services.MatchDetails;
using System.Threading.Tasks;

namespace SerieA.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchDetailsController(IMatchDetailService _matchDetailService) : ControllerBase
    {
       [HttpGet("GetDetail/{id}")]
       public async Task<IActionResult> GetDetail(int id)
        {
            var match = await _matchDetailService.GetMatchDetailByIdAsync(id);
            return Ok(match);
        }
    }
}
