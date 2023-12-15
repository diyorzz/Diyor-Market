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
    internal class SupplyEntityConfiguration : IEntityTypeConfiguration<Supply>
    {
        public void Configure(EntityTypeBuilder<Supply> builder)
        {
            builder.ToTable(nameof(Supply));
            builder.HasKey(x => x.Id);

            builder.Property(x => x.SupplyDate)
                .IsRequired();

            builder.HasOne(s => s.Supplier)
                .WithMany(sp => sp.Supplies)
                .HasForeignKey(s => s.SupplierId);

            builder.HasMany(s => s.SupplyItems)
                .WithOne(si => si.Supply)
                .HasForeignKey(si => si.SupplyId);
        }
    }
}
