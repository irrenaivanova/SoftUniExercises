using Horizons.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Horizons.Data.Configuration
{
    public class UserDestinationConfiguration : IEntityTypeConfiguration<UserDestination>
    {
        public void Configure(EntityTypeBuilder<UserDestination> builder)
        {
            builder.HasKey(x => new {x.UserId, x.DestinationId});
            builder.HasOne(x => x.Destination).WithMany(x => x.UsersDestinations).HasForeignKey(x => x.DestinationId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
