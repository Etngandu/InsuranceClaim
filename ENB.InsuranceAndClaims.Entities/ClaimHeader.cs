using ENB.InsuranceAndClaims.Entities.Collections;
using ENB.InsuranceAndClaims.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENB.InsuranceAndClaims.Entities
{
    public class ClaimHeader : DomainEntity<int>, IDateTracking
    {
        public ClaimHeader()
        {
            ClaimsDocuments = new();
            ClaimProcessings = new();
        }
        public Ref_Claim_Status Ref_Claim_Status { get; set; }

        public Ref_Claim_Type Ref_Claim_Type { get; set; }

        public Customer? Customer { get; set; }
        public int CustomerId { get; set; }
        public Policy? Policy { get; set; }
        public int PolicyId { get; set; }
        public DateTime DateOfClaim { get; set; }
        public DateTime? Date_of_Settlement { get; set; }
        public  decimal Amount_Claimed { get; set; }
        public decimal Amount_Paid { get; set; }

        public ClaimsDocuments ClaimsDocuments  { get; set; }
        public ClaimsProcessings ClaimProcessings { get; set; }
        public string? Other_Details { get; set; }

        public DateTime DateCreated { get ; set; }
        public DateTime DateModified { get; set ; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}
