namespace SerieA.WebApi.DTOs.MatchDtos
{
    public class CreateMatchDto
    {
        public int Week { get; set; }
        public DateTime MatchDate { get; set; }
        public string Stadium { get; set; }
        public string Status { get; set; }
        public string? PostponedNote { get; set; }
        public bool IsFeatured { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }

        public int? HomeScore { get; set; }
        public int? AwayScore { get; set; }
        public string Season { get; set; } = "2026/27";
    }
}
