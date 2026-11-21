using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SerieA.WebApi.Context;
using SerieA.WebApi.DTOs.StandingDtos;

namespace SerieA.WebApi.Services.Standings
{
    public class StandingService(AppDbContext _context,
                                 IMapper _mapper) : IStandingService
    {
        public async Task<List<ResultStandingDto>> GetAllStandingsAsync()
        {
            // 1. Yalnızca skoru kesinleşmiş (bitmiş) maçlar puana sayılır.
            var finishedMatches = await _context.Matches
                .Where(m => m.Status == "Finished")
                .Select(m => new { m.HomeTeamId, m.AwayTeamId, m.HomeScore, m.AwayScore, m.MatchDate })
                .ToListAsync();

            // 2. Her maç iki takımı ilgilendirir: maçı her takımın kendi bakış açısıyla
            //    (attığı gol / yediği gol) iki ayrı satıra çeviriyoruz.
            var rows = finishedMatches.SelectMany(m => new[]
            {
                new { TeamId = m.HomeTeamId, MatchDate = m.MatchDate, For = m.HomeScore ?? 0, Against = m.AwayScore ?? 0 },
                new { TeamId = m.AwayTeamId, MatchDate = m.MatchDate, For = m.AwayScore ?? 0, Against = m.HomeScore ?? 0 }
            }).ToList();




            var teams = await _context.Teams
                .Where(t => t.IsActive)
                .Select(t => new { t.TeamId, t.Name, t.ColorA, t.ColorB })
                .ToListAsync();

            var standings = teams.Select(team =>
            {
                var teamRows = rows.Where(r => r.TeamId == team.TeamId).ToList();

                return new ResultStandingDto
                {
                    TeamId = team.TeamId,
                    TeamName = team.Name,
                    ColorA = team.ColorA,
                    ColorB = team.ColorB,
                    Played = teamRows.Count,
                    Won = teamRows.Count(x => x.For > x.Against),
                    Drawn = teamRows.Count(x => x.For == x.Against),
                    Lost = teamRows.Count(x => x.For < x.Against),
                    GoalsFor = teamRows.Sum(x => x.For),
                    GoalsAgainst = teamRows.Sum(x => x.Against),
                    Form = teamRows.OrderByDescending(x => x.MatchDate)
               .Take(5)
               .OrderBy(x => x.MatchDate)      // soldan sağa eskiden yeniye
               .Select(x => x.For > x.Against ? "W" : x.For == x.Against ? "D" : "L")
               .ToList()
                };
            })

            .OrderByDescending(s => s.Points)
            .ThenByDescending(s => s.GoalDifference)
            .ThenByDescending(s => s.GoalsFor)
            .ThenBy(s => s.TeamName)
            .ToList();

            for (int i = 0; i < standings.Count; i++)
                standings[i].Position = i + 1;

            return standings;
        }
    }
}
