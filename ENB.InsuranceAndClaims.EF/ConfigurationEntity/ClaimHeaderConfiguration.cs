using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ENB.InsuranceAndClaims.Infrastructure;
using ENB.InsuranceAndClaims.Entities;

namespace ENB.Restaurant.Event.Bookings.EF.ConfigurationEntity
{
   public class ClaimHeaderConfiguration : IEntityTypeConfiguration<ClaimHeader>
    {
        public void Configure(EntityTypeBuilder<ClaimHeader> builder)
        {

            builder.Property(x => x.Other_Details).IsRequired().HasMaxLength(350);
               builder.HasOne<Policy>(p=>p.Policy)
                .WithMany(ch=>ch.ClaimHeaders)
                .HasForeignKey(x => x.PolicyId)
                .OnDelete(DeleteBehavior.Restrict); 

        }
    }
}
