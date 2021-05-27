using System;
using System.Collections.Generic;
using System.Text;

namespace BackendLibrary.Models
{
    /// <summary>
    /// Klasa pomocnicza łącząca wybrane info. z modeli pracownika i projektu.
    /// </summary>
    public class EmpProjectPair
    {
        public int Employee_id { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string Email { get; set; }
        public int Project_id { get; set; }

        public EmpProjectPair(int Employee_id, string First_name, string Last_name, string Email, int Project_id)
        {
            this.Employee_id = Employee_id;
            this.First_name = First_name;
            this.Last_name = Last_name;
            this.Email = Email;
            this.Project_id = Project_id;
        }
    }
}
