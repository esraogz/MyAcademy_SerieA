using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SerieA.WebApi.Context;
using SerieA.WebApi.Entities;
using SerieA.WebApi.Exceptions;
using SerieA.WebApi.Mapping;
using SerieA.WebApi.Services.Dashboard;
using SerieA.WebApi.Services.Events;
using SerieA.WebApi.Services.MatchDetails;
using SerieA.WebApi.Services.Matches;
using SerieA.WebApi.Services.Standings;
using SerieA.WebApi.Services.Teams;
using SerieA.WebApi.Services.Users;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<ITeamService, TeamService>();
builder.Services.AddScoped<IMatchService, MatchService>();
builder.Services.AddScoped<IMatchDetailService, MatchDetailService>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IStandingService, StandingService>();
builder.Services.AddScoped<IDashboardService, DashboardService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddAutoMapper(cfg => { }, typeof(MappingProfile).Assembly);

builder.Services.AddControllers(options =>
{
    // Non-nullable string alanlar için otomatik İngilizce "The X field is required." hatası üretilmesin;
    // doğrulama mesajlarının tek kaynağı FluentValidation (Türkçe) olsun.
    options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}
app.UseExceptionHandler();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
