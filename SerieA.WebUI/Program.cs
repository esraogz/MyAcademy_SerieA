using SerieA.WebUI.Options;
using SerieA.WebUI.Services.TeamServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var apiOptions = builder.Configuration.GetSection(nameof(ApiOptions)).Get<ApiOptions>(); //1.ApiOptions => appsettings.json'dan gelen
                                                                                         //2.ApiOptions => Bizim oluþturduðumuz ApiOptions sýnýfý
builder.Services.AddHttpClient<ITeamService, TeamService>(options =>
{
    options.BaseAddress = new Uri(apiOptions.BaseUrl);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
