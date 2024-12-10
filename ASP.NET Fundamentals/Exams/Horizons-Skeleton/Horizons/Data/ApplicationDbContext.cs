using Horizons.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Horizons.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            var defaultUser = new IdentityUser
            {
                Id = "7699db7d-964f-4782-8209-d76562e0fece",
                UserName = "admin@horizons.com",
                NormalizedUserName = "ADMIN@HORIZONS.COM",
                Email = "admin@horizons.com",
                NormalizedEmail = "ADMIN@HORIZONS.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(
                    new IdentityUser { UserName = "admin@horizons.com" },
                    "Admin123!")
            };
            builder.Entity<IdentityUser>().HasData(defaultUser);
        }
            public DbSet<Destination> Destinations { get; set; }
            public DbSet<Terrain> Terrains { get; set; }

            public DbSet<UserDestination> UsersDestination { get; set; }

    }
}
