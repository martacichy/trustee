﻿namespace BackendLibrary.Models
{
    /// <summary>
    /// Klasa reprezentująca parę pracownik i zadanie.
    /// </summary>
    public class EmployeeTaskModel
    {
        public int Task_id { get; set; }
        public int Employee_id { get; set; }
        public string Status { get; set; }

        public EmployeeTaskModel(int task_id, int employee_id, string status)
        {
            Task_id = task_id;
            Employee_id = employee_id;
            Status = status;
        }

        public EmployeeTaskModel(int task_id, int employee_id)
        {
            Task_id = task_id;
            Employee_id = employee_id;
        }
    }
}