using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BackendLibrary.Models
{
    public class EmployeeModel
    {	
		public int Employee_id { get; set; }
		public int Company_id { get; set; }
		public string First_name { get; set; }
		public string Last_name { get; set; }
		public string Email { get; set; }
		public int If_manager { get; set; }
		public string Login { get; set; }
		public string Password { get; set; }


		public EmployeeModel(int company_id, string first_name, string last_name,
					string email, int if_manager, string login, string password)
		{
			Company_id = company_id;
			First_name = first_name;
			Last_name = last_name;
			Email = email;
			If_manager = if_manager;
			Login = login;
			Password = password;
		}

		public EmployeeModel(int employee_id, int company_id, string first_name, string last_name,
							string email, int if_manager, string login, string password)
		{
			Employee_id = employee_id;
			Company_id = company_id;
			First_name = first_name;
			Last_name = last_name;
			Email = email;
			If_manager = if_manager;
			Login = login;
			Password = password;
		}

		public EmployeeModel() { }
	}
}
