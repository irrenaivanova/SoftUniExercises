using GameZone.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameZone.Data.Configuration
{
    public class GamerGameCongiduration : IEntityTypeConfiguration<GamerGame>
    {
        public void Configure(EntityTypeBuilder<GamerGame> builder)
        {
            builder.HasKey(x => new { x.GamerId, x.GameId });
            
            builder.HasOne(x=>x.Game).WithMany(x=>x.GamersGames).HasForeignKey(x=>x.GameId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
