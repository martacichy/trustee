using System;
using System.Collections.Generic;
using System.Text;

namespace BackendLibrary.Models
{
    public class EmpTaskPair
    {
        public int Employee_id { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string Email { get; set; }
        public int Task_id { get; set; }

        public EmpTaskPair(int Employee_id, string First_name, string Last_name, string Email, int Task_id)
        {
            this.Employee_id = Employee_id;
            this.First_name = First_name;
            this.Last_name = Last_name;
            this.Email = Email;
            this.Task_id = Task_id;
        }
    }
}
