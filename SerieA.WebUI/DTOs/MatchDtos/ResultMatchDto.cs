namespace SerieA.WebUI.DTOs.MatchDtos
{
    public class ResultMatchDto
    {
        public int MatchId { get; set; }
        public int Week { get; set; }
        public DateTime MatchDate { get; set; }
        public int? HomeScore { get; set; }
        public int? AwayScore { get; set; }
        public string Status { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public string HomeTeamName { get; set; }
        public string HomeTeamColorA { get; set; }
        public string HomeTeamColorB { get; set; }
        public string? HomeTeamLogoUrl { get; set; }
        public string AwayTeamName { get; set; }
        public string AwayTeamColorA { get; set; }
        public string AwayTeamColorB { get; set; }
        public string? AwayTeamLogoUrl { get; set; }
        public string Stadium { get; set; }
    }
}
