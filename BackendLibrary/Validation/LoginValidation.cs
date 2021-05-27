using System.ComponentModel.DataAnnotations;

namespace BackendLibrary.Validation
{
    /// <summary>
    /// Klasa odpowiadająca za walidację danych wporwadzanych przy logowaniu.
    /// </summary>
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