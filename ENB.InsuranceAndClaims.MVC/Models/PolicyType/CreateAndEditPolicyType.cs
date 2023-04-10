using ENB.InsuranceAndClaims.Entities.Collections;
using System.ComponentModel.DataAnnotations;

namespace ENB.InsuranceAndClaims.MVC.Models
{
    public class CreateAndEditPolicyType :IValidatableObject
    {
        public int Id { get; set; }
        public string PolicyTypeCode { get; set; } = string.Empty;
        public string PolicyTypeDescrition { get; set; } = string.Empty;

        public Policies? Policies { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { if (string.IsNullOrEmpty(PolicyTypeCode))
            {
                yield return new ValidationResult("PolicyTypeCode can't be None", new[] { "PolicyTypeCode" });
            }
        }
    }
}
