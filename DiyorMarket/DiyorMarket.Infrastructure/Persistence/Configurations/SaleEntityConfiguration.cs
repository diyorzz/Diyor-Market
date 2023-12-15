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
    internal class SaleEntityConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable(nameof(Sale));

            builder.HasKey(x => x.Id);

            builder.Property(s => s.SaleDate);

            builder.HasOne(s => s.Customer)
                 .WithMany(s => s.Sales)
                 .HasForeignKey(s => s.CustomerId);
        }
    }
}
