using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BackendLibrary.Validation
{
    public class EditTaskValidation
    {
        [StringLength(30,
        ErrorMessage = "Pole 'Tytuł' nie może mieć więcej niż 30 znaków.")]
        public string name { get; set; }


        [StringLength(500,
        ErrorMessage = "Pole 'Opis' nie może mieć więcej niż 500 znaków.")]
        public string description { get; set; }


        public DateTime start_time { get; set; }

        public DateTime deadline { get; set; }

        [StringLength(50, ErrorMessage = "Pole 'Status' nie może mieć więcej niż 50 znaków.")]
        public string status { get; set; }

        public int auto_assigned { get; set; }

        public int project_id { get; set; }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class DateDeadlineAttributeEdit : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return (DateTime)value >= DateTime.Today;
        }
    }
}
