using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Voyager.Models.Vm
{
    public class PassengerLoginVM
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please fill required areas!")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please fill required areas!")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please fill required areas!")]
        [Display(Name = "Lastname")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Please fill required areas!")]
        [Display(Name = "Password")]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "Please fill required areas!")]
        [Compare("Password", ErrorMessage = "Passwords do not match!")]
        [Display(Name = "Re-Password")]
        public string Confirmpassword { get; set; }

    }
}
