using ENB.InsuranceAndClaims.Entities;
using System.ComponentModel.DataAnnotations;

namespace ENB.InsuranceAndClaims.MVC.Models
{
    public class CreateAndEditClaimHeader: IValidatableObject
    {
        public int Id { get; set; }
        public Ref_Claim_Status Ref_Claim_Status { get; set; }

        public Ref_Claim_Type Ref_Claim_Type { get; set; }

        public Customer? Customer { get; set; }

        public int CustomerId { get; set; }

        public Policy? Policy { get; set; }

        public int PolicyId { get; set; }
        public DateTime DateOfClaim { get; set; }
        public DateTime? Date_of_Settlement { get; set; }
        public decimal Amount_Claimed { get; set; }
        public decimal Amount_Paid { get; set; }      

        public string? Other_Details { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(Ref_Claim_Status==Ref_Claim_Status.None)
            {
                yield return new ValidationResult("Ref_Claim_Status can't be none", new[] { "Ref_Claim_Status" });
            }
            if (Ref_Claim_Type == Ref_Claim_Type.None)
            {
                yield return new ValidationResult("Ref_Claim_Type can't be none", new[] { "Ref_Claim_Type" });
            }
        }
    }
}
