namespace SerieA.WebApi.DTOs.MatchSubstitutionDtos
{
    public class ResultMatchSubstitutionDto
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public int TeamId { get; set; }
        public string PlayerInName { get; set; }
        public string PlayerOutName { get; set; }
        public int Minute { get; set; }
        public int ExtraMinute { get; set; }
    }
}
