using DeskMarket.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeskMarket.Data.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Price)
                .HasColumnType("decimal(18,2)");

            builder.Property(x => x.IsDeleted)
                .HasDefaultValue(false); 
        }
    }
}
