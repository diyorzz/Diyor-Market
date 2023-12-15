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
    internal class SupplierEntityConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable(nameof(Supplier));

            builder.HasKey(s => s.Id);

            builder.Property(s => s.FirstName)
                .IsRequired()
                .HasMaxLength(255);
            builder.Property(s => s.LastName)
                .HasMaxLength(255);
            builder.Property(s => s.PhoneNumber)
                .IsRequired()
                .HasMaxLength(17);
            builder.Property(s => s.Company)
                .IsRequired()
                .HasMaxLength(150);

            builder.HasMany(sp => sp.Supplies)
                .WithOne(s => s.Supplier)
                .HasForeignKey(s => s.SupplierId);
        }
    }
}
