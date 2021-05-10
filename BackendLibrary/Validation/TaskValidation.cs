﻿using System;
using System.ComponentModel.DataAnnotations;

namespace BackendLibrary.Validation
{
    public class TaskValidation
    {
        [Required(ErrorMessage = "To pole jest obowiązkowe!")]
        [StringLength(30,
        ErrorMessage = "To pole nie może mieć więcej niż 30 znaków.")]
        public string name { get; set; }

        [Required(ErrorMessage = "To pole jest obowiązkowe!")]
        [StringLength(500,
        ErrorMessage = "To pole nie może mieć więcej niż 500 znaków.")]
        public string description { get; set; }

        [DefaultDateAttribute(ErrorMessage = "Wprowadź poprawną datę rozpoczęcia.")]
        public DateTime start_time { get; set; } = DateTime.Now;

        [DateDeadlineAttribute(ErrorMessage = "Deadline nie może być wcześniejszy niż dzisiaj.")]
        public DateTime deadline { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "To pole jest obowiązkowe!")]
        [StringLength(50, ErrorMessage = "To pole nie może mieć więcej niż 50 znaków.")]
        public string status { get; set; } = "Nierozpoczęte";

        public int auto_assigned { get; set; }

        public int project_id { get; set; }

        [RegularExpression(@"^[a-zA-ZĄĆĘŁŃÓŚŹŻąćęłńóśźż]*$", ErrorMessage = "Dodając etykiete możesz używać tylko liter i cyfr!")]
        public string SelectedLabel { get; set; }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class DateDeadlineAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return (DateTime)value >= DateTime.Today;
        }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class DefaultDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return (DateTime)value >= DateTime.Today;
        }
    }
}