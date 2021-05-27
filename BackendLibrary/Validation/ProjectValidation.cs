using System.ComponentModel.DataAnnotations;

namespace BackendLibrary.Validation
{
    /// <summary>
    /// Klasa odpowiadająca za walidację danych wprowadzanych do projektu.
    /// </summary>
    public class ProjectValidation
    {
        [Required(ErrorMessage = "Pole 'Nazwa' jest obowiązkowe.")]
        [StringLength(200,
        ErrorMessage = "To pole nie może mieć więcej niż 200 znaków.")]
        public string Name { get; set; }

        public int Project_id { get; set; }

        public int Company_id { get; set; }
    }
}