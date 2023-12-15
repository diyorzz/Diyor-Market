using DiyorMarket.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiyorMarket.Infrastructure.Persistence.Configurations
{
    internal class SupplyItemEntityConfiguration : IEntityTypeConfiguration<SupplyItem>
    {
        public void Configure(EntityTypeBuilder<SupplyItem> builder)
        {
            builder.ToTable(nameof(SupplyItem));
            builder.Property(sui => sui.Quantity)
                .IsRequired();
            builder.Property(sui => sui.UnitPrice)
                .IsRequired()
                .HasColumnType("money");

            builder.HasOne(s => s.Supply)
                .WithMany(sui => sui.SupplyItems)
                .HasForeignKey(sui => sui.SupplyId);
        }
    }
}
