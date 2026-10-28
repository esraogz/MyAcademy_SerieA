namespace SerieA.Api.Entities
{
    public class Team
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Stadium { get; set; }
        public int Capacity { get; set; }
        public int Founded { get; set; }  //Kuruluş Yılı
        public string ColorA { get; set; }
        public string ColorB { get; set; }
        public string? LogoUrl { get; set; }
        public bool IsActive { get; set; }


        public List<Match> HomeMatches { get; set; }
        public List<Match> AwayMatches { get; set; }

    }
}
