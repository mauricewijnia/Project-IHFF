using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Project_IHFF.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Fill in your first name")]
        [Display(Name = "First Name")]
        public string firstName { get; set; }

        [Required(ErrorMessage = "Fill in your last name")]
        [Display(Name = "Last Name")]
        public string lastName { get; set; }

        [Required(ErrorMessage = "Fill in your phonenumber")]
        [Display(Name = "Phone number")]
        public string phoneNumber { get; set; }

        [Required(ErrorMessage = "Fill in your emailadress")]
        [Display(Name = "Emailaddress")]
        public string email { get; set; }

        [Required(ErrorMessage = "Fill in your desired password")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Repeat Password")]
        [Compare("Password", ErrorMessage = "The passwords you filled in do not match")]
        public string ConfirmPassword { get; set; }

        public RegisterModel()
        {

        }

        public RegisterModel(string firstName, string lastName, string phoneNumber, string email, string password)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.phoneNumber = phoneNumber;
            this.email = email;
            this.Password = password;
        }
    }
}