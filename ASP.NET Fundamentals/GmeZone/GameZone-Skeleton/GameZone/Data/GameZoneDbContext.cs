﻿using GameZone.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GameZone.Data
{
    public class GameZoneDbContext : IdentityDbContext
    {
        public GameZoneDbContext(DbContextOptions<GameZoneDbContext> options)
            : base(options)
        {
        }

        public DbSet<Game> Games { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<GamerGame> GamerGames { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<GamerGame>().HasKey(x => new { x.GamerId, x.GameId });
            builder.Entity<GamerGame>().HasOne(x => x.Game).WithMany(x => x.GamerGames).OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Genre>()
                .HasData(
                new Genre { Id = 1, Name = "Action" },
                new Genre { Id = 2, Name = "Adventure" },
                new Genre { Id = 3, Name = "Fighting" },
                new Genre { Id = 4, Name = "Sports" },
                new Genre { Id = 5, Name = "Racing" },
                new Genre { Id = 6, Name = "Strategy" });
        }
    }
}
