# 🏆 Serie A Bootcamp Case - Tasarım Uyumlu Proje ve GitHub Takip Listesi (To-Do)

> **İpucu:** Paylaştığın **5 HTML tasarım dosyasını** (`Admin Paneli 1`, `Admin Paneli 2`, `Detaylı Maç Sonucu`, `Haftalık Fikstür`, `Puan Durumu`) satır satır inceledim! Tasarımlarda PDF'te yazmayan ama ekranda çok şık duran **Bölge (Region), Kulüp Renkleri (ColorA/ColorB), Hakem, Seyirci Sayısı, Maç İstatistikleri, Asist/Kart Nedeni** gibi ekstra property'ler var. Veritabanı ve API adımlarını **tamamen bu tasarımlara %100 uyacak şekilde** güncelledim.

---

## 📌 GitHub'a Kod Atarken Dikkat Edilecek Altın Kurallar
- [ ] **`.gitignore` Kontrolü:** İlk commit'ten önce ana dizinde `.gitignore` olduğundan emin ol (`bin/`, `obj/`, `.vs/` klasörleri GitHub'a **atılmamalı**).
- [ ] **Anlamlı Commit Mesajları:** Her özelliği bitirdiğinde küçük ve açıklayıcı mesajlarla commit at (`feat: ...`, `fix: ...`, `chore: ...`, `docs: ...`).
- [ ] **Çalışan Kod Kuralı:** Projeyi derlemeden (Build almadan) ve hatasız çalıştığından emin olmadan commit atma.
- [ ] **Bağlantı Güvenliği:** `appsettings.json` içindeki veritabanı bağlantı cümlende (Connection String) özel şifre varsa dikkatli ol.

---

## 🏁 AŞAMA 1: Proje Kurulumu ve Git/GitHub Hazırlığı
- [ ] **1.1.** GitHub hesabında proje için yeni bir repository (depo) oluştur (Örn: `MyAcademy_SerieA`).
- [ ] **1.2.** Bilgisayarında boş bir Solution (`MyAcademy_SerieA.sln`) oluştur.
- [ ] **1.3.** Solution içerisine **SerieA.API** (ASP.NET Core Web API) projesini ekle.
- [ ] **1.4.** Solution içerisine **SerieA.WebUI** (ASP.NET Core MVC) projesini ekle.
- [ ] **1.5.** Solution ana dizinine `.NET / Visual Studio` uyumlu `.gitignore` dosyasını ekle.
- [ ] **1.6.** Yerel Git'i başlat (`git init`) ve uzak GitHub deponla bağla (`git remote add origin ...`).
- [ ] 📌 **GitHub Görevi 1:** Boş ama derlenen ilk proje iskeletini GitHub'a gönder (`chore: initial project structure with API and WebUI`).

---

## 🗄️ AŞAMA 2: HTML Tasarımlarına Birebir Uygun Veritabanı ve Property'ler (API Tarafı)
*Not: Aşağıdaki property listesi doğrudan gönderdiğin HTML tasarımlarındaki tablo kolonları, modal inputları ve detay kartlarından çıkarılmıştır. Standing ve Player tablosu yine olmayacaktır.*

