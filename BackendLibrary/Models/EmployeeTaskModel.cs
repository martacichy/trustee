using System;
using System.Collections.Generic;
using System.Text;

namespace BackendLibrary.Models
{
    public class EmployeeTaskModel
    {
		public int Task_id { get; set; }
		public int Employee_id { get; set; }

		public EmployeeTaskModel(int task_id, int employee_id)
		{
			Task_id = task_id;
			Employee_id = employee_id;
		}
	}
}
