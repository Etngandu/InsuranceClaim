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
   public class ClaimProcessingStageConfiguration : IEntityTypeConfiguration<ClaimProcessingStage>
    {
        public void Configure(EntityTypeBuilder<ClaimProcessingStage> builder)
        {
            
            builder.Property(x => x.Other_Details).IsRequired().HasMaxLength(350); 
            builder.HasOne(x => x.ParentClaimStage)
              .WithMany(x=>x.RepliesProcessingStages) 
              .HasForeignKey(x => x.ParentClaimStageId)
              .IsRequired(false)              
              .OnDelete(DeleteBehavior.Restrict); 

        }
    }
}
