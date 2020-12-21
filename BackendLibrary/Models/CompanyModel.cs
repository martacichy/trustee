using System;
using System.Collections.Generic;
using System.Text;

namespace BackendLibrary.Models
{
    public class CompanyModel
    {
		public int Company_id { get; set; }
		public string Name { get; set; }
		public DateTime Creation_date { get; set; }

		public CompanyModel(int company_id, string name, DateTime creation_date)
		{
			Company_id = company_id;
			Name = name;
			Creation_date = creation_date;
		}
	}
}
