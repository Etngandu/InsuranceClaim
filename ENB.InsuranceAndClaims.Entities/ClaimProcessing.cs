using ENB.InsuranceAndClaims.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENB.InsuranceAndClaims.Entities
{
    public class ClaimProcessing : DomainEntity<int>, IDateTracking
    {
        public Customer? Customer { get; set; }
        public int CustomerId { get; set; }
        public Policy? Policy { get; set; }
        public int? PolicyId { get; set; }
        public int? ClaimHeaderId { get; set; }
        public ClaimHeader? ClaimHeader { get; set; }
        public int? ClaimProcessingStageId { get; set; }
        public ClaimProcessingStage? ClaimProcessingStage { get; set; }
        public int StaffId { get; set; }
        public Staff? Staff { get; set; }
        public Ref_Stage_Outcome Stage_Outcome { get; set; }
        public string Other_Details { get; set; } = string.Empty;
        public DateTime DateCreated { get ; set ; }
        public DateTime DateModified { get ; set ; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}
