using Microsoft.AspNetCore.Authentication.Cookies;
using SerieA.WebUI.Handlers;
using SerieA.WebUI.Options;
using SerieA.WebUI.Services;
using SerieA.WebUI.Services.Auth;
using SerieA.WebUI.Services.Dashboard;
using SerieA.WebUI.Services.Events;
using SerieA.WebUI.Services.MatchDetails;
using SerieA.WebUI.Services.Matches;
using SerieA.WebUI.Services.Standings;
using SerieA.WebUI.Services.TeamServices;
using SerieA.WebUI.Services.Users;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Admin/Auth/Login";          
        options.AccessDeniedPath = "/Admin/Auth/AccessDenied"; 
        options.Cookie.Name = "SerieA.Auth";
    });

builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<JwtTokenHandler>();

var apiOptions = builder.Configuration.GetSection(nameof(ApiOptions)).Get<ApiOptions>(); //1.ApiOptions => appsettings.json'dan gelen
                                                                                         //2.ApiOptions => Bizim oluþturduðumuz ApiOptions sýnýfý
builder.Services.AddHttpClient<ITeamService, TeamService>(options =>
{
    options.BaseAddress = new Uri(apiOptions.BaseUrl);
}).AddHttpMessageHandler<JwtTokenHandler>();

builder.Services.AddHttpClient<IMatchService, MatchService>((sp, client) =>
{
    client.BaseAddress = new Uri(apiOptions.BaseUrl);
}).AddHttpMessageHandler<JwtTokenHandler>();

builder.Services.AddHttpClient<IMatchDetailService, MatchDetailService>((sp, client) =>
{
    client.BaseAddress = new Uri(apiOptions.BaseUrl);
}).AddHttpMessageHandler<JwtTokenHandler>();

builder.Services.AddHttpClient<IEventService, EventService>((sp, client) =>
{
    client.BaseAddress = new Uri(apiOptions.BaseUrl);
}).AddHttpMessageHandler<JwtTokenHandler>();

builder.Services.AddHttpClient<IStandingService, StandingService>((sp, client) =>
{
    client.BaseAddress = new Uri(apiOptions.BaseUrl);
}).AddHttpMessageHandler<JwtTokenHandler>();

builder.Services.AddHttpClient<IDashboardService, DashboardService>((sp, client) =>
{
    client.BaseAddress = new Uri(apiOptions.BaseUrl);
}).AddHttpMessageHandler<JwtTokenHandler>();

builder.Services.AddHttpClient<IUserService, UserService>((sp, client) =>
{
    client.BaseAddress = new Uri(apiOptions.BaseUrl);
}).AddHttpMessageHandler<JwtTokenHandler>();

builder.Services.AddHttpClient<IAuthService, AuthService>((sp, client) =>
{
    client.BaseAddress = new Uri(apiOptions.BaseUrl);
});

builder.Services.AddScoped<TeamViewModelService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/Auth/AccessDenied", "?statusCode={0}");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
