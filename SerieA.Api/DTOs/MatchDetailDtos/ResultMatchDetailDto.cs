using SerieA.Api.Entities;
using SerieA.WebApi.DTOs.MatchCardDtos;
using SerieA.WebApi.DTOs.MatchEventItemDtos;
using SerieA.WebApi.DTOs.MatchGoalDtos;
using SerieA.WebApi.DTOs.MatchStatisticDtos;
using SerieA.WebApi.DTOs.MatchSubstitutionDtos;
using System.Linq;

namespace SerieA.WebApi.DTOs.MatchDetailDtos
{
    public class ResultMatchDetailDto
    {
        public int MatchId { get; set; }
        public int Week { get; set; }
        public string Season { get; set; }
        public DateTime MatchDate { get; set; }
        public string Stadium { get; set; }
        public int? HomeScore { get; set; }
        public int? AwayScore { get; set; }
        public int? HalfTimeHomeScore { get; set; }
        public int? HalfTimeAwayScore { get; set; }
        public string Status { get; set; }
        public string? LiveMinute { get; set; }
        public string? PostponedNote { get; set; }
        public string? Referee { get; set; }
        public string? Attendance { get; set; }
        // Ev Sahibi Takım Bilgileri 
        public int HomeTeamId { get; set; }
        public string HomeTeamName { get; set; }
        public string HomeTeamShortName { get; set; }
        public string HomeTeamColorA { get; set; }
        public string HomeTeamColorB { get; set; }
        public string? HomeTeamLogoUrl { get; set; }

        // Deplasman Takımı Bilgileri
        public int AwayTeamId { get; set; }
        public string AwayTeamName { get; set; }
        public string AwayTeamShortName { get; set; }
        public string AwayTeamColorA { get; set; }
        public string AwayTeamColorB { get; set; }
        public string? AwayTeamLogoUrl { get; set; }
        
        // Maça Ait Olaylar ve İstatistik

        public List<ResultMatchGoalDto> MatchGoals { get; set; } = new();
        public List<ResultMatchCardDto> MatchCards { get; set; } = new();
        public List<ResultMatchSubstitutionDto> MatchSubstitutions { get; set; } = new();
        public ResultMatchStatisticDto? MatchStatistic { get; set; }

        public List<MatchEventItemDto> Events =>
            (MatchGoals ?? new()).Select(g => new MatchEventItemDto
            {
                Id = g.Id,
                Minute = g.Minute,
                Type = "Gol",
                Icon = "⚽",
                TeamName = g.TeamId == HomeTeamId ? HomeTeamName : AwayTeamName,
                Description = string.IsNullOrEmpty(g.AssistPlayerName) ? g.PlayerName : $"{g.PlayerName} (Asist: {g.AssistPlayerName})"
            })
            .Concat((MatchCards ?? new()).Select(c => new MatchEventItemDto
            {
                Id = c.Id,
                Minute = c.Minute,
                Type = c.CartType == "Red" ? "Kırmızı Kart" : "Sarı Kart",
                Icon = c.CartType == "Red" ? "🟥" : "🟨",
                TeamName = c.TeamId == HomeTeamId ? HomeTeamName : AwayTeamName,
                Description = c.PlayerName
            }))
            .Concat((MatchSubstitutions ?? new ()).Select(s => new MatchEventItemDto
            {
                Id = s.Id,
                Minute = s.Minute,
                Type = "Değişiklik",
                Icon = "🔄",
                TeamName = s.TeamId == HomeTeamId ? HomeTeamName : AwayTeamName,
                Description = $"{s.PlayerInName} (Çıkan: {s.PlayerOutName})"
            }))
            .OrderBy(x => x.Minute)
            .ToList();
    }
}

