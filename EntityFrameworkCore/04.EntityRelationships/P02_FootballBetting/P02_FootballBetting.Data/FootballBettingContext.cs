using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using P02_FootballBetting.Data.Common;
using P02_FootballBetting.Data.Models;

namespace P02_FootballBetting.Data;
public class FootballBettingContext : DbContext
{
    public FootballBettingContext()
    {
    }
    public FootballBettingContext(DbContextOptions options)
            : base(options)
    {
    }

    public DbSet<Country> Countries { get; set; } = null!;
    public DbSet<Town> Towns { get; set; } = null!;
    public DbSet<Color> Colors { get; set; } = null!;
    public DbSet<Player> Players { get; set; } = null!;
    public DbSet<Position> Positions { get; set; } = null!;
    public DbSet<Team> Teams { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<PlayerStatistic> PlayersStatistics { get; set; } = null!;
    public DbSet<Game> Games { get; set; } = null!;
    public DbSet<Bet> Bets { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = Config.ConnectionString;
            optionsBuilder.UseSqlServer(connectionString);
        }
        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<PlayerStatistic>()
            .HasKey(x=> new {x.GameId,x.PlayerId });

        modelBuilder.Entity<User>()
            .HasIndex(x => x.Username)
            .IsUnique();

        modelBuilder.Entity<Team>()
            .HasOne(x=>x.Town)
            .WithMany(x=>x.Teams)
            .OnDelete(DeleteBehavior.Restrict);


        modelBuilder.Entity<Team>()
            .HasOne(x => x.PrimaryKitColor)
            .WithMany(x => x.PrimaryKitTeams)
            .HasForeignKey(x => x.PrimaryKitColorId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Team>()
           .HasOne(x => x.SecondaryKitColor)
           .WithMany(x => x.SecondaryKitTeams)
           .HasForeignKey(x => x.SecondaryKitColorId)
           .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Game>()
            .HasOne(x=>x.AwayTeam)
            .WithMany(x=>x.AwayGames)
            .HasForeignKey(x=>x.AwayTeamId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Game>()
           .HasOne(x => x.HomeTeam)
           .WithMany(x => x.HomeGames)
           .HasForeignKey(x => x.HomeTeamId)
           .OnDelete(DeleteBehavior.NoAction);


    }
}