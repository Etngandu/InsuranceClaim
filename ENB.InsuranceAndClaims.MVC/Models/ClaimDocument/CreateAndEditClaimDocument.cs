using ENB.InsuranceAndClaims.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ENB.InsuranceAndClaims.MVC.Models
{
    public class CreateAndEditClaimDocument: IValidatableObject
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
        public List<SelectListItem>? ListStaff { get; set; }


        public  IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Ref_Document_Type == Ref_Document_Type.None)
            {
                yield return new ValidationResult("Ref_Document_Type can't be none", new[] { "Ref_Document_Type" });
            }
        }

    }
}
