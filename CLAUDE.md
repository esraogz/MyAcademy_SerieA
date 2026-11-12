# CLAUDE.md

Bu dosya, Claude Code'un bu depoda çalışırken ihtiyaç duyduğu bağlamı içerir.

## Proje Özeti

Serie A futbol ligi yönetimi için bir bootcamp projesi (MyAcademy). İki katmanlı yapı:

- **SerieA.Api** (`SerieA.Api/SerieA.WebApi.csproj`) — ASP.NET Core 8 Web API, EF Core + SQL Server.
- **SerieA.WebUI** (`SerieA.WebUI/SerieA.WebUI.csproj`) — ASP.NET Core 8 MVC; veritabanına doğrudan erişmez, tüm veriyi `HttpClient` ile API'den alır.

Ayrıntılı gereksinimler ve yol haritası `TODO.md` içinde (Türkçe). Tasarım referansı HTML dosyalarından alınmıştır (Admin Paneli 1/2, Detaylı Maç Sonucu, Haftalık Fikstür, Puan Durumu). **Standing ve Player tablosu yoktur** — puan durumu maç sonuçlarından hesaplanır, oyuncular metin (`PlayerName`) olarak tutulur.

## Komutlar

```bash
dotnet build MyAcademy_SerieA.sln

# API (Swagger: https://localhost:7031/swagger)
dotnet run --project SerieA.Api --launch-profile https

# WebUI (https://localhost:7142) — API'nin çalışıyor olması gerekir
dotnet run --project SerieA.WebUI --launch-profile https

# EF Core migration (API projesinde)
dotnet ef migrations add <MigrationAdi> --project SerieA.Api
dotnet ef database update --project SerieA.Api
```

- Test projesi yoktur.
- WebUI, API adresini `appsettings.json > ApiOptions:BaseUrl` (`https://localhost:7031/api/`) üzerinden okur.
- Connection string `SerieA.Api/appsettings.json` içinde yerel SQLEXPRESS instance'ına işaret eder (`SerieAProjectDb`); başka makinede çalıştırılacaksa değiştirilmelidir.
- API açılışında `SeedData.Initialize` çalışır; tablolar boşsa takım (20 aktif + pasif), maç, gol vb. örnek verileri ekler.

## Mimari

### API (`SerieA.Api`)
Akış: `Controller → I<X>Service → AppDbContext` (servisler doğrudan DbContext kullanır, repository katmanı yok).

- `Entities/` — `Team`, `Match`, `MatchGoal`, `MatchCard`, `MatchSubstitution`, `MatchStatistic` (Match ile 1-1). Match'in `HomeTeam`/`AwayTeam` ilişkileri `AppDbContext.OnModelCreating` içinde `DeleteBehavior.Restrict` ile tanımlı.
- `DTOs/<Varlık>Dtos/` — `Create…Dto`, `Update…Dto`, `Result…Dto` adlandırması.
- `Services/<Çoğul>/` — `ITeamService/TeamService`, `IMatchService/MatchService`, `IMatchDetailService/MatchDetailService`, `IEventService/EventService`. `Program.cs` içinde `AddScoped` ile kaydedilir.
- `Mapping/MappingProfile.cs` — tüm AutoMapper eşlemeleri tek profilde.
- `Exceptions/` — İş kuralı ihlallerinde `BadRequestException` (400), bulunamayan kayıtta `NotFoundException` (404) fırlatılır. `GlobalExceptionHandler` bunları `{ StatusCode, Message }` JSON'una çevirir. Controller'larda try/catch yazılmaz.
- Controller route'ları `api/[controller]` + açık action adları: ör. `GET api/Matches/ListGetAllMatches`, `POST api/Matches/CreateMatch`, `PUT api/Matches/UpdateMatch`, `DELETE api/Matches/{id}`, `GET api/Matches/GetMatch/{id}`. Controller'lar primary constructor kullanır (`MatchesController(IMatchService _matchService)`).

### WebUI (`SerieA.WebUI`)
Akış: `Areas/Admin/Controllers → Services/<X>/ (typed HttpClient) → API`.

- Yönetim ekranları `Areas/Admin` altında (`[Area("Admin")]`): `Team/ListTeam`, `Match/ListMatch`, `MatchDetail/MatchDetail`, `Event` (gol/kart/değişiklik ekle-sil, sonra MatchDetail'e redirect). Layout: `Areas/Admin/Views/Shared/_AdminLayout.cshtml` + `AdminPartial/` partial'ları.
- `DTOs/` API'deki DTO'ların **kopyasıdır** (paylaşılan proje yok). API DTO'sunda bir alan değişirse WebUI'daki karşılığını da güncelle.
- Servisler `Program.cs`'de `AddHttpClient<IXService, XService>` ile kaydedilir. Yazma işlemleri `Task<string?>` döner: başarıda `null`, hatada API'den gelen `ApiErrorDto.Message`.
- Hata gösterimi: controller'lar dönen hata mesajını `TempData[...]` (redirect) veya `ViewBag.ApiError` + `ViewBag.OpenCreateModal` (aynı view'a dönüş) ile view'a taşır; view'lar modal içinde gösterir.
- `Services/TeamViewModelService.cs` takım listesi için arama/bölge/durum filtrelemesini ve özet istatistikleri hazırlar.
- Form doğrulaması: `ValidationRules/` altında FluentValidation + `SharpGrip...AutoValidation.Mvc` (otomatik çalışır).

## İş Kuralları (API servislerinde)

- Ligde en fazla **20 aktif takım** olabilir (create ve update'te kontrol).
- Takım adı ve 3 harfli `ShortName` benzersiz olmalı (büyük/küçük harf duyarsız).
- Bir takım aynı **hafta**da yalnızca bir maç oynayabilir.
- `Status == "Finished"` ise skorlar boş olamaz. Maç durumları string: `NotStarted`, `Live`, `Finished`, `Postponed`.
- Gol eklenince/silinince `EventService` maçın `HomeScore`/`AwayScore` değerini günceller. Event türleri string ile ayrılır (`Goal`, `Card`, `Substitution`; silmede Türkçe karşılıkları da kabul edilir).

## Kurallar ve Dikkat Edilecekler

- **Namespace tutarsızlığı:** Klasör `SerieA.Api` olsa da namespace'ler çoğunlukla `SerieA.WebApi.*`. Ancak bazı entity'ler `SerieA.Api.Entities`, bazıları `SerieA.WebApi.Entities` altında. Yeni dosyada mevcut komşu dosyaların namespace'ini takip et ve gerekli `using`'leri ekle.
- Kullanıcıya dönen mesajlar, yorumlar ve hata metinleri **Türkçe**dir; aynı dili koru.
- Entity PK isimleri `<Varlık>Id` şeklindedir (`TeamId`, `MatchId`).
- Yeni özellik eklerken tipik adımlar: Entity → (gerekirse) migration → API DTO → MappingProfile → Service + Interface → `Program.cs` kaydı → Controller → WebUI DTO kopyası → WebUI Service + `AddHttpClient` kaydı → Admin controller + view.
- Commit mesajları Conventional Commits formatında: `feat(api): ...`, `feat(webui): ...`, `fix: ...`, `chore: ...`.
- `bin/`, `obj/`, `.vs/` commit'lenmez.
