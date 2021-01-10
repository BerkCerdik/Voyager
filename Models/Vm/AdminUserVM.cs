using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Voyager.Models.Vm
{
    public class AdminUserVM
    {
        public int ID { get; set; }

        [Required(ErrorMessage="E-Mail alanı boş geçilemez!")]
        public string EMail { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        [Required(ErrorMessage = "Şifre alanı boş geçilemez!")]
        public string Password { get; set; }


        [Required(ErrorMessage = "Şifre tekrar boş geçilemez!")]
        [Compare("Password",ErrorMessage ="Şifreler Uyuşmuyor!")]
        [Display(Name="Şifre Tekrar")]
        public string ConfirmPassword { get; set; }
        public string Roles { get; set; }
    }
}
