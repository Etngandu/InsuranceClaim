using ENB.InsuranceAndClaims.Entities.Collections;
using ENB.InsuranceAndClaims.Entities;

namespace ENB.InsuranceAndClaims.MVC.Models
{
    public class DisplayClaimProcessingStage
    {
        public int Id { get; set; }
        public ClaimProcessingStage? ParentClaimStage { get; set; }
        public int ParentClaimStageId { get; set; }
        public string Claim_Status_Name { get; set; } = string.Empty;
        public string Claim_Status_Description { get; set; } = string.Empty;
        public string Other_Details { get; set; } = string.Empty;

        public ClaimsProcessingStages? RepliesProcessingStages { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
