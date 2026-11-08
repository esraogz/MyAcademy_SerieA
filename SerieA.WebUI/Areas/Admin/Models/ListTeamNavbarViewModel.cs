using SerieA.WebUI.DTOs.TeamDtos;

namespace SerieA.WebUI.Areas.Admin.Models
{
    public class ListTeamNavbarViewModel
    {
        public int ActiveTeam { get; set; }
        public int CityRepresented { get; set; } //Temsil edilen şehir
        public int TotalStadiumCapacity { get; set; }
        public string OldestClubN { get; set; }
        public int OldestClubF { get; set; }
        public int TotalTeamCount { get; set; }
        public List<ResultTeamDto> Teams { get; set; }
    }
}
