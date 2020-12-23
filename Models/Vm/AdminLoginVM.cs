using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Voyager.Models.Vm
{
    public class AdminLoginVM
    {
        [Required(ErrorMessage = "E-Mail alanı boş geçilemez!")]
        public string EMail { get; set; }
        [Required(ErrorMessage = "Şifre alanı boş geçilemez!")]
        public string Password { get; set; }


    }
}
