namespace SerieA.Api.Entities
{
    public class MatchGoal
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public int TeamId { get; set; }
        public string PlayerName { get; set; } //Golü atan oyuncu
        public string? AssistPlayerName { get; set; }
        public string? GoleType { get; set; }
        public int Minute { get; set; }
        public int ExtraMinute { get; set; }


        //Navigation Property
        public Match Match { get; set; }
        public Team Team { get; set; }
    }
}
