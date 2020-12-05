using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Voyager.Models.Vm
{
    public class PassengerVM
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please fill required areas!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please fill required areas!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please fill required areas!")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Please fill required areas!")]
        public string Password { get; set; }



        
    }
}
