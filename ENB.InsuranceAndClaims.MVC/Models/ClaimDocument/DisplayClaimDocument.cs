using ENB.InsuranceAndClaims.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ENB.InsuranceAndClaims.MVC.Models
{
    public class DisplayClaimDocument
    {
        public int Id { get; set; }
        public Customer? Customer { get; set; }
        public int CustomerId { get; set; }
        public Policy? Policy { get; set; }
        public int PolicyId { get; set; }
        public ClaimHeader? ClaimHeader { get; set; }
        public int ClaimHeaderId { get; set; }

        public Staff? Staff { get; set; }
        public int? StaffId { get; set; }
        public Ref_Document_Type Ref_Document_Type { get; set; }

        public string? Other_Details { get; set; }

        public string? Namecustomer { get; set; }
        public string? Policycode { get; set; }
        public Ref_Claim_Type Claim_Type { get; set; }      
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
