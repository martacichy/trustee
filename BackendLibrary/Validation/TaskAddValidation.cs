using System;
using System.ComponentModel.DataAnnotations;

namespace BackendLibrary.Validation
{
    /// <summary>
    /// Klasa odpowiadająca za walidację danych wprowadzanych podczas dodawania zadania.
    /// </summary>
    public class TaskAddValidation
    {
        [Required(ErrorMessage = "To pole jest obowiązkowe!")]
        [StringLength(50,
        ErrorMessage = "To pole nie może mieć więcej niż 50 znaków.")]
        public string name { get; set; }

        [Required(ErrorMessage = "To pole jest obowiązkowe!")]
        [StringLength(500,
        ErrorMessage = "To pole nie może mieć więcej niż 500 znaków.")]
        public string description { get; set; }

        [DefaultDate(ErrorMessage = "Wprowadź poprawną datę rozpoczęcia.")]
        public DateTime start_time { get; set; } = DateTime.Now;

        [DateDeadline(ErrorMessage = "Wprowadź poprawną datę zakończenia.")]
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
            return (DateTime)value >= DateTime.MinValue;
        }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class DefaultDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return (DateTime)value >= DateTime.MinValue;
        }
    }
}