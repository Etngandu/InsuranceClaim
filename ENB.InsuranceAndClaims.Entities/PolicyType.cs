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
    public class PolicyType : DomainEntity<int>, IDateTracking
    {
        public PolicyType()
        {
            Policies = new();
        }
        public string PolicyTypeCode { get; set; } = string.Empty;

        public string PolicyTypeDescrition { get; set; } = string.Empty;
        public DateTime DateCreated { get ; set ; }
        public DateTime DateModified { get; set; }
        public Policies Policies  { get; set; }
        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(PolicyTypeCode))
            {
                yield return new ValidationResult("PolicyTypeCode can't be none", new[] { "PolicyTypeCode" });
            }
        }
    }
}
