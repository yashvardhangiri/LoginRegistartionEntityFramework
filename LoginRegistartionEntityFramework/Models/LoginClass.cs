using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LoginRegistartionEntityFramework.Models
{
    public class LoginClass
    {
      
            [Required(ErrorMessage = "Please Enter the Registerd Email")]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Please Enter the Password")]
            [Display(Name = "Password")]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        
    }
}
