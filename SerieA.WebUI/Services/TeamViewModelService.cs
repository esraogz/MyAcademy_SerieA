using SerieA.WebUI.Areas.Admin.Models;
using SerieA.WebUI.Services.TeamServices;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SerieA.WebUI.Services
{
    public class TeamViewModelService(ITeamService _teamService)
    {
        public async Task<ListTeamNavbarViewModel> BuildListViewModelAsync(string? search = null, string? region = null, string? status = null)
        {
            var teams = await _teamService.GetAllTeamsAsync();
            var oldestClub = teams.OrderBy(x => x.Founded).FirstOrDefault();
            // 1. Tepsiyi oluştur ve üst istatistikleri doldur
            var model = new ListTeamNavbarViewModel
            {
                ActiveTeam = teams.Count(x => x.IsActive),
                CityRepresented = teams.DistinctBy(x => x.City).Count(),
                TotalStadiumCapacity = teams.Sum(x => x.Capacity),
                OldestClubN = oldestClub?.Name ?? "",
                OldestClubF = oldestClub?.Founded ?? 0,
                TotalTeamCount = teams.Count
            };

            // 2. Tablo listesini filtrele
            var query = teams.AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.ToLower()) ||
                                         x.City.ToLower().Contains(search.ToLower()) ||
                                         x.Stadium.ToLower().Contains(search.ToLower()));
            }
            if (!string.IsNullOrEmpty(region))
            {
                query = query.Where(x => x.Region == region);
            }
            if (!string.IsNullOrEmpty(status))
            {
                if (status == "active")
                    query = query.Where(x => x.IsActive);
                else if (status == "inactive")
                    query = query.Where(x => !x.IsActive);
            }
            // 3. Filtrelenmiş listeyi tepsiye koy ve dön
            model.Teams = query.ToList();
            return model;
        }
    }
}
