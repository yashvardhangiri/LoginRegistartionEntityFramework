using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LoginRegistartionEntityFramework.Models
{
    public class NewUserClass
    {
       [Required(ErrorMessage = "Please Enter Your Name")]
       [Display(Name ="Name")]

        public string UserName { get; set; }

        [Required(ErrorMessage = "Please Enter Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Passeord")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string PasswordHash { get; set; }

        [Required(ErrorMessage = "Please Enter Confirm-Password")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("PasswordHash")]
        public string UserConPass { get; set; }
    }
}
