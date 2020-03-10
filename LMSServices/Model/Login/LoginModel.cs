using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Services
{
    public class LoginModel
    {
        [Required]
        public string UserName { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, DataType(DataType.Password), Compare("Password")]
        public string ConfirmPassword { get; set; }
        [Required]
        public bool AgreedToTerms { get; set; }
    }
}
