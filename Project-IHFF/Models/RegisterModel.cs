using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Project_IHFF.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "First Name is required")]
        [Display(Name = "First Name")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Use letters only.")]
        [StringLength(30)]
        public string firstName { get; set; }
    
        [Required(ErrorMessage = "Last Name is required")]
        [Display(Name = "Last Name")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Use letters only.")]
        [StringLength(30)]
        public string lastName { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [Display(Name = "Phone Number")]
        [RegularExpression(@"^([0-9\(\)\/\+ \-]*)$", ErrorMessage = "Enter a valid phone number.")]
        [StringLength(20)]
        public string phoneNumber { get; set; }

        [Required(ErrorMessage = "Email Adress is required")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Email address is is not valid.")]
        [Display(Name = "Email Address")]
        [StringLength(254)]
        public string email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [StringLength(255, ErrorMessage = "Password must be between 4 and 255 characters.", MinimumLength = 4)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Repeat Password is required.")]
        [DataType(DataType.Password)]
        [Display(Name = "Repeat Password")]
        [Compare("Password", ErrorMessage = "The passwords you filled in do not match.")]
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