- [ ] **2.1.** `SerieA.API` projesine Entity Framework Core (`SqlServer`, `Tools`, `Design`) paketlerini kur.
- [ ] **2.2.** **Team** entity'sini tasarımdaki (`Admin Paneli 1.html`) tüm alanlarla oluştur:
  - [ ] `Id` (int)
  - [ ] `Name` (Takım Adı - max 40 karakter, zorunlu)
  - [ ] `Code` / `ShortName` (3 harfli kısa kod: `INT`, `MIL`, `JUV` - armada ve tabloda görünüyor)
  - [ ] `City` (Şehir: `Milano`, `Roma` vb.)
  - [ ] `Region` (Bölge filtresi ve rozeti için: `north` [Kuzey İtalya], `center` [Orta İtalya], `south` [Güney İtalya], `island` [Adalar])
  - [ ] `Stadium` (Stadyum adı: `San Siro` vb.)
  - [ ] `Capacity` (Stadyum kapasitesi: `1000` - `100000` arası sayısal değer)
  - [ ] `Founded` (Kuruluş yılı: `1850` - `2026` arası sayısal değer)
  - [ ] `ColorA` (Kulüp Ana Rengi Hex kodu: `#0A4FA8` - tasarımdaki dinamik takım arması ve renk yuvarlakları için!)
  - [ ] `ColorB` (Kulüp İkinci Rengi Hex kodu: `#101418`)
  - [ ] `LogoUrl` (İsteğe bağlı resim URL'si - tasarımda renk + 3 harfli kod ile otomatik arma da üretiliyor)
  - [ ] `IsActive` / `Status` (`active` / `inactive` - Ligde en fazla 20 aktif takım kuralı için)
- [ ] **2.3.** **Match** entity'sini tasarımdaki (`Admin Paneli 2.html`, `Haftalık Fikstür.html`, `Detaylı Maç Sonucu.html`) alanlarla oluştur:
  - [ ] `Id` (int)
  - [ ] `Season` (Sezon bilgisi, örn: `"2026/27"`)
  - [ ] `Week` (Hafta: 1-38 arası)
  - [ ] `MatchDate` / `Kickoff` (Maç Tarihi ve Saati)
  - [ ] `Stadium` (Stadyum - Ev sahibi seçilince otomatik dolacak ama değiştirilebilir)
  - [ ] `HomeTeamId` ve `AwayTeamId` (Ev sahibi ve Deplasman takım referansları)
  - [ ] `HomeScore` ve `AwayScore` (Nullable int - Maç Başlamadı veya Ertelendi ise boş)
  - [ ] `HalfTimeHomeScore` ve `HalfTimeAwayScore` (Nullable int - Maç Detay sayfasındaki *"İlk Yarı 2-0"* ve *"İkinci Yarı 0-1"* özet kartları için!)
  - [ ] `Status` (`NotStarted` [Başlamadı], `Live` [Canlı], `Finished` [Tamamlandı], `Postponed` [Ertelendi])
  - [ ] `LiveMinute` (Nullable int - Fikstürde `"Canlı 67'"` rozeti göstermek için)
  - [ ] `PostponedNote` (Nullable string - Fikstürde Ertelendi durumunda `"Yoğun yağış, yeni tarih bekleniyor"` notu için)
  - [ ] `IsFeatured` (Bool - Fikstür sağ paneldeki *"Haftanın Öne Çıkan Maçı"* kartını belirlemek için)
  - [ ] `Referee` (Nullable string - Maç Detay'daki `"Hakem: Daniele Orsato"` alanı için)
  - [ ] `Attendance` (Nullable int - Maç Detay'daki `"Seyirci: 72.145"` alanı için)
  - [ ] **Maç İstatistik Property'leri** (`Detaylı Maç Sonucu.html` sağ paneldeki bar grafikleri için Match tablosuna veya birebir ilişkili `MatchStatistic` tablosuna ekleyebilirsin):
    - [ ] `HomePossession` / `AwayPossession` (Topa sahip olma %54 - %46)
    - [ ] `HomeShots` / `AwayShots` (Şut) ve `HomeShotsOnTarget` / `AwayShotsOnTarget` (İsabetli Şut)
    - [ ] `HomePasses` / `AwayPasses` (Pas) ve `HomePassAccuracy` / `AwayPassAccuracy` (Pas İsabeti %)
    - [ ] `HomeCorners` / `AwayCorners` (Korner), `HomeFouls` / `AwayFouls` (Faul), `HomeOffsides` / `AwayOffsides` (Ofsayt)
- [ ] **2.4.** **MatchGoal** entity'sini (`Detaylı Maç Sonucu.html` timeline'ına uygun) oluştur:
  - [ ] `Id`, `MatchId`, `TeamId` (veya `IsHomeTeam`)
  - [ ] `PlayerName` (Golü atan oyuncu adı - Metin)
  - [ ] `AssistPlayerName` (Nullable string - Tasarımda `"Asist: Theo Hernández"` yazıyor!)
  - [ ] `GoalType` / `Note` (Nullable string - Tasarımda `"Gol, kafa"` gibi detay notu var)
  - [ ] `Minute` (Dakika - int) ve `ExtraMinute` (Nullable int, `90+2'` gibi uzatma dakikaları için)
- [ ] **2.5.** **MatchCard** entity'sini oluştur:
  - [ ] `Id`, `MatchId`, `TeamId` (veya `IsHomeTeam`)
  - [ ] `PlayerName` (Kart gören oyuncu adı - Metin)
  - [ ] `CardType` (`Yellow` [Sarı], `Red` [Kırmızı])
  - [ ] `Reason` (Nullable string - Tasarımda `"Sarı kart, taktik faul"`, `"itiraz"`, `"gol şansını engelleme"` yazıyor!)
  - [ ] `Minute` ve `ExtraMinute`
- [ ] **2.6.** **MatchSubstitution** entity'sini oluştur:
  - [ ] `Id`, `MatchId`, `TeamId` (veya `IsHomeTeam`)
  - [ ] `PlayerInName` (Giren oyuncu `▲` - Metin)
  - [ ] `PlayerOutName` (Çıkan oyuncu `▼` - Metin)
  - [ ] `Minute` ve `ExtraMinute`
- [ ] **2.7.** `DbContext` sınıfını oluştur, `Match` ile `Team` arasındaki çift yönlü Foreign Key ilişkisini (`HomeTeam` / `AwayTeam`) `Restrict` olarak ayarla ve Migration alıp SQL Server veritabanını oluştur.
- [ ] 📌 **GitHub Görevi 2:** Tasarıma uyumlu entity'leri ve ilk migration'ı GitHub'a gönder (`feat: create design-aligned database entities and initial migration`).

---

## 🌱 AŞAMA 3: Tasarımdaki Örnek Verilerin (Seed Data) Veritabanına Aktarılması
*Not: Gönderdiğin HTML dosyalarının `<script>` kısımlarında (`teams.js`, `fixtures.js`, `admin.js`) 22 takımın tamamı (20 aktif + Sampdoria, Salernitana pasif), renk kodları, bölgeleri, kapasiteleri ve 11, 12, 13. haftanın tüm maçları hazır olarak duruyor!*

- [ ] **3.1.** `Admin Paneli 1.html` içindeki 20 aktif + 2 pasif takımın verilerini (Renk kodları `ColorA`, `ColorB`, Bölgesi `Region`, Stadyumu, Kapasitesi, Kuruluş yılı ile birlikte) birebir Seed Data olarak ekle.
- [ ] **3.2.** `Haftalık Fikstür.html` içindeki 11, 12 ve 13. hafta maçlarını (30 maç) gerçek skorları, canlı/ertelenme durumları ve öne çıkan maç (`IsFeatured`) işaretleriyle Seed Data olarak ekle.
- [ ] **3.3.** `Detaylı Maç Sonucu.html` içindeki **Milan 2-1 Roma** maçı başta olmak üzere en az 3 maça gol, asist, kart (nedenleriyle), oyuncu değişikliği ve maç istatistiği verilerini ekle.
- [ ] 📌 **GitHub Görevi 3:** Zenginleştirilmiş Seed Data yapısını GitHub'a gönder (`feat: seed 22 Serie A teams with colors/regions and 3 weeks of fixtures`).

---

## ⚙️ AŞAMA 4: Backend (`SerieA.API`) Geliştirme ve Tasarım İş Kuralları

### 4A. Takım Yönetimi (Teams) API (`Admin Paneli 1.html` Kuralları)
- [ ] **4A.1.** Takım listeleme (`GET /api/teams`) endpoint'ini yaz (Arama metni `q`, Bölge `region` ve Durum `status` filtrelerini desteklesin).
- [ ] **4A.2.** Üstteki **Lig Şeridi (`_LeagueStrip`)** için özet verileri sağlayacak yapıyı kur:
  - [ ] Aktif takım sayısı (`20 / 20`), Temsil edilen benzersiz şehir sayısı, Toplam stadyum kapasitesi (*Dikkat: San Siro ve Stadio Olimpico gibi ortak kullanılan stadyumlar 1 kez toplanmalı!*), En köklü kulüp ve kuruluş yılı (`Genoa 1893`).
- [ ] **4A.3.** Takım Ekleme (`POST /api/teams`) ve Güncelleme (`PUT /api/teams/{id}`) validasyonlarını tasarımdaki kurallarla birebir yaz:
  - [ ] Takım adı en az 2 karakter olmalı ve aynı isimde ikinci bir takım eklenememeli.
  - [ ] Kısa ad (`Code`) tam 3 harf olmalı ve benzersiz olmalı.
  - [ ] Kapasite `1.000` ile `100.000` arasında olmalı (negatif olamaz).
  - [ ] Kuruluş yılı `1850` ile `2026` arasında olmalı.
  - [ ] Ana renk (`ColorA`) ve ikinci renk (`ColorB`) birbiriyle aynı olamaz!
  - [ ] **20 Aktif Takım Sınırı:** Ligde zaten 20 aktif takım varsa, yeni eklenen veya güncellenen bir takım "Aktif" yapılamaz (Önce başka bir takım pasife alınmalı uyarısı dönmeli).
- [ ] **4A.4.** Takım Silme (`DELETE /api/teams/{id}`) endpoint'ini yaz (Maçı olan takım silinemez veya pasife alınır).
- [ ] 📌 **GitHub Görevi 4A:** Takım API'lerini test et ve GitHub'a gönder (`feat: implement Teams API with 20-active-team limit, color and region validations`).

### 4B. Maçlar, Fikstür ve Maç Detay (Matches) API
- [ ] **4B.1.** Haftalık Fikstür (`GET /api/matches/week/{week}`) endpoint'ini oluştur:
  - [ ] Seçilen haftanın maçlarını, haftanın tarih aralığını (`7 Kasım – 9 Kasım 2026`), haftanın öne çıkan maçını ve **Hafta Özeti (`_WeeklySummary`)** verilerini (Toplam maç, Tamamlanan, Toplam gol, Maç başına gol ortalaması, Ev galibiyeti / Beraberlik / Deplasman galibiyeti dağılımı) döndürsün.
- [ ] **4B.2.** Maç Detay (`GET /api/matches/{id}`) endpoint'ini oluştur:
  - [ ] Maç üst bilgilerini, İlk Yarı / İkinci Yarı / Maç Sonu skorlarını, kronolojik birleştirilmiş **Timeline (Zaman Çizelgesi)** olaylarını (Gol anında oluşan güncel skoru `1-0`, `2-0` hesaplayarak), iki sütunlu Gol/Kart/Değişiklik listelerini ve Maç İstatistiklerini döndürsün.
- [ ] **4B.3.** Admin Maç Ekleme/Güncelleme/Silme (`POST`, `PUT`, `DELETE /api/matches`) endpoint'lerini ve kurallarını oluştur:
  - [ ] Ev sahibi ve deplasman aynı takım olamaz.
  - [ ] Aynı takım aynı hafta içinde ikinci bir maça eklenemez.
  - [ ] Durum `Live` veya `Finished` ise skorlar (`0` veya üzeri) zorunludur; `NotStarted` veya `Postponed` ise skorlar `null` kaydedilmelidir.
- [ ] 📌 **GitHub Görevi 4B:** Maç, Fikstür ve Detay API'lerini GitHub'a gönder (`feat: implement Matches, Weekly Fixture summary and Match Detail timeline endpoints`).

### 4C. Dinamik Puan Durumu (Standings) API (`Puan Durumu.html` Özellikleri)
- [ ] **4C.1.** `GET /api/standings` endpoint'ini oluştur.
- [ ] **4C.2.** Sadece `Finished` (Tamamlandı) maçları baz alarak 20 aktif takım için dinamik hesaplama yap:
  - [ ] `O`, `G`, `B`, `M`, `AG`, `YG`, `AV`, `Puan` hesaplamaları ve `Puan > AV > AG` sıralaması.
  - [ ] **Bölge (Zone) Etiketi:** 1-4. sıralar `ucl` (Şampiyonlar Ligi), 5-6. sıralar `europe` (Avrupa Kupaları), 18-20. sıralar `rel` (Düşme Hattı), diğerleri `mid`.
  - [ ] **Son 5 Maç Formu (`Form`):** Her takımın oynadığı son 5 tamamlanmış maçın sonucunu eskiden yeniye (`G`, `B`, `M` dizisi olarak) dinamik hesapla!
  - [ ] **Üst Özet Kartları (`_SummaryCards`):** Lider takım (ve 2. ile puan farkı), En çok gol atan takım (ve maç başı gol ortalaması), En az gol yiyen takım (ve maç başı ortalaması), Düşme hattı başlangıcı (18. sıradaki takım ve 17. sırayla puan farkı).
  - [ ] **Yan Panel - Formda Olanlar (`_StandingsSidebar`):** Son 5 maçta en çok puan toplayan ilk 3 takımı (`13 / 15 puan` gibi) hesapla.
- [ ] 📌 **GitHub Görevi 4C:** Gelişmiş dinamik puan durumu ve form hesaplama API'sini GitHub'a gönder (`feat: implement dynamic Standings API with last 5 form, zones and stat cards`).

---

## 🖥️ AŞAMA 5: Frontend (`SerieA.WebUI`) Kullanıcı Ekranlarının Giydirilmesi
- [ ] **5.1.** `SerieA.WebUI` projesinde `HttpClient` yapılandırmasını kur ve kullanıcı ekranları için üst navigasyon menüsü ekle (Fikstür, Puan Durumu ve Admin Panel geçişi).
- [ ] **5.2.** **Haftalık Fikstür Sayfası (`Haftalık Fikstür.html`):**
  - [ ] Tasarımdaki CSS ve HTML yapısını Razor View'a (`Views/Fixture/Index.cshtml`) taşı, Partial View'lara (`_FixturesHero`, `_WeekSelector`, `_WeekInfo`, `_FixtureCard`, `_WeeklySummary`, `_FeaturedMatch`) ayır.
  - [ ] Hafta değiştirildiğinde (11, 12, 13. haftalar) verileri API'den çekerek gün gruplarını, hafta ilerleme çubuğunu (10 parçalı progress bar), hafta özetini ve öne çıkan maçı dinamik doldur.
- [ ] **5.3.** **Puan Durumu Sayfası (`Puan Durumu.html`):**
  - [ ] Tasarımdaki yapıyı Razor View'a (`Views/Standings/Index.cshtml`) taşı.
  - [ ] Hero içindeki **Puan Dağılımı (`_PointsLadder`)** eksenini, 4 adet **Özet Kartını**, **Bölge Filtre Butonlarını** (`Tümü`, `Şampiyonlar Ligi`, `Avrupa`, `Düşme hattı`), **Takım Arama** kutusunu, **Son 5 Maç** rozetlerini ve sağdaki **Formda Olanlar** kartını API'den gelen dinamik verilerle bağla.
- [ ] **5.4.** **Maç Detay Sayfası (`Detaylı Maç Sonucu.html`):**
  - [ ] Tasarımdaki yapıyı Razor View'a (`Views/Match/Detail.cshtml`) taşı.
  - [ ] Skor tabelasını, dakika bazlı interaktif **Maç Akışı Şeridini (`_MatchFlowStrip`)**, olay filtreli (`Tümü`, `Goller`, `Kartlar`, `Değişiklikler`) **Zaman Çizelgesini (`_MatchTimeline`)**, İlk/İkinci Yarı özet kartlarını ve **İstatistik Barlarını** API'den gelen verilerle çalıştır.
- [ ] 📌 **GitHub Görevi 5:** Kullanıcı arayüzündeki 3 ana ekranı tamamlayıp GitHub'a gönder (`feat: integrate Fixture, Standings and Match Detail views with API`).

---

## 🛠️ AŞAMA 6: Admin Paneli Ekranlarının Giydirilmesi (`SerieA.WebUI`)
- [ ] **6.1.** `Admin Paneli 1.html` ve `Admin Paneli 2.html` içindeki ortak İtalya bayrağı şeritli (`tricolore`), saha çizgili sol **Sidebar (`_AdminSidebar`)** ve **Topbar (`_AdminTopbar`)** yapısını `_AdminLayout.cshtml` olarak oluştur.
- [ ] **6.2.** **Admin - Takım Yönetimi (`Admin Paneli 1.html`):**
  - [ ] Üstteki 4'lü Lig Şeridini, Arama / Bölge / Durum filtrelerini ve sıralanabilir (`ID`, `Takım`, `Kapasite`, `Kuruluş`) takım tablosunu API'ye bağla.
  - [ ] **Yeni Takım Ekle / Düzenle Modalı (`<dialog>`):** Siz isim, 3 harfli kod ve renk seçtikçe anlık değişen **Canlı Arma Önizlemesini (`crest-preview`)** koru ve kaydetme/güncelleme/silme işlemlerini API ile konuşturup sağ altta **Toast** bildirimi göster.
- [ ] **6.3.** **Admin - Maç Yönetimi (`Admin Paneli 2.html`):**
  - [ ] Takım adı, Hafta ve Durum filtreli maç tablosunu API'ye bağla.
  - [ ] **Yeni Maç Ekle / Düzenle Modalı (`<dialog>`):** Ev sahibi seçildiğinde o takımın stadyumunun otomatik dolması ve durum `Canlı` / `Tamamlandı` seçildiğinde skor kutularının açılması (`toggleScoreFields`) özelliğini koruyarak API'ye bağla.
- [ ] 📌 **GitHub Görevi 6:** Admin Takım ve Maç Yönetimi ekranlarını tamamlayıp GitHub'a gönder (`feat: implement Admin Team and Match management views with live crest preview and modals`).

---

## 🌟 AŞAMA 7 (BONUS): Case Dışı Ekleyebileceğin Farklı ve Özgün Özellikler

### 🔥 1. Admin Sidebar'daki "Boş" Bırakılan Sayfaları Canlandırmak (En Doğal Eklenti!)
- [ ] **Bonus 1A - Admin Dashboard (`Ana Sayfa` - `/Admin`):** Toplam oynanan maç, toplam atılan gol, en çok kart gören takım, yaklaşan maçlar ve son eklenen maçların yer aldığı özet istatistik ekranı.
- [ ] **Bonus 1B - Admin Maç Olayları ve İstatistik Yönetimi (`/Admin/Matches/Detail/{id}`):** Maç tablosundaki **"Görüntüle (Göz ikonu)"** butonuna tıklayınca adminin o maça **yeni Gol (ve asist), Kart, Oyuncu Değişikliği ekleyebildiği** ve **Maç İstatistiklerini (Şut, Pas, Topla Oynama)** girebildiği yönetim ekranı.
- [ ] **Bonus 1C - Admin Haftalar Yönetimi (`/Admin/Weeks`):** Hangi haftanın "Güncel Hafta" olduğunu belirleyen, haftanın tarih aralığını ve o haftanın **"Öne Çıkan Maçını (Featured Match)"** seçebildiğin ekran.

### ⚽ 2. Kullanıcı Tarafını Zenginleştirecek Futbol Özellikleri
- [ ] **Bonus 2A - Kulüp Detay / Profil Sayfası:** Bir takıma tıklandığında açılan; takımın stadyumunu, renklerini, kuruluş yılını, bu sezonki tüm maçlarını ve o takımda gol atan oyuncuları gösteren sayfa.
- [ ] **Bonus 2B - Gol ve Asist Krallığı (Capocannoniere) Sayfası:** Ayrı bir `Player` tablosu kurmadan, `MatchGoal` ve `MatchCard` tablolarındaki metin bazlı oyuncu isimlerini `GroupBy` ile gruplayarak **"Serie A Gol Krallığı"**, **"Asist Krallığı"** ve **"Kart İstatistikleri"** liderlik sayfası oluşturmak.
- [ ] **Bonus 2C - İç Saha / Dış Saha Puan Durumu Filtresi:** Puan durumu sayfasındaki filtrelerin yanına `"İç Saha"` ve `"Deplasman"` butonları ekleyerek takımların sadece evindeki veya sadece deplasmandaki puan durumunu dinamik hesaplatmak.
- [ ] **Bonus 2D - Haftalık Skor Simülatörü ("Tahmin Et" Modu):** Fikstürde henüz oynanmamış maçlara kullanıcının deneme amaçlı skor yazıp Puan Durumunun nasıl şekilleneceğini canlı görmesi.

### 💻 3. Teknik Kaliteyi Artıracak Özellikler
- [ ] **Bonus 3A - Admin Giriş Ekranı (Login / Authentication):** Sidebar'daki "Çıkış Yap" ve üstteki "Yönetici" alanını gerçek bir Cookie/Session Login sayfasıyla bağlamak.
- [ ] **Bonus 3B - SignalR ile Gerçek Zamanlı "Canlı Skor" Bildirimi:** Admin bir maçın skorunu güncellediğinde veya gol eklediğinde kullanıcı ekranlarında sayfa yenilenmeden skorun değişmesi ve gol bildirimi çıkması.
- [ ] **Bonus 3C - Excel / PDF Dışa Aktarma (Export):** Admin panelindeki Takım veya Fikstür listesini tek tuşla Excel/CSV olarak indirme butonu.

---

## 🧪 AŞAMA 8: Genel Kontrol ve Final Teslim
- [ ] **8.1.** `SerieA.API` ve `SerieA.WebUI` projelerinin birlikte hatasız çalıştığını doğrula.
- [ ] **8.2.** Admin panelinden bir maçın skorunu güncellediğinde **Puan Durumu**, **Son 5 Maç Formu** ve **Hafta Özeti** alanlarının otomatik değiştiğini test et.
- [ ] **8.3.** Projenin ekran görüntülerini içeren detaylı bir `README.md` hazırla.
- [ ] 📌 **Son GitHub Görevi:** Tüm projeyi ve `README.md` dosyasını GitHub'a gönder (`docs: add README with screenshots and finalize project`).
