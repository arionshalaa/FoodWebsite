using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodWebsite.Data.ViewModels
{
    public class RegisterVM
    {
        [Display(Name = "Full name")]
        [Required(ErrorMessage = "Full name is required")]
        public string FullName { get; set; }

        [Display(Name = "Email adress")]
        [Required(ErrorMessage = "Email adress is required")]
        public string EmailAdress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm password")]
        [Required(ErrorMessage ="Confirmed password is required.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Passwords do not match.")]
        public string ConfirmPassword { get; set; }

    }
}
