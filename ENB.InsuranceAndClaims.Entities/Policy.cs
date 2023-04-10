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
    public class Policy : DomainEntity<int>, IDateTracking
    {
        public Policy()
        {
            ClaimHeaders = new();
            ClaimsDocuments = new();
        }
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public int? PolicyTypeId { get; set; }
        public PolicyType? PolicyType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime DateCreated { get; set ;}
        public DateTime DateModified { get; set; }

        public string Other_Details { get; set; } = string.Empty;

        public ClaimsHeaders ClaimHeaders  { get; set; }

        public ClaimsDocuments ClaimsDocuments { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}
