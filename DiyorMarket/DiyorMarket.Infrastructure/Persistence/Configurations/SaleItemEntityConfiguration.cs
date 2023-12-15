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
    internal class SaleItemEntityConfiguration : IEntityTypeConfiguration<SaleItem>
    {
        public void Configure(EntityTypeBuilder<SaleItem> builder)
        {
            builder.ToTable(nameof(SaleItem));

            builder.HasKey(x => x.Id);
            builder.Property(s => s.Quantity)
                .IsRequired();
            builder.Property(s => s.UnitPrice)
                .HasColumnType("money");

            builder.HasOne(s => s.Sale)
                .WithMany(si => si.SaleItems)
                .HasForeignKey(si => si.SaleId);
        }
    }
}
