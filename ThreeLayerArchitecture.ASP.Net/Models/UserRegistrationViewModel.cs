using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using ThreeLayerArchitecture.ASP.Net.DAL;

namespace ThreeLayerArchitecture.ASP.Net.Models
{
    public class UserRegistrationViewModel
    {

        public UserRegistrationViewModel()
        {

        }

        public UserRegistrationViewModel(User user)
        {
            this.Id = user.Id;
            this.EmailId = user.EmailId;
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;
            this.GenderId = user.GenderId;
            //this.GenderName = user.Gender.TExt;
            this.MobileNumber = user.MobileNumber;
            this.AdharNumber = user.AdharNumber;
            this.Category = user.Category;
            this.Id = user.Id;
        }



        public int Id { get; set; }
        [Required]
        [EmailAddress]
        [Remote(action: "IsEmailIdValid", controller: "User")]
        public string? EmailId { get; set; }
        [Required]
        [Display(Name = "Fisrt Name")]
        public string? FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }

        public int? GenderId { get; set; }
        [Required]
        [RegularExpression(@"^(\+\d{1,2}\s?)?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$", ErrorMessage = "Mobile number is not valid")]
        [Display(Name = "Mobile")]
        public string? MobileNumber { get; set; }

        [StringLength(20, MinimumLength = 8)]
        public string? Password { get; set; }
        [Compare("Password", ErrorMessage = "Password & confirm Password is not correct")]
        public string? ConfirmPassword { get; set; }
        [Required]
        public string? AdharNumber { get; set; }
        public string? Category { get; set; }

        public bool TermsConditions { get; set; }

        public string? GenderName { get; set; }

        
    }
}
