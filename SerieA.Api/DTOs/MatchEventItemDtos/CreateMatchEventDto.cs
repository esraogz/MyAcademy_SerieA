namespace SerieA.WebApi.DTOs.MatchEventItemDtos
{
    public class CreateMatchEventDto
    {
        public int MatchId { get; set; }
        public int TeamId { get; set; }
        public string EventType { get; set; } // "Gol", "Kart", "Değişiklik"
        public int Minute { get; set; }
        public string? ScorerPlayerName { get; set; }
        public string? CardPlayerName { get; set; }
        public string? CardType { get; set; } // "Sarı", "Kırmızı"
        public string? PlayerInName { get; set; }
        public string? PlayerOutName { get; set; }
    }
}
