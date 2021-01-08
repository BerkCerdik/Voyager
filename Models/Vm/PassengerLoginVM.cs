using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Voyager.Models.Vm
{
    public class PassengerLoginVM
    {
        
        [Required(ErrorMessage = "Please fill required areas!")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please fill required areas!")]
        [Display(Name = "Password")]
        public string Password { get; set; }
        
    }
}
