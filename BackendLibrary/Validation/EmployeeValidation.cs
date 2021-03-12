﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace BackendLibrary.Validation
{
    /// <summary>
    /// Klasa odpowiadająca za walidację danych, czyli ich poprawne wpisanie
    /// Można korzystać przy dowolnych formularzach, dodając odp zmienne i wymagania
    /// </summary>
    public class EmployeeValidation
    {

        
        [Required(ErrorMessage = "Pole 'Imię' jest obowiązkowe.")]
        [StringLength(50,
        ErrorMessage = "To pole nie może mieć więcej niż 50 znaków.")]
        public string firstname { get; set; }

        [Required(ErrorMessage = "Pole 'Nazwisko' jest obowiązkowe.")]
        [StringLength(50,
        ErrorMessage = "To pole nie może mieć więcej niż 50 znaków.")]
        public string lastname { get; set; }

        [StringLength(50,
        ErrorMessage = "To pole nie może mieć więcej niż 50 znaków.")]
        [EmailAddress(ErrorMessage ="Wpisz poprawny email.")]
        public string email { get; set; }

        public bool ifmanager { get; set; }

        public string login { get; set; }

        public string password { get; set; }
    }
}
