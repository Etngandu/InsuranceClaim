namespace ENB.InsuranceAndClaims.MVC.Models
{
    public class DisplayPolicyType
    {
        public int Id { get; set; }
        public string PolicyTypeCode { get; set; } = string.Empty;
        public string PolicyTypeDescrition { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
