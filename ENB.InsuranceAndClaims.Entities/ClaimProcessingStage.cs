using ENB.InsuranceAndClaims.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENB.InsuranceAndClaims.Entities.Collections;

namespace ENB.InsuranceAndClaims.Entities
{
    public class ClaimProcessingStage : DomainEntity<int>, IDateTracking
    {
        public ClaimProcessingStage()
        {
            RepliesProcessingStages = new();
            ClaimProcessings = new();
        }
        public ClaimProcessingStage? ParentClaimStage { get; set; }
        public int? ParentClaimStageId { get; set; }
        public string Claim_Status_Name { get; set; } = string.Empty;
        public string Claim_Status_Description { get; set; }=string.Empty;
        public string Other_Details { get; set; } = string.Empty;

        public ClaimsProcessingStages RepliesProcessingStages { get; set; }
        public ClaimsProcessings ClaimProcessings { get; set; }
        public DateTime DateCreated { get ; set ; }
        public DateTime DateModified { get; set ; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}
