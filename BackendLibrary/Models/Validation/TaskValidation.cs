using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BackendLibrary.Models.Validation
{
    public class TaskValidation
    {
        [Required(ErrorMessage = "Pole 'Tytuł' jest obowiązkowe!")]
        [StringLength(30,
        ErrorMessage = "Pole 'Tytuł' nie może mieć więcej niż 30 znaków.")]
        public string name { get; set; }


        [StringLength(500,
        ErrorMessage = "Pole 'Opis' nie może mieć więcej niż 30 znaków.")]
        public string description { get; set; }


        public DateTime start_time { get; set; }
        public DateTime deadline { get; set; }
        [StringLength(50, ErrorMessage = "Pole 'Status' nie może mieć więcej niż 50 znaków.")]
        public string status { get; set; }
        public int auto_assigned { get; set; }
    }
}
