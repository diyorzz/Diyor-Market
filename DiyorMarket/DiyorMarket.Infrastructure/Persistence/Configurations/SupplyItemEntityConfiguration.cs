using DiyorMarket.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DiyorMarket.Infrastructure.Persistence.Configurations
{
    internal class SupplyItemEntityConfiguration : IEntityTypeConfiguration<SupplyItem>
    {
        public void Configure(EntityTypeBuilder<SupplyItem> builder)
        {
            builder.ToTable(nameof(SupplyItem));

            builder.HasKey(si => si.Id);

            builder.Property(si => si.Quantity)
                .IsRequired();

            builder.Property(si => si.UnitPrice)
                .IsRequired();

            builder.HasOne(si => si.Supply)
                .WithMany(s => s.SupplyItems)
                .HasForeignKey(si => si.SupplyId);

            builder.HasOne(si => si.Product)
                .WithMany(p => p.SupplyItems)
                .HasForeignKey(si => si.ProductId);
        }
    }
}
