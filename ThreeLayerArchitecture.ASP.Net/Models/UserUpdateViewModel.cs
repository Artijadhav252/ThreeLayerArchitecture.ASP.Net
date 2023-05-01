using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using ThreeLayerArchitecture.ASP.Net.DAL;

namespace ThreeLayerArchitecture.ASP.Net.Models
{
    public class UserUpdateViewModel
    {
        private User user;

        public UserUpdateViewModel(User user)
        {
            this.user = user;
        }

        public int Id { get; set; }
        
      
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

        [Required]
        public string? AdharNumber { get; set; }
        public string? Category { get; set; }

      

       
    }
}
