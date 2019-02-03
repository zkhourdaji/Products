using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EFDbFirstApproachExample.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Username cannot be blank")]
        public string Username { get; set; }

        [Required(ErrorMessage ="Password cannot be blank")]
        public string Password { get; set; }

        [Required(ErrorMessage ="Confirm password cannot be blank")]
        [Compare("Password", ErrorMessage ="Password does not match")]
        public string ConfirmPassword { get; set; }

        [EmailAddress(ErrorMessage ="Invalid Email")]
        [Required(ErrorMessage ="Email cannot be blank")]
        public string Email { get; set; }

        [Phone]
        public string Mobile { get; set; }

        //TODO: why does the browser require me to put value in?
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

    }
}