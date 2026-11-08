namespace SerieA.WebUI.DTOs.MatchCardDtos
{
    public class ResultMatchCardDto
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public int TeamId { get; set; }
        public string PlayerName { get; set; }
        public string CartType { get; set; } 
        public string? Reason { get; set; }
        public int Minute { get; set; }
        public int? ExtraMinute { get; set; }
    }
}
