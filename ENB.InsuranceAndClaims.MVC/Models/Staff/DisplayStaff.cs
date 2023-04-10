using ENB.InsuranceAndClaims.Entities;
using ENB.InsuranceAndClaims.Entities.Collections;
using System.ComponentModel.DataAnnotations;

namespace ENB.InsuranceAndClaims.MVC.Models
{
    public class DisplayStaff
    {
        #region "Public Properties"

        public int Id { get; set; }
        public string FirstName { get; set; }=string.Empty;

       
        public string LastName { get; set; }=string.Empty;

        public string EmailAddress { get; set; } = String.Empty;

        public Gender Gender { get; set; }
        public string PhoneNumber { get; set; } = String.Empty;


        [Display(Name = "Date of birth")]
        [DisplayFormat(DataFormatString = "{0: MM/dd/yyyy}")]
        public DateTime DateOfBirth
        {
            get;
            set;
        }
       
        
        public string FullName { get; set; }=string.Empty;
       

        public string Other_details { get; set; } = string.Empty;
        #endregion

    }
}
