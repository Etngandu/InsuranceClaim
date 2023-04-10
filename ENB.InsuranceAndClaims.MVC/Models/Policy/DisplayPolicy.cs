using ENB.InsuranceAndClaims.Entities;

namespace ENB.InsuranceAndClaims.MVC.Models
{
    public class DisplayPolicy
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public int? PolicyTypeId { get; set; }
        public PolicyType? PolicyType { get; set; }

        public string? PolicyTypeCode { get; set; }
        
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        public string Other_Details { get; set; } = string.Empty;
    }
}
