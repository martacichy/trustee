using System;
using System.ComponentModel.DataAnnotations;

namespace BackendLibrary.Validation
{
    /// <summary>
    /// Klasa odpowiadająca za walidację danych wprowadzanych do komenatarza.
    /// </summary>
    class CommentValidation
    {
        public int Comment_id { get; set; }
        public int Task_id { get; set; }
        public int Employee_id { get; set; }
        public DateTime Date { get; set; }
        
        [StringLength(1000, ErrorMessage = "To pole nie może mieć więcej niż 1000 znaków.")]
        public string Descritpion { get; set; }
    }
}
