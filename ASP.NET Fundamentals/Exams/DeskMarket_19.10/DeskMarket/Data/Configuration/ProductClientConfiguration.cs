using DeskMarket.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeskMarket.Data.Configuration
{
    public class ProductClientConfiguration : IEntityTypeConfiguration<ProductClient>
    {
        public void Configure(EntityTypeBuilder<ProductClient> builder)
        {
            builder.HasKey(x=> new {x.ClientId, x.ProductId});
            builder.HasOne(x => x.Product).WithMany(x => x.ProductClient).HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
