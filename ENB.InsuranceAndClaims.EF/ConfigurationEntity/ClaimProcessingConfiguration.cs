using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ENB.InsuranceAndClaims.Infrastructure;
using ENB.InsuranceAndClaims.Entities;

namespace ENB.Restaurant.Event.Bookings.EF.ConfigurationEntity
{
   public class ClaimProcessingConfiguration : IEntityTypeConfiguration<ClaimProcessing>
    {
        public void Configure(EntityTypeBuilder<ClaimProcessing> builder)
        {
            
            builder.Property(x => x.Other_Details).IsRequired().HasMaxLength(350);
            builder.HasOne(x => x.Customer)
               .WithMany(x => x.ClaimProcessings)
               .HasForeignKey(x => x.CustomerId)
               .IsRequired(false)
               .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
