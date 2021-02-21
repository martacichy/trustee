using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BackendLibrary.Models.Validation
{
    public class LoginValidation
    {

        [Required(ErrorMessage = "Wpisz login!")]
        [StringLength(100,
        ErrorMessage = "Login jest zbyt długi.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Wpisz hasło!")]
        [StringLength(100,
        ErrorMessage = "Hasło jest zbyt długie.")]
        public string Password { get; set; }
    }
}
