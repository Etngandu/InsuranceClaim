using System.ComponentModel.DataAnnotations;

namespace ENB.InsuranceAndClaims.Entities
{
    /// <summary>
    /// Determines the type of a contact person.
    /// </summary>
    public enum Ref_Claim_Status
    {
        /// <summary>
        /// Indicates an unidentified value.
        /// </summary>
        None = 0,

        /// <summary>
        /// Indicates a Divorce Lawyer.
        /// </summary>
        Disputed = 1,

        [Display(Name = "In Progress")]
        /// <summary>
        /// Indicates Bankruptcy Lawyer.
        /// </summary>
        In_Progress = 2,

        
        /// <summary>
        /// Indicates Employment Lawyer.
        /// </summary>
        Settled = 3,
        
    }
}
