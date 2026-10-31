using Microsoft.AspNetCore.Mvc;
using SerieA.WebApi.DTOs.TeamDtos;
using SerieA.WebApi.Services.Teams;

namespace SerieA.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController(ITeamService _teamService) : ControllerBase
    {
        [HttpGet()]
        public async Task<IActionResult> ListTeam()
        {
            var teams = await _teamService.GetAllTeamAsync();
            return Ok(teams);
        }

        [HttpPost()]
        public async Task<IActionResult> AddTeams(CreateTeamDto createTeamDto)
        {
            await _teamService.CreateTeamAsync(createTeamDto);
            return Ok();
        }

        [HttpPut()]
        public async Task<IActionResult> UpdateTeam(UpdateTeamDto updateTeamDto)
        {
            await _teamService.UpdateTeamAsync(updateTeamDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            await _teamService.DeleteTeamAsync(id);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeam(int id)
        {
            var team = await _teamService.GetTeamByIdAsync(id);
            return Ok(team);
        }
    }
}
