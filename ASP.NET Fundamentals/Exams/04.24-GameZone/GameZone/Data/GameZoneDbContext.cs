using GameZone.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GameZone.Data
{
    public class GameZoneDbContext : IdentityDbContext
    {
        public GameZoneDbContext(DbContextOptions<GameZoneDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        
        }

        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<GamerGame> GamerGames { get; set; }

    }
}
