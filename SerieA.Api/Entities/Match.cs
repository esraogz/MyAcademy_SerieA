using SerieA.WebApi.Entities;

namespace SerieA.Api.Entities
{
    public class Match
    {
        public int MatchId { get; set; }
        public string Season { get; set; }
        public int Week { get; set; }
        public DateTime MatchDate { get; set; }
        public string Stadium { get; set; }
        public int? HomeScore { get; set; }
        public int? AwayScore { get; set; }
        public int? HalfTimeHomeScore { get; set; }
        public int? HalfTimeAwayScore { get; set; }
        public string Status { get; set; }
        public string? LiveMinute { get; set; }
        public string? PostponedNote { get; set; }
        public bool IsFeatured { get; set; }
        public string? Referee { get; set; }  //Hakem
        public string? Attendance { get; set; }  //seyirci 


        public Team HomeTeam { get; set; }
        public int HomeTeamId { get; set; }
        public Team AwayTeam { get; set; }
        public int AwayTeamId { get; set; }

        public List<MatchCard> MatchCards { get; set; }
        public List<MatchGoal> MatchGoals { get; set; }
        public List<MatchSubstitution> MatchSubstitutions { get; set; }
        public MatchStatistic? MatchStatistic { get; set; }  //İstatistik özeti her maçta 1 tane. O yüzden List şeklinde tutmuyoruz.






    }
}
