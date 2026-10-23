using Microsoft.EntityFrameworkCore;
using SerieA.Api.Entities;
using SerieA.WebApi.Entities;

namespace SerieA.WebApi.Context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>().HasOne(m => m.HomeTeam)
                                        .WithMany(t => t.HomeMatches)
                                        .HasForeignKey(m => m.HomeTeamId)
                                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Match>().HasOne(m => m.AwayTeam)
                                        .WithMany(t => t.AwayMatches)
                                        .HasForeignKey(m => m.AwayTeamId)
                                        .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Match> Matches { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<MatchCard> MatchCards { get; set; }
        public DbSet<MatchGoal> MatchGoals { get; set; }
        public DbSet<MatchSubstitution> MatchSubstitutions { get; set; }
        public DbSet<MatchStatistic> MatchStatistics { get; set; }

    }
}
