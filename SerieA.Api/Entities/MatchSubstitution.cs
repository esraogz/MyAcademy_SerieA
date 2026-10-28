namespace SerieA.Api.Entities
{
    public class MatchSubstitution
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public int TeamId { get; set; }
        public string PlayerInName { get; set; } //Golü atan oyuncu
        public string PlayerOutName { get; set; } //Golü atan oyuncu
        public int Minute { get; set; }
        public int ExtraMinute { get; set; }


        //Navigation Property
        public Match Match { get; set; }
    }
}
