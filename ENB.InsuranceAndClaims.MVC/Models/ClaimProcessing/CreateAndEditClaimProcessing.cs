using ENB.InsuranceAndClaims.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ENB.InsuranceAndClaims.MVC.Models
{
    public class CreateAndEditClaimProcessing: IValidatableObject
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

        [Display(Name ="Staffmember")]
        public int StaffId { get; set; }
        public Staff? Staff { get; set; }
        public Ref_Stage_Outcome Stage_Outcome { get; set; }
        public string Other_Details { get; set; } = string.Empty;
        public List<SelectListItem>? ListStaff { get; set; }
        public List<SelectListItem>? ListStage { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Stage_Outcome==Ref_Stage_Outcome.None)
            {
                yield return new ValidationResult("Stage_Outcome can't be none", new[] {"Stage_Outcome"});
            }

            if(string.IsNullOrEmpty(Other_Details))
            {
                yield return new ValidationResult("Other_Details can't be empty", new[] { "Other_Details" });

            }
        }
    }
}
