using System;
using System.Collections.Generic;
using System.Text;

namespace BackendLibrary.Models
{
    class EmployeeModel
    {
		public int Employee_id { get; set; }
		public int Company_id { get; set; }
		public string First_name { get; set; }
		public string Last_name { get; set; }
		public string Email { get; set; }
		public byte If_manager { get; set; }

		public EmployeeModel(int employee_id, int company_id, string first_name, string last_name, string email, byte if_manager)
		{
			Employee_id = employee_id;
			Company_id = company_id;
			First_name = first_name;
			Last_name = last_name;
			Email = email;
			If_manager = if_manager;
		}
	}
}
