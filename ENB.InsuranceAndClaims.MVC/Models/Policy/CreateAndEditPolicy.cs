using ENB.InsuranceAndClaims.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ENB.InsuranceAndClaims.MVC.Models
{
    public class CreateAndEditPolicy : IValidatableObject
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public int PolicyTypeId { get; set; }
        public PolicyType? PolicyType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }        
        public string Other_Details { get; set; } = string.Empty;
        public List<SelectListItem>?  ListPolicyType { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
          if(PolicyTypeId==0)
            {
                yield return new ValidationResult("Select the PolicyType", new[] { "PolicyTypeId" });

            }

           if(StartDate < DateTime.Today)
            {
                yield return new ValidationResult("StartDate should be from today", new[] { "StartDate" });
            }
            if ((StartDate > EndDate)|| (StartDate == EndDate))
            {
                yield return new ValidationResult("StartDate should before EndDate", new[] { "StartDate", "EndDate" });
            }
        }
    }
}
