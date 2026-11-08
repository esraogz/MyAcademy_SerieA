using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SerieA.Api.Entities;
using SerieA.WebApi.Context;
using SerieA.WebApi.DTOs.MatchDtos;
using SerieA.WebApi.DTOs.TeamDtos;
using SerieA.WebApi.Services.Matches;
using System.Threading.Tasks;

namespace SerieA.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchesController(IMatchService _matchService) : ControllerBase
    {
        [HttpGet("ListGetAllMatches")]
        public async Task<IActionResult> ListGetAllMatches()
        {
            return Ok(await _matchService.GetAllMatchAsync());
        }

        [HttpPost("CreateMatch")]
        public async Task<IActionResult> CreateMatch(CreateMatchDto createMatchDto)
        {
            await _matchService.CreateMatchAsync(createMatchDto);
            return Ok();
        }

        [HttpPut("UpdateMatch")]
        public async Task<IActionResult> UpdateMatch(UpdateMatchDto updateMatchDto)
        {
            await _matchService.UpdateMatchAsync(updateMatchDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMatch(int id)
        {
            await _matchService.DeleteMatchAsync(id);
            return Ok();
        }

        [HttpGet("GetMatch/{id}")]
        public async Task<IActionResult> GetMatch(int id)
        {
            return Ok(await _matchService.GetMatchByIdAsync(id));
        }


    }
}
