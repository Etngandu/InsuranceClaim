using ENB.InsuranceAndClaims.Entities;

namespace ENB.InsuranceAndClaims.MVC.Models
{
    public class DisplayClaimProcessing
    {
        public int Id { get; set; }
        public Customer? Customer { get; set; }
        public int CustomerId { get; set; }
        public Policy? Policy { get; set; }
        public int? PolicyId { get; set; }
        public int? ClaimHeaderId { get; set; }
        public ClaimHeader? ClaimHeader { get; set; }
        public int? ClaimProcessingStageId { get; set; }
        public ClaimProcessingStage? ClaimProcessingStage { get; set; }
        public int StaffId { get; set; }
        public Staff? Staff { get; set; }
        public Ref_Stage_Outcome Stage_Outcome { get; set; }
        public string Other_Details { get; set; } = string.Empty;
        public string? Namecustomer { get; set; }
        public string? Policycode { get; set; }
        public string? ClaimStatusName { get; set; }
        public Ref_Claim_Type Claim_Type { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
