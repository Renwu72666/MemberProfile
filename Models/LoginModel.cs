using System;
using System.ComponentModel.DataAnnotations;

namespace MemberProfile.Models
{
    public class LoginModel
    {
        // for login model, If the value empty, show error
        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

    }
}

