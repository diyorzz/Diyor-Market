using DiyorMarket.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

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
                .HasMaxLength(255);

            builder.Property(s => s.Company)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasMany(s => s.Supplies)
                .WithOne(sp => sp.Supplier)
                .HasForeignKey(sp => sp.SupplierId);
        }
    }
}
