using ENB.InsuranceAndClaims.Entities;

namespace ENB.InsuranceAndClaims.MVC.Models
{
    public class DisplayClaimHeader
    {
        public int Id { get; set; }
        public Ref_Claim_Status Ref_Claim_Status { get; set; }

        public Ref_Claim_Type Ref_Claim_Type { get; set; }

        public  Customer? Customer { get; set; }

        public int CustomerId { get; set; }

        public Policy? Policy { get; set; }

        public int PolicyId { get; set; }
        public DateTime DateOfClaim { get; set; }
        public DateTime? Date_of_Settlement { get; set; }
        public decimal Amount_Claimed { get; set; }
        public decimal Amount_Paid { get; set; }
        public string? Namecustomer { get; set; }
        public string? Policycode { get; set; }

        public string? Other_Details { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

    }
}
