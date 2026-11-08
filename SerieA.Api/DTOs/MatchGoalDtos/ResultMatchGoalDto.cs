namespace SerieA.WebApi.DTOs.MatchGoalDtos
{
    public class ResultMatchGoalDto
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public int TeamId { get; set; }
        public string PlayerName { get; set; }
        public string? AssistPlayerName { get; set; }
        public string? GoleType { get; set; } // Entity'de GoleType yazıldığı için aynı isimde
        public int Minute { get; set; }
        public int ExtraMinute { get; set; }
    }
}
