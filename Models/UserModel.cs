using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Demo.Models
{
    public class UserModel
    {

        public int UserId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name is Required")]
        [Display(Name = "First Name : ")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Last Name is Required")]
        [Display(Name = "Last Name : ")]
        public string LasttName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is Required")]
        [Display(Name = "Email : ")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password : ")]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Confirm Password is Required")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password : ")]
        [Compare("Password",ErrorMessage = " Password and Confirm Password Should be same")]

        public string ConfirmPassword { get; set; }

        public string CreatedOn { get; set; }

        public string Message { get; set;   }


    }
}