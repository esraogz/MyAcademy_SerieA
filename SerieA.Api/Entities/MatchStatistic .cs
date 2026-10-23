namespace SerieA.WebApi.Entities
{
    public class MatchStatistic
    {
        public int Id { get; set; }
        public string HomePossession { get; set; }
        public string AwayPossession { get; set; }
        public int HomeShots { get; set; }
        public int AwayShots { get; set; }
        public int HomeShotsOnTarget { get; set; }
        public int AwayShotsOnTarget { get; set; }
        public int HomePasses { get; set; }
        public int AwayPasses { get; set; }
        public string HomePassAccuracy { get; set; }
        public string AwayPassAccuracy { get; set; }
        public int HomeCorners { get; set; }
        public int AwayCorners { get; set; }
        public int HomeFouls { get; set; }
        public int AwayFouls { get; set; }
        public int HomeOffsides { get; set; }
        public int AwayOffsides { get; set; }
        
    }
}
