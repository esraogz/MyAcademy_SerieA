using Microsoft.AspNetCore.Components.Routing;

namespace SerieA.Api.Entities
{
    public class MatchCard
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public int TeamId { get; set; }
        public string PlayerName { get; set; } //Golü atan oyuncu
        public string CartType { get; set; }
        public string? Reason { get; set; }
        public int Minute { get; set; }
        public int? ExtraMinute { get; set; }

        //Navigation Property
        public Match Match { get; set; }
        public Team Team { get; set; }
    }
}
