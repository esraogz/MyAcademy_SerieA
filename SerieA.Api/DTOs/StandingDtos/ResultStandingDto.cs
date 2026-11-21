namespace SerieA.WebApi.DTOs.StandingDtos
{
    public class ResultStandingDto
    {
        public int Position { get; set; }  //Sıralama sayısı
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string ColorA { get; set; }
        public string ColorB { get; set; }
        public int Played { get; set; }
        public int Won { get; set; }
        public int Drawn { get; set; }
        public int Lost { get; set; }
        public int GoalsFor { get; set; }
        public int GoalsAgainst { get; set; }
        public int GoalDifference => GoalsFor - GoalsAgainst;  //Averaj
        public int Points => Won * 3 + Drawn;
        public List<string> Form { get; set; } = new();   // örn. ["W","W","D","L","W"]
    }
}
