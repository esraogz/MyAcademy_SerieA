using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SerieA.WebApi.Context;
using SerieA.WebApi.DTOs.DashboardDtos;
using SerieA.WebApi.DTOs.MatchDtos;
using SerieA.WebApi.Services.Standings;

namespace SerieA.WebApi.Services.Dashboard
{
    public class DashboardService(AppDbContext _context,
                                  IStandingService _standingService,
                                  IMapper _mapper) : IDashboardService
    {
        public async Task<ResultDashboardDto> GetDashboardAsync()
        {
            var nextMatches = await _context.Matches
                                            .Include(x => x.HomeTeam)
                                            .Include(x => x.AwayTeam)
                                            .Where(x => x.Status == "NotStarted")
                                            .OrderBy(x => x.MatchDate)
                                            .Take(5)
                                            .ToListAsync();

            var lastResult = await _context.Matches
                                           .Include(x => x.HomeTeam)
                                           .Include(x => x.AwayTeam)
                                           .Where(x => x.Status == "Finished")
                                           .OrderByDescending(x => x.MatchDate)
                                           .Take(5)
                                           .ToListAsync();

            var standings = await _standingService.GetAllStandingsAsync();


            return new ResultDashboardDto
            {
                ActiveTeamCount = await _context.Teams.CountAsync(x => x.IsActive),
                PlayedMatchCount = await _context.Matches.CountAsync(x => x.Status == "Finished"),
                CurrentWeek = await _context.Matches.Where(x => x.Status == "NotStarted").MinAsync(x => (int?)x.Week) ?? 1,
                TotalWeek = await _context.Matches.Select(x => x.Week).Distinct().CountAsync(),
                TotalPlayedMatch = await _context.Matches.CountAsync(),
                LiveMatchCount = await _context.Matches.CountAsync(x => x.Status == "Live"),
                NextMatches = _mapper.Map<List<ResultMatchDto>>(nextMatches),
                LastResults = _mapper.Map<List<ResultMatchDto>>(lastResult),
                Standings = standings.Take(5).ToList()

            };
        }
    }
}
