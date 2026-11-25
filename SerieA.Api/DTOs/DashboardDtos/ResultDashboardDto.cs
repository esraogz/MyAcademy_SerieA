using Microsoft.Identity.Client;
using SerieA.WebApi.DTOs.MatchDtos;
using SerieA.WebApi.DTOs.StandingDtos;
using System.Numerics;

namespace SerieA.WebApi.DTOs.DashboardDtos
{
    public class ResultDashboardDto
    {
        public int ActiveTeamCount { get; set; }
        public int PlayedMatchCount { get; set; }
        public int CurrentWeek { get; set; }
        public int LiveMatchCount { get; set; }
        public int TotalWeek { get; set; }
        public int TotalPlayedMatch {  get; set; }

        public List<ResultMatchDto> NextMatches { get; set; }
        public List<ResultStandingDto> Standings { get; set; }
        public List<ResultMatchDto> LastResults { get; set; }
    }
}
