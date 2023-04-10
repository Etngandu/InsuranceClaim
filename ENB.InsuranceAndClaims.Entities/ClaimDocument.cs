using ENB.InsuranceAndClaims.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENB.InsuranceAndClaims.Entities
{
    public class ClaimDocument : DomainEntity<int>, IDateTracking
    {

        public Customer? Customer  { get; set; }
        public int CustomerId { get; set; }
        public Policy? Policy  { get; set; }
        public int? PolicyId { get; set; }
        public ClaimHeader? ClaimHeader { get; set; }
        public int? ClaimHeaderId { get; set; }

        public Staff? Staff { get; set; }
        public int? StaffId { get; set; }
        public Ref_Document_Type Ref_Document_Type { get; set; }       

        public string? Other_Details { get; set; }

        public DateTime DateCreated { get ; set; }
        public DateTime DateModified { get; set ; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(Ref_Document_Type==Ref_Document_Type.None)
            {
                yield return new ValidationResult("Ref_Document_Type can't be none", new[] { "Ref_Document_Type" });
            }
        }
    }
}
