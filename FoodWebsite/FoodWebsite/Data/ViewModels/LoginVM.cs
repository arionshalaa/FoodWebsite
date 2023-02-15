using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodWebsite.Data.ViewModels
{
    public class LoginVM
    {
        [Display(Name = "Email adress")]
        [Required(ErrorMessage = "Email adress is required")]
        public string EmailAdress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
