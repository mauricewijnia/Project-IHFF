using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project_IHFF.Models
{
    public class LoginModel
    {

        [Required(ErrorMessage = "Fill in your emailadress")]
        [Display(Name = "Emailaddress")]
        public string email { get; set; }

        [Required(ErrorMessage = "Fill in your password")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string password { get; set; }

        public LoginModel()
        {

        }

        public LoginModel(string email, string password)
        {
            this.email = email;
            this.password = password;
        }
    }
}