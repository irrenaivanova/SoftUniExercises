using CinemaApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Cinema.App.Data
{
    public class CinemaDbContext : DbContext
    {
        public CinemaDbContext()
        {
        }
        public CinemaDbContext(DbContextOptions options)
          : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public virtual DbSet<Movie> Movies { get; set; }
    }
}