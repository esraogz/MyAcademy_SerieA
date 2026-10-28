using Microsoft.EntityFrameworkCore;
using SerieA.Api.Entities;
using SerieA.WebApi.Entities;

namespace SerieA.WebApi.Context
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>());

            // =========================================================================
            // 1. ADIM: TAKIMLAR (20 Aktif Serie A Kulübü + 2 Pasif Kulüp)
            // =========================================================================
            if (!context.Teams.Any())
            {
                var teams = new List<Team>
                {
                    new Team { Name = "Atalanta",    ShortName = "ATA", City = "Bergamo",   Region = "north",  Stadium = "Gewiss Stadium",                Capacity = 24950, Founded = 1907, ColorA = "#1E6FB8", ColorB = "#111111", LogoUrl = null, IsActive = true },
                    new Team { Name = "Bologna",     ShortName = "BOL", City = "Bologna",   Region = "north",  Stadium = "Stadio Renato Dall'Ara",        Capacity = 36462, Founded = 1909, ColorA = "#1A2F5A", ColorB = "#A21C26", LogoUrl = null, IsActive = true },
                    new Team { Name = "Cagliari",    ShortName = "CAG", City = "Cagliari",  Region = "island", Stadium = "Unipol Domus",                  Capacity = 16416, Founded = 1920, ColorA = "#A5162B", ColorB = "#0E2A56", LogoUrl = null, IsActive = true },
                    new Team { Name = "Como",        ShortName = "COM", City = "Como",      Region = "north",  Stadium = "Stadio Giuseppe Sinigaglia",    Capacity = 13602, Founded = 1907, ColorA = "#0B3E91", ColorB = "#FFFFFF", LogoUrl = null, IsActive = true },
                    new Team { Name = "Fiorentina",  ShortName = "FIO", City = "Firenze",   Region = "center", Stadium = "Stadio Artemio Franchi",        Capacity = 43147, Founded = 1926, ColorA = "#5B2A86", ColorB = "#FFFFFF", LogoUrl = null, IsActive = true },
                    new Team { Name = "Frosinone",   ShortName = "FRO", City = "Frosinone", Region = "center", Stadium = "Stadio Benito Stirpe",          Capacity = 16227, Founded = 1928, ColorA = "#1C4E9A", ColorB = "#FFD200", LogoUrl = null, IsActive = true },
                    new Team { Name = "Genoa",       ShortName = "GEN", City = "Genova",    Region = "north",  Stadium = "Stadio Luigi Ferraris",         Capacity = 36599, Founded = 1893, ColorA = "#A2172E", ColorB = "#002B5C", LogoUrl = null, IsActive = true },
                    new Team { Name = "Inter",       ShortName = "INT", City = "Milano",    Region = "north",  Stadium = "San Siro",                      Capacity = 75817, Founded = 1908, ColorA = "#0A4FA8", ColorB = "#101418", LogoUrl = null, IsActive = true },
                    new Team { Name = "Juventus",    ShortName = "JUV", City = "Torino",    Region = "north",  Stadium = "Allianz Stadium",               Capacity = 41507, Founded = 1897, ColorA = "#16181D", ColorB = "#E8E8E8", LogoUrl = null, IsActive = true },
                    new Team { Name = "Lazio",       ShortName = "LAZ", City = "Roma",      Region = "center", Stadium = "Stadio Olimpico",               Capacity = 70634, Founded = 1900, ColorA = "#8FD3F4", ColorB = "#FFFFFF", LogoUrl = null, IsActive = true },
                    new Team { Name = "Lecce",       ShortName = "LEC", City = "Lecce",     Region = "south",  Stadium = "Stadio Via del Mare",           Capacity = 31533, Founded = 1908, ColorA = "#F6D000", ColorB = "#D21F26", LogoUrl = null, IsActive = true },
                    new Team { Name = "Milan",       ShortName = "MIL", City = "Milano",    Region = "north",  Stadium = "San Siro",                      Capacity = 75817, Founded = 1899, ColorA = "#C8141E", ColorB = "#111111", LogoUrl = null, IsActive = true },
                    new Team { Name = "Monza",       ShortName = "MON", City = "Monza",     Region = "north",  Stadium = "U-Power Stadium",               Capacity = 16917, Founded = 1912, ColorA = "#D2122E", ColorB = "#FFFFFF", LogoUrl = null, IsActive = true },
                    new Team { Name = "Napoli",      ShortName = "NAP", City = "Napoli",    Region = "south",  Stadium = "Stadio Diego Armando Maradona", Capacity = 54726, Founded = 1926, ColorA = "#1E9BD7", ColorB = "#0C3C78", LogoUrl = null, IsActive = true },
                    new Team { Name = "Parma",       ShortName = "PAR", City = "Parma",     Region = "north",  Stadium = "Stadio Ennio Tardini",          Capacity = 22352, Founded = 1913, ColorA = "#FFD200", ColorB = "#1D3E8A", LogoUrl = null, IsActive = true },
                    new Team { Name = "Roma",        ShortName = "ROM", City = "Roma",      Region = "center", Stadium = "Stadio Olimpico",               Capacity = 70634, Founded = 1927, ColorA = "#8E1F2F", ColorB = "#F0B323", LogoUrl = null, IsActive = true },
                    new Team { Name = "Sassuolo",    ShortName = "SAS", City = "Sassuolo",  Region = "north",  Stadium = "Mapei Stadium",                 Capacity = 21584, Founded = 1920, ColorA = "#00A651", ColorB = "#111111", LogoUrl = null, IsActive = true },
                    new Team { Name = "Torino",      ShortName = "TOR", City = "Torino",    Region = "north",  Stadium = "Stadio Olimpico Grande Torino", Capacity = 27958, Founded = 1906, ColorA = "#7E1B1B", ColorB = "#E9D9B0", LogoUrl = null, IsActive = true },
                    new Team { Name = "Udinese",     ShortName = "UDI", City = "Udine",     Region = "north",  Stadium = "Bluenergy Stadium",             Capacity = 25144, Founded = 1896, ColorA = "#26282C", ColorB = "#FFFFFF", LogoUrl = null, IsActive = true },
                    new Team { Name = "Venezia",     ShortName = "VEN", City = "Venezia",   Region = "north",  Stadium = "Stadio Pier Luigi Penzo",       Capacity = 11150, Founded = 1907, ColorA = "#141414", ColorB = "#F06A1A", LogoUrl = null, IsActive = true },
                    // Pasif Takımlar (Admin Paneli Filtre Testi İçin)
                    new Team { Name = "Sampdoria",   ShortName = "SAM", City = "Genova",    Region = "north",  Stadium = "Stadio Luigi Ferraris",         Capacity = 36599, Founded = 1946, ColorA = "#1B4FA0", ColorB = "#FFFFFF", LogoUrl = null, IsActive = false },
                    new Team { Name = "Salernitana", ShortName = "SAL", City = "Salerno",   Region = "south",  Stadium = "Stadio Arechi",                 Capacity = 37180, Founded = 1919, ColorA = "#7A1E2E", ColorB = "#FFFFFF", LogoUrl = null, IsActive = false }
                };

                context.Teams.AddRange(teams);
                context.SaveChanges();
            }

            // =========================================================================
            // 2. ADIM: 38 MAÇ (11, 12, 13 ve 14. Hafta Fikstürü)
            // =========================================================================
            if (!context.Matches.Any())
            {
                var t = context.Teams.ToDictionary(x => x.ShortName, x => x);

                var matches = new List<Match>
                {
                    // ---------------- 11. HAFTA (10 Maç - Tamamlandı) ----------------
                    new Match { Season = "2026/27", Week = 11, MatchDate = new DateTime(2026, 10, 31, 15, 0, 0),  HomeTeamId = t["LAZ"].TeamId, AwayTeamId = t["TOR"].TeamId, Stadium = t["LAZ"].Stadium, Status = "Finished", HomeScore = 1, AwayScore = 1, HalfTimeHomeScore = 0, HalfTimeAwayScore = 1, IsFeatured = false, Referee = "Marco Guida",       Attendance = "41.200" },
                    new Match { Season = "2026/27", Week = 11, MatchDate = new DateTime(2026, 10, 31, 18, 0, 0),  HomeTeamId = t["ROM"].TeamId, AwayTeamId = t["INT"].TeamId, Stadium = t["ROM"].Stadium, Status = "Finished", HomeScore = 1, AwayScore = 2, HalfTimeHomeScore = 1, HalfTimeAwayScore = 1, IsFeatured = true,  Referee = "Davide Massa",      Attendance = "64.500" },
                    new Match { Season = "2026/27", Week = 11, MatchDate = new DateTime(2026, 10, 31, 20, 45, 0), HomeTeamId = t["NAP"].TeamId, AwayTeamId = t["ATA"].TeamId, Stadium = t["NAP"].Stadium, Status = "Finished", HomeScore = 2, AwayScore = 0, HalfTimeHomeScore = 1, HalfTimeAwayScore = 0, IsFeatured = false, Referee = "Maurizio Mariani",  Attendance = "51.000" },
                    new Match { Season = "2026/27", Week = 11, MatchDate = new DateTime(2026, 11, 1, 12, 30, 0),  HomeTeamId = t["FIO"].TeamId, AwayTeamId = t["JUV"].TeamId, Stadium = t["FIO"].Stadium, Status = "Finished", HomeScore = 0, AwayScore = 2, HalfTimeHomeScore = 0, HalfTimeAwayScore = 1, IsFeatured = false, Referee = "Simone Sozza",      Attendance = "38.900" },
                    new Match { Season = "2026/27", Week = 11, MatchDate = new DateTime(2026, 11, 1, 15, 0, 0),  HomeTeamId = t["BOL"].TeamId, AwayTeamId = t["MIL"].TeamId, Stadium = t["BOL"].Stadium, Status = "Finished", HomeScore = 1, AwayScore = 3, HalfTimeHomeScore = 1, HalfTimeAwayScore = 2, IsFeatured = false, Referee = "Daniele Chiffi",    Attendance = "31.400" },
                    new Match { Season = "2026/27", Week = 11, MatchDate = new DateTime(2026, 11, 1, 15, 0, 0),  HomeTeamId = t["GEN"].TeamId, AwayTeamId = t["COM"].TeamId, Stadium = t["GEN"].Stadium, Status = "Finished", HomeScore = 0, AwayScore = 1, HalfTimeHomeScore = 0, HalfTimeAwayScore = 0, IsFeatured = false, Referee = "Luca Pairetto",     Attendance = "30.100" },
                    new Match { Season = "2026/27", Week = 11, MatchDate = new DateTime(2026, 11, 1, 18, 0, 0),  HomeTeamId = t["PAR"].TeamId, AwayTeamId = t["UDI"].TeamId, Stadium = t["PAR"].Stadium, Status = "Finished", HomeScore = 2, AwayScore = 2, HalfTimeHomeScore = 1, HalfTimeAwayScore = 0, IsFeatured = false, Referee = "Matteo Marcenaro",  Attendance = "19.800" },
                    new Match { Season = "2026/27", Week = 11, MatchDate = new DateTime(2026, 11, 1, 20, 45, 0), HomeTeamId = t["CAG"].TeamId, AwayTeamId = t["LEC"].TeamId, Stadium = t["CAG"].Stadium, Status = "Finished", HomeScore = 1, AwayScore = 0, HalfTimeHomeScore = 0, HalfTimeAwayScore = 0, IsFeatured = false, Referee = "Andrea Colombo",    Attendance = "16.100" },
                    new Match { Season = "2026/27", Week = 11, MatchDate = new DateTime(2026, 11, 2, 18, 30, 0), HomeTeamId = t["MON"].TeamId, AwayTeamId = t["FRO"].TeamId, Stadium = t["MON"].Stadium, Status = "Finished", HomeScore = 1, AwayScore = 1, HalfTimeHomeScore = 0, HalfTimeAwayScore = 1, IsFeatured = false, Referee = "Marco Di Bello",    Attendance = "13.500" },
                    new Match { Season = "2026/27", Week = 11, MatchDate = new DateTime(2026, 11, 2, 20, 45, 0), HomeTeamId = t["VEN"].TeamId, AwayTeamId = t["SAS"].TeamId, Stadium = t["VEN"].Stadium, Status = "Finished", HomeScore = 1, AwayScore = 2, HalfTimeHomeScore = 1, HalfTimeAwayScore = 1, IsFeatured = false, Referee = "Rosario Abisso",    Attendance = "10.800" },

                    // ---------------- 12. HAFTA (10 Maç - Güncel Hafta) ----------------
                    new Match { Season = "2026/27", Week = 12, MatchDate = new DateTime(2026, 11, 7, 15, 0, 0),  HomeTeamId = t["ATA"].TeamId, AwayTeamId = t["LAZ"].TeamId, Stadium = t["ATA"].Stadium, Status = "Finished",   HomeScore = 3, AwayScore = 1, HalfTimeHomeScore = 2, HalfTimeAwayScore = 0, IsFeatured = false, Referee = "Michael Fabbri",    Attendance = "23.800" },
                    new Match { Season = "2026/27", Week = 12, MatchDate = new DateTime(2026, 11, 7, 18, 0, 0),  HomeTeamId = t["JUV"].TeamId, AwayTeamId = t["NAP"].TeamId, Stadium = t["JUV"].Stadium, Status = "Finished",   HomeScore = 1, AwayScore = 1, HalfTimeHomeScore = 1, HalfTimeAwayScore = 0, IsFeatured = false, Referee = "Daniele Doveri",    Attendance = "40.900" },
                    new Match { Season = "2026/27", Week = 12, MatchDate = new DateTime(2026, 11, 7, 20, 45, 0), HomeTeamId = t["MIL"].TeamId, AwayTeamId = t["ROM"].TeamId, Stadium = t["MIL"].Stadium, Status = "Finished",   HomeScore = 2, AwayScore = 1, HalfTimeHomeScore = 2, HalfTimeAwayScore = 0, IsFeatured = true,  Referee = "Daniele Orsato",    Attendance = "72.145" },
                    new Match { Season = "2026/27", Week = 12, MatchDate = new DateTime(2026, 11, 8, 12, 30, 0), HomeTeamId = t["INT"].TeamId, AwayTeamId = t["FIO"].TeamId, Stadium = t["INT"].Stadium, Status = "Finished",   HomeScore = 2, AwayScore = 1, HalfTimeHomeScore = 1, HalfTimeAwayScore = 1, IsFeatured = false, Referee = "Fabio Maresca",     Attendance = "71.300" },
                    new Match { Season = "2026/27", Week = 12, MatchDate = new DateTime(2026, 11, 8, 15, 0, 0),  HomeTeamId = t["TOR"].TeamId, AwayTeamId = t["BOL"].TeamId, Stadium = t["TOR"].Stadium, Status = "Live",       HomeScore = 1, AwayScore = 0, HalfTimeHomeScore = 1, HalfTimeAwayScore = 0, LiveMinute = "67",  IsFeatured = false, Referee = "Juan Luca Sacchi",  Attendance = "24.100" },
                    new Match { Season = "2026/27", Week = 12, MatchDate = new DateTime(2026, 11, 8, 15, 0, 0),  HomeTeamId = t["COM"].TeamId, AwayTeamId = t["PAR"].TeamId, Stadium = t["COM"].Stadium, Status = "Live",       HomeScore = 2, AwayScore = 0, HalfTimeHomeScore = 1, HalfTimeAwayScore = 0, LiveMinute = "64",  IsFeatured = false, Referee = "Ermanno Feliciani", Attendance = "12.900" },
                    new Match { Season = "2026/27", Week = 12, MatchDate = new DateTime(2026, 11, 8, 20, 45, 0), HomeTeamId = t["UDI"].TeamId, AwayTeamId = t["GEN"].TeamId, Stadium = t["UDI"].Stadium, Status = "NotStarted" },
                    new Match { Season = "2026/27", Week = 12, MatchDate = new DateTime(2026, 11, 9, 18, 30, 0), HomeTeamId = t["SAS"].TeamId, AwayTeamId = t["CAG"].TeamId, Stadium = t["SAS"].Stadium, Status = "NotStarted" },
                    new Match { Season = "2026/27", Week = 12, MatchDate = new DateTime(2026, 11, 9, 20, 45, 0), HomeTeamId = t["LEC"].TeamId, AwayTeamId = t["MON"].TeamId, Stadium = t["LEC"].Stadium, Status = "Postponed",  PostponedNote = "Yoğun yağış, yeni tarih bekleniyor" },
                    new Match { Season = "2026/27", Week = 12, MatchDate = new DateTime(2026, 11, 9, 20, 45, 0), HomeTeamId = t["FRO"].TeamId, AwayTeamId = t["VEN"].TeamId, Stadium = t["FRO"].Stadium, Status = "NotStarted" },

                    // ---------------- 13. HAFTA (10 Maç - Başlamadı) ----------------
                    new Match { Season = "2026/27", Week = 13, MatchDate = new DateTime(2026, 11, 14, 15, 0, 0),  HomeTeamId = t["ROM"].TeamId, AwayTeamId = t["COM"].TeamId, Stadium = t["ROM"].Stadium, Status = "NotStarted" },
                    new Match { Season = "2026/27", Week = 13, MatchDate = new DateTime(2026, 11, 14, 18, 0, 0),  HomeTeamId = t["NAP"].TeamId, AwayTeamId = t["MIL"].TeamId, Stadium = t["NAP"].Stadium, Status = "NotStarted" },
                    new Match { Season = "2026/27", Week = 13, MatchDate = new DateTime(2026, 11, 14, 20, 45, 0), HomeTeamId = t["INT"].TeamId, AwayTeamId = t["JUV"].TeamId, Stadium = t["INT"].Stadium, Status = "NotStarted", IsFeatured = true },
                    new Match { Season = "2026/27", Week = 13, MatchDate = new DateTime(2026, 11, 15, 12, 30, 0), HomeTeamId = t["LAZ"].TeamId, AwayTeamId = t["BOL"].TeamId, Stadium = t["LAZ"].Stadium, Status = "NotStarted" },
                    new Match { Season = "2026/27", Week = 13, MatchDate = new DateTime(2026, 11, 15, 15, 0, 0),  HomeTeamId = t["FIO"].TeamId, AwayTeamId = t["ATA"].TeamId, Stadium = t["FIO"].Stadium, Status = "NotStarted" },
                    new Match { Season = "2026/27", Week = 13, MatchDate = new DateTime(2026, 11, 15, 15, 0, 0),  HomeTeamId = t["GEN"].TeamId, AwayTeamId = t["TOR"].TeamId, Stadium = t["GEN"].Stadium, Status = "NotStarted" },
                    new Match { Season = "2026/27", Week = 13, MatchDate = new DateTime(2026, 11, 15, 18, 0, 0),  HomeTeamId = t["CAG"].TeamId, AwayTeamId = t["UDI"].TeamId, Stadium = t["CAG"].Stadium, Status = "NotStarted" },
                    new Match { Season = "2026/27", Week = 13, MatchDate = new DateTime(2026, 11, 15, 20, 45, 0), HomeTeamId = t["PAR"].TeamId, AwayTeamId = t["LEC"].TeamId, Stadium = t["PAR"].Stadium, Status = "NotStarted" },
                    new Match { Season = "2026/27", Week = 13, MatchDate = new DateTime(2026, 11, 16, 18, 30, 0), HomeTeamId = t["VEN"].TeamId, AwayTeamId = t["MON"].TeamId, Stadium = t["VEN"].Stadium, Status = "NotStarted" },
                    new Match { Season = "2026/27", Week = 13, MatchDate = new DateTime(2026, 11, 16, 20, 45, 0), HomeTeamId = t["SAS"].TeamId, AwayTeamId = t["FRO"].TeamId, Stadium = t["SAS"].Stadium, Status = "NotStarted" },

                    // ---------------- 14. HAFTA (8 Maç - Toplam 38 Maça Tamamlamak İçin) ----------------
                    new Match { Season = "2026/27", Week = 14, MatchDate = new DateTime(2026, 11, 21, 18, 0, 0),  HomeTeamId = t["MIL"].TeamId, AwayTeamId = t["JUV"].TeamId, Stadium = t["MIL"].Stadium, Status = "NotStarted", IsFeatured = true },
                    new Match { Season = "2026/27", Week = 14, MatchDate = new DateTime(2026, 11, 21, 20, 45, 0), HomeTeamId = t["ATA"].TeamId, AwayTeamId = t["ROM"].TeamId, Stadium = t["ATA"].Stadium, Status = "NotStarted" },
                    new Match { Season = "2026/27", Week = 14, MatchDate = new DateTime(2026, 11, 22, 15, 0, 0),  HomeTeamId = t["BOL"].TeamId, AwayTeamId = t["NAP"].TeamId, Stadium = t["BOL"].Stadium, Status = "NotStarted" },
                    new Match { Season = "2026/27", Week = 14, MatchDate = new DateTime(2026, 11, 22, 18, 0, 0),  HomeTeamId = t["TOR"].TeamId, AwayTeamId = t["INT"].TeamId, Stadium = t["TOR"].Stadium, Status = "NotStarted" },
                    new Match { Season = "2026/27", Week = 14, MatchDate = new DateTime(2026, 11, 22, 20, 45, 0), HomeTeamId = t["COM"].TeamId, AwayTeamId = t["LAZ"].TeamId, Stadium = t["COM"].Stadium, Status = "NotStarted" },
                    new Match { Season = "2026/27", Week = 14, MatchDate = new DateTime(2026, 11, 23, 15, 0, 0),  HomeTeamId = t["UDI"].TeamId, AwayTeamId = t["FIO"].TeamId, Stadium = t["UDI"].Stadium, Status = "NotStarted" },
                    new Match { Season = "2026/27", Week = 14, MatchDate = new DateTime(2026, 11, 23, 18, 0, 0),  HomeTeamId = t["LEC"].TeamId, AwayTeamId = t["GEN"].TeamId, Stadium = t["LEC"].Stadium, Status = "NotStarted" },
                    new Match { Season = "2026/27", Week = 14, MatchDate = new DateTime(2026, 11, 23, 20, 45, 0), HomeTeamId = t["MON"].TeamId, AwayTeamId = t["PAR"].TeamId, Stadium = t["MON"].Stadium, Status = "NotStarted" }
                };

                context.Matches.AddRange(matches);
                context.SaveChanges();
            }

            // =========================================================================
            // 3. ADIM: 6 FARKLI MAÇ İÇİN ZENGİN OLAYLAR & İSTATİSTİKLER
            // (Güncel Serie A yıldızları ve birbirinden farklı oyuncular)
            // =========================================================================
            if (!context.MatchGoals.Any())
            {
                // Detay eklenecek 6 maçı çekiyoruz:
                var matchMilRom = context.Matches.Include(m => m.HomeTeam).Include(m => m.AwayTeam).FirstOrDefault(m => m.Week == 12 && m.HomeTeam.ShortName == "MIL" && m.AwayTeam.ShortName == "ROM");
                var matchRomInt = context.Matches.Include(m => m.HomeTeam).Include(m => m.AwayTeam).FirstOrDefault(m => m.Week == 11 && m.HomeTeam.ShortName == "ROM" && m.AwayTeam.ShortName == "INT");
                var matchJuvNap = context.Matches.Include(m => m.HomeTeam).Include(m => m.AwayTeam).FirstOrDefault(m => m.Week == 12 && m.HomeTeam.ShortName == "JUV" && m.AwayTeam.ShortName == "NAP");
                var matchAtaLaz = context.Matches.Include(m => m.HomeTeam).Include(m => m.AwayTeam).FirstOrDefault(m => m.Week == 12 && m.HomeTeam.ShortName == "ATA" && m.AwayTeam.ShortName == "LAZ");
                var matchIntFio = context.Matches.Include(m => m.HomeTeam).Include(m => m.AwayTeam).FirstOrDefault(m => m.Week == 12 && m.HomeTeam.ShortName == "INT" && m.AwayTeam.ShortName == "FIO");
                var matchNapAta = context.Matches.Include(m => m.HomeTeam).Include(m => m.AwayTeam).FirstOrDefault(m => m.Week == 11 && m.HomeTeam.ShortName == "NAP" && m.AwayTeam.ShortName == "ATA");

                // ---------------------------------------------------------------------
                // MAÇ 1: MILAN 2 - 1 ROMA (12. Hafta)
                // ---------------------------------------------------------------------
                if (matchMilRom != null)
                {
                    int mId = matchMilRom.MatchId, h = matchMilRom.HomeTeamId, a = matchMilRom.AwayTeamId;

                    context.MatchGoals.AddRange(
                        new MatchGoal { MatchId = mId, TeamId = h, PlayerName = "Rafael Leão", AssistPlayerName = "Theo Hernández", GoleType = "Gol, plase", Minute = 14, ExtraMinute = 0 },
                        new MatchGoal { MatchId = mId, TeamId = h, PlayerName = "Álvaro Morata", AssistPlayerName = "Christian Pulisic", GoleType = "Gol, kafa", Minute = 41, ExtraMinute = 0 },
                        new MatchGoal { MatchId = mId, TeamId = a, PlayerName = "Artem Dovbyk", AssistPlayerName = "Lorenzo Pellegrini", GoleType = "Gol", Minute = 72, ExtraMinute = 0 }
                    );

                    context.MatchCards.AddRange(
                        new MatchCard { MatchId = mId, TeamId = a, PlayerName = "Paulo Dybala", CartType = "Yellow", Reason = "Sarı kart, faul", Minute = 27, ExtraMinute = null },
                        new MatchCard { MatchId = mId, TeamId = a, PlayerName = "Bryan Cristante", CartType = "Yellow", Reason = "Sarı kart, taktik faul", Minute = 54, ExtraMinute = null },
                        new MatchCard { MatchId = mId, TeamId = h, PlayerName = "Fikayo Tomori", CartType = "Yellow", Reason = "Sarı kart, kontrolsüz müdahale", Minute = 67, ExtraMinute = null },
                        new MatchCard { MatchId = mId, TeamId = a, PlayerName = "Gianluca Mancini", CartType = "Yellow", Reason = "Sarı kart, hakeme itiraz", Minute = 74, ExtraMinute = null },
                        new MatchCard { MatchId = mId, TeamId = h, PlayerName = "Youssouf Fofana", CartType = "Yellow", Reason = "Sarı kart, oyunu geciktirme", Minute = 83, ExtraMinute = null },
                        new MatchCard { MatchId = mId, TeamId = a, PlayerName = "Evan Ndicka", CartType = "Red", Reason = "Kırmızı kart, bariz gol şansını engelleme", Minute = 90, ExtraMinute = 2 }
                    );

                    context.MatchSubstitutions.AddRange(
                        new MatchSubstitution { MatchId = mId, TeamId = a, PlayerInName = "Matías Soulé", PlayerOutName = "Stephan El Shaarawy", Minute = 58, ExtraMinute = 0 },
                        new MatchSubstitution { MatchId = mId, TeamId = h, PlayerInName = "Samuel Chukwueze", PlayerOutName = "Christian Pulisic", Minute = 64, ExtraMinute = 0 },
                        new MatchSubstitution { MatchId = mId, TeamId = h, PlayerInName = "Ruben Loftus-Cheek", PlayerOutName = "Tijjani Reijnders", Minute = 78, ExtraMinute = 0 },
                        new MatchSubstitution { MatchId = mId, TeamId = a, PlayerInName = "Tommaso Baldanzi", PlayerOutName = "Paulo Dybala", Minute = 79, ExtraMinute = 0 },
                        new MatchSubstitution { MatchId = mId, TeamId = h, PlayerInName = "Noah Okafor", PlayerOutName = "Rafael Leão", Minute = 88, ExtraMinute = 0 }
                    );

                    context.MatchStatistics.Add(new MatchStatistic
                    {
                        MatchId = mId,
                        HomePossession = "%54",
                        AwayPossession = "%46",
                        HomeShots = 15,
                        AwayShots = 10,
                        HomeShotsOnTarget = 7,
                        AwayShotsOnTarget = 4,
                        HomePasses = 512,
                        AwayPasses = 438,
                        HomePassAccuracy = "%87",
                        AwayPassAccuracy = "%82",
                        HomeCorners = 6,
                        AwayCorners = 4,
                        HomeFouls = 11,
                        AwayFouls = 13,
                        HomeOffsides = 2,
                        AwayOffsides = 1
                    });
                }

                // ---------------------------------------------------------------------
                // MAÇ 2: ROMA 1 - 2 INTER (11. Hafta)
                // ---------------------------------------------------------------------
                if (matchRomInt != null)
                {
                    int mId = matchRomInt.MatchId, h = matchRomInt.HomeTeamId, a = matchRomInt.AwayTeamId;

                    context.MatchGoals.AddRange(
                        new MatchGoal { MatchId = mId, TeamId = a, PlayerName = "Lautaro Martínez", AssistPlayerName = "Federico Dimarco", GoleType = "Gol, vole", Minute = 18, ExtraMinute = 0 },
                        new MatchGoal { MatchId = mId, TeamId = h, PlayerName = "Lorenzo Pellegrini", AssistPlayerName = "Angelino", GoleType = "Gol, uzaktan şut", Minute = 43, ExtraMinute = 0 },
                        new MatchGoal { MatchId = mId, TeamId = a, PlayerName = "Marcus Thuram", AssistPlayerName = "Denzel Dumfries", GoleType = "Gol", Minute = 66, ExtraMinute = 0 }
                    );

                    context.MatchCards.AddRange(
                        new MatchCard { MatchId = mId, TeamId = h, PlayerName = "Manu Koné", CartType = "Yellow", Reason = "Sarı kart, sert müdahale", Minute = 35, ExtraMinute = null },
                        new MatchCard { MatchId = mId, TeamId = a, PlayerName = "Nicolò Barella", CartType = "Yellow", Reason = "Sarı kart, itiraz", Minute = 62, ExtraMinute = null },
                        new MatchCard { MatchId = mId, TeamId = a, PlayerName = "Alessandro Bastoni", CartType = "Yellow", Reason = "Sarı kart, taktik faul", Minute = 77, ExtraMinute = null }
                    );

                    context.MatchSubstitutions.AddRange(
                        new MatchSubstitution { MatchId = mId, TeamId = a, PlayerInName = "Davide Frattesi", PlayerOutName = "Henrikh Mkhitaryan", Minute = 70, ExtraMinute = 0 },
                        new MatchSubstitution { MatchId = mId, TeamId = a, PlayerInName = "Mehdi Taremi", PlayerOutName = "Lautaro Martínez", Minute = 75, ExtraMinute = 0 },
                        new MatchSubstitution { MatchId = mId, TeamId = h, PlayerInName = "Eldor Shomurodov", PlayerOutName = "Artem Dovbyk", Minute = 81, ExtraMinute = 0 }
                    );

                    context.MatchStatistics.Add(new MatchStatistic
                    {
                        MatchId = mId,
                        HomePossession = "%47",
                        AwayPossession = "%53",
                        HomeShots = 11,
                        AwayShots = 16,
                        HomeShotsOnTarget = 4,
                        AwayShotsOnTarget = 7,
                        HomePasses = 430,
                        AwayPasses = 495,
                        HomePassAccuracy = "%84",
                        AwayPassAccuracy = "%89",
                        HomeCorners = 5,
                        AwayCorners = 8,
                        HomeFouls = 14,
                        AwayFouls = 10,
                        HomeOffsides = 1,
                        AwayOffsides = 3
                    });
                }

                // ---------------------------------------------------------------------
                // MAÇ 3: JUVENTUS 1 - 1 NAPOLI (12. Hafta)
                // ---------------------------------------------------------------------
                if (matchJuvNap != null)
                {
                    int mId = matchJuvNap.MatchId, h = matchJuvNap.HomeTeamId, a = matchJuvNap.AwayTeamId;

                    context.MatchGoals.AddRange(
                        new MatchGoal { MatchId = mId, TeamId = h, PlayerName = "Dušan Vlahović", AssistPlayerName = "Kenan Yıldız", GoleType = "Gol", Minute = 29, ExtraMinute = 0 },
                        new MatchGoal { MatchId = mId, TeamId = a, PlayerName = "Khvicha Kvaratskhelia", AssistPlayerName = "Scott McTominay", GoleType = "Gol, plase", Minute = 61, ExtraMinute = 0 }
                    );

                    context.MatchCards.AddRange(
                        new MatchCard { MatchId = mId, TeamId = h, PlayerName = "Manuel Locatelli", CartType = "Yellow", Reason = "Sarı kart, faul", Minute = 48, ExtraMinute = null },
                        new MatchCard { MatchId = mId, TeamId = a, PlayerName = "André-Frank Zambo Anguissa", CartType = "Yellow", Reason = "Sarı kart, taktik faul", Minute = 55, ExtraMinute = null },
                        new MatchCard { MatchId = mId, TeamId = h, PlayerName = "Andrea Cambiaso", CartType = "Yellow", Reason = "Sarı kart, formadan çekme", Minute = 84, ExtraMinute = null }
                    );

                    context.MatchSubstitutions.AddRange(
                        new MatchSubstitution { MatchId = mId, TeamId = h, PlayerInName = "Francisco Conceição", PlayerOutName = "Nicolás González", Minute = 63, ExtraMinute = 0 },
                        new MatchSubstitution { MatchId = mId, TeamId = a, PlayerInName = "David Neres", PlayerOutName = "Matteo Politano", Minute = 70, ExtraMinute = 0 },
                        new MatchSubstitution { MatchId = mId, TeamId = h, PlayerInName = "Khéphren Thuram", PlayerOutName = "Teun Koopmeiners", Minute = 80, ExtraMinute = 0 },
                        new MatchSubstitution { MatchId = mId, TeamId = a, PlayerInName = "Giovanni Simeone", PlayerOutName = "Romelu Lukaku", Minute = 82, ExtraMinute = 0 }
                    );

                    context.MatchStatistics.Add(new MatchStatistic
                    {
                        MatchId = mId,
                        HomePossession = "%52",
                        AwayPossession = "%48",
                        HomeShots = 13,
                        AwayShots = 12,
                        HomeShotsOnTarget = 5,
                        AwayShotsOnTarget = 5,
                        HomePasses = 485,
                        AwayPasses = 450,
                        HomePassAccuracy = "%86",
                        AwayPassAccuracy = "%85",
                        HomeCorners = 5,
                        AwayCorners = 6,
                        HomeFouls = 12,
                        AwayFouls = 11,
                        HomeOffsides = 2,
                        AwayOffsides = 2
                    });
                }

                // ---------------------------------------------------------------------
                // MAÇ 4: ATALANTA 3 - 1 LAZIO (12. Hafta)
                // ---------------------------------------------------------------------
                if (matchAtaLaz != null)
                {
                    int mId = matchAtaLaz.MatchId, h = matchAtaLaz.HomeTeamId, a = matchAtaLaz.AwayTeamId;

                    context.MatchGoals.AddRange(
                        new MatchGoal { MatchId = mId, TeamId = h, PlayerName = "Mateo Retegui", AssistPlayerName = "Ademola Lookman", GoleType = "Gol, kafa", Minute = 16, ExtraMinute = 0 },
                        new MatchGoal { MatchId = mId, TeamId = h, PlayerName = "Charles De Ketelaere", AssistPlayerName = "Éderson", GoleType = "Gol", Minute = 38, ExtraMinute = 0 },
                        new MatchGoal { MatchId = mId, TeamId = a, PlayerName = "Mattia Zaccagni", AssistPlayerName = "Nuno Tavares", GoleType = "Gol, penaltı", Minute = 59, ExtraMinute = 0 },
                        new MatchGoal { MatchId = mId, TeamId = h, PlayerName = "Ademola Lookman", AssistPlayerName = "Lazar Samardžić", GoleType = "Gol, kontra", Minute = 85, ExtraMinute = 0 }
                    );

                    context.MatchCards.AddRange(
                        new MatchCard { MatchId = mId, TeamId = a, PlayerName = "Matteo Guendouzi", CartType = "Yellow", Reason = "Sarı kart, tartışma", Minute = 33, ExtraMinute = null },
                        new MatchCard { MatchId = mId, TeamId = h, PlayerName = "Marten de Roon", CartType = "Yellow", Reason = "Sarı kart, sert faul", Minute = 58, ExtraMinute = null },
                        new MatchCard { MatchId = mId, TeamId = a, PlayerName = "Alessio Romagnoli", CartType = "Yellow", Reason = "Sarı kart, taktik faul", Minute = 76, ExtraMinute = null }
                    );

                    context.MatchSubstitutions.AddRange(
                        new MatchSubstitution { MatchId = mId, TeamId = a, PlayerInName = "Pedro", PlayerOutName = "Gustav Isaksen", Minute = 62, ExtraMinute = 0 },
                        new MatchSubstitution { MatchId = mId, TeamId = h, PlayerInName = "Lazar Samardžić", PlayerOutName = "Charles De Ketelaere", Minute = 71, ExtraMinute = 0 },
                        new MatchSubstitution { MatchId = mId, TeamId = a, PlayerInName = "Boulaye Dia", PlayerOutName = "Taty Castellanos", Minute = 74, ExtraMinute = 0 }
                    );

                    context.MatchStatistics.Add(new MatchStatistic
                    {
                        MatchId = mId,
                        HomePossession = "%56",
                        AwayPossession = "%44",
                        HomeShots = 18,
                        AwayShots = 9,
                        HomeShotsOnTarget = 8,
                        AwayShotsOnTarget = 3,
                        HomePasses = 530,
                        AwayPasses = 410,
                        HomePassAccuracy = "%88",
                        AwayPassAccuracy = "%81",
                        HomeCorners = 7,
                        AwayCorners = 3,
                        HomeFouls = 10,
                        AwayFouls = 15,
                        HomeOffsides = 3,
                        AwayOffsides = 1
                    });
                }

                // ---------------------------------------------------------------------
                // MAÇ 5: INTER 2 - 1 FIORENTINA (12. Hafta)
                // ---------------------------------------------------------------------
                if (matchIntFio != null)
                {
                    int mId = matchIntFio.MatchId, h = matchIntFio.HomeTeamId, a = matchIntFio.AwayTeamId;

                    context.MatchGoals.AddRange(
                        new MatchGoal { MatchId = mId, TeamId = h, PlayerName = "Hakan Çalhanoğlu", AssistPlayerName = null, GoleType = "Gol, penaltı", Minute = 24, ExtraMinute = 0 },
                        new MatchGoal { MatchId = mId, TeamId = a, PlayerName = "Moise Kean", AssistPlayerName = "Robin Gosens", GoleType = "Gol, kafa", Minute = 44, ExtraMinute = 0 },
                        new MatchGoal { MatchId = mId, TeamId = h, PlayerName = "Nicolò Barella", AssistPlayerName = "Hakan Çalhanoğlu", GoleType = "Gol, gelişine", Minute = 73, ExtraMinute = 0 }
                    );

                    context.MatchCards.AddRange(
                        new MatchCard { MatchId = mId, TeamId = a, PlayerName = "Dodô", CartType = "Yellow", Reason = "Sarı kart, ceza sahasında faul", Minute = 23, ExtraMinute = null },
                        new MatchCard { MatchId = mId, TeamId = h, PlayerName = "Benjamin Pavard", CartType = "Yellow", Reason = "Sarı kart, faul", Minute = 60, ExtraMinute = null }
                    );

                    context.MatchSubstitutions.AddRange(
                        new MatchSubstitution { MatchId = mId, TeamId = a, PlayerInName = "Albert Guðmundsson", PlayerOutName = "Lucas Beltrán", Minute = 65, ExtraMinute = 0 },
                        new MatchSubstitution { MatchId = mId, TeamId = h, PlayerInName = "Piotr Zieliński", PlayerOutName = "Henrikh Mkhitaryan", Minute = 69, ExtraMinute = 0 },
                        new MatchSubstitution { MatchId = mId, TeamId = a, PlayerInName = "Yacine Adli", PlayerOutName = "Danilo Cataldi", Minute = 78, ExtraMinute = 0 }
                    );

                    context.MatchStatistics.Add(new MatchStatistic
                    {
                        MatchId = mId,
                        HomePossession = "%60",
                        AwayPossession = "%40",
                        HomeShots = 17,
                        AwayShots = 8,
                        HomeShotsOnTarget = 6,
                        AwayShotsOnTarget = 3,
                        HomePasses = 590,
                        AwayPasses = 380,
                        HomePassAccuracy = "%90",
                        AwayPassAccuracy = "%80",
                        HomeCorners = 9,
                        AwayCorners = 4,
                        HomeFouls = 9,
                        AwayFouls = 13,
                        HomeOffsides = 2,
                        AwayOffsides = 1
                    });
                }

                // ---------------------------------------------------------------------
                // MAÇ 6: NAPOLI 2 - 0 ATALANTA (11. Hafta)
                // ---------------------------------------------------------------------
                if (matchNapAta != null)
                {
                    int mId = matchNapAta.MatchId, h = matchNapAta.HomeTeamId, a = matchNapAta.AwayTeamId;

                    context.MatchGoals.AddRange(
                        new MatchGoal { MatchId = mId, TeamId = h, PlayerName = "Romelu Lukaku", AssistPlayerName = "Giovanni Di Lorenzo", GoleType = "Gol", Minute = 31, ExtraMinute = 0 },
                        new MatchGoal { MatchId = mId, TeamId = h, PlayerName = "Scott McTominay", AssistPlayerName = "Khvicha Kvaratskhelia", GoleType = "Gol, uzaktan şut", Minute = 79, ExtraMinute = 0 }
                    );

                    context.MatchCards.AddRange(
                        new MatchCard { MatchId = mId, TeamId = a, PlayerName = "Isak Hien", CartType = "Yellow", Reason = "Sarı kart, formadan çekme", Minute = 49, ExtraMinute = null },
                        new MatchCard { MatchId = mId, TeamId = h, PlayerName = "Alessandro Buongiorno", CartType = "Yellow", Reason = "Sarı kart, faul", Minute = 72, ExtraMinute = null }
                    );

                    context.MatchSubstitutions.AddRange(
                        new MatchSubstitution { MatchId = mId, TeamId = a, PlayerInName = "Nicolò Zaniolo", PlayerOutName = "Mario Pašalić", Minute = 66, ExtraMinute = 0 },
                        new MatchSubstitution { MatchId = mId, TeamId = h, PlayerInName = "Billy Gilmour", PlayerOutName = "Stanislav Lobotka", Minute = 82, ExtraMinute = 0 }
                    );

                    context.MatchStatistics.Add(new MatchStatistic
                    {
                        MatchId = mId,
                        HomePossession = "%51",
                        AwayPossession = "%49",
                        HomeShots = 14,
                        AwayShots = 11,
                        HomeShotsOnTarget = 6,
                        AwayShotsOnTarget = 3,
                        HomePasses = 475,
                        AwayPasses = 455,
                        HomePassAccuracy = "%86",
                        AwayPassAccuracy = "%84",
                        HomeCorners = 6,
                        AwayCorners = 5,
                        HomeFouls = 11,
                        AwayFouls = 12,
                        HomeOffsides = 1,
                        AwayOffsides = 2
                    });
                }

                context.SaveChanges();
            }
        }
    }
}