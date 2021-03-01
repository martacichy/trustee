using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BackendLibrary.Validation
{
    public class TaskValidation
    {
        [Required(ErrorMessage = "Pole 'Tytuł' jest obowiązkowe!")]
        [StringLength(30,
        ErrorMessage = "Pole 'Tytuł' nie może mieć więcej niż 30 znaków.")]
        public string name { get; set; }

        [Required(ErrorMessage = "Pole 'Opis' jest obowiązkowe!")]
        [StringLength(500,
        ErrorMessage = "Pole 'Opis' nie może mieć więcej niż 30 znaków.")]
        public string description { get; set; }


        public DateTime start_time { get; set; }
        public DateTime deadline { get; set; }
        
        [Required(ErrorMessage = "Pole 'Status' jest obowiązkowe!")]
        [StringLength(50, ErrorMessage = "Pole 'Status' nie może mieć więcej niż 50 znaków.")]
        public string status { get; set; }
        
        public int auto_assigned { get; set; }
    }
}
