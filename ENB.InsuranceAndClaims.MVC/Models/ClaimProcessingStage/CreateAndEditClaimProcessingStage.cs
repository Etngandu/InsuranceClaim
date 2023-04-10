using ENB.InsuranceAndClaims.Entities.Collections;
using ENB.InsuranceAndClaims.Entities;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace ENB.InsuranceAndClaims.MVC.Models
{
    public class CreateAndEditClaimProcessingStage: IValidatableObject
    {
        public int Id { get; set; }
        public ClaimProcessingStage? ParentClaimStage { get; set; }

        [DisplayName("Next Claim Stage")]
        public int? ParentClaimStageId { get; set; }

        [DisplayName("Claim Status Name")]
        public string Claim_Status_Name { get; set; } = string.Empty;

        [DisplayName("Claim Status Description")]
        public string Claim_Status_Description { get; set; } = string.Empty;

        [DisplayName("Other Details")]
        public string Other_Details { get; set; } = string.Empty;

        public ClaimsProcessingStages? RepliesProcessingStages { get; set; }

        public List<SelectListItem>? ListStages { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ParentClaimStageId == 0)
            {
                yield return new ValidationResult("You have to select Next claim stage", new[] { "ParentClaimStageId" });
            }
            if(string.IsNullOrEmpty(Claim_Status_Name))
            {
                yield return new ValidationResult("Claim_Status_Name can't be null", new[] { "Claim_Status_Name" });
            }
            if (string.IsNullOrEmpty(Claim_Status_Description))
            {
                yield return new ValidationResult("Claim_Status_Description can't be null", new[] { "Claim_Status_Description" });
            }
        }
    }
}
