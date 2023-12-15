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
    internal class CustomerEntityConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable(nameof(Customer));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(255);
            builder.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(x => x.DateOfBirth)
                .IsRequired();

            builder.Property(x => x.PhoneNumber)
                .IsRequired()
                .HasMaxLength(17);
        }
    }
}

