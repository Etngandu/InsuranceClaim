using ENB.InsuranceAndClaims.Entities;
using ENB.InsuranceAndClaims.Entities.Collections;
using System.ComponentModel.DataAnnotations;

namespace ENB.InsuranceAndClaims.MVC.Models
{
    public class CreateAndEditStaff: IValidatableObject
    {
        #region "Public Properties"

        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;


        public string LastName { get; set; } = string.Empty;

        public string EmailAddress { get; set; } = string.Empty;

        public Gender Gender { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;

        public DateTime DateOfBirth
        {
            get;
            set;
        }

        

        public string Other_details { get; set; } = string.Empty; 
      
        #endregion

        #region validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Gender==Gender.None)
            {
                yield return new ValidationResult("Gender can't be None.", new[] { "Gender" });
            }
            if (String.IsNullOrEmpty(PhoneNumber))
            {
                yield return new ValidationResult("PhoneNumber can't be None.", new[] { "PhoneNumber" });
            }

            if (String.IsNullOrEmpty(EmailAddress))
            {
                yield return new ValidationResult("EmailAddress can't be None.", new[] { "EmailAddress" });
            }
        }
        #endregion
    }
}
