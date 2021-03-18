using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BackendLibrary.Models
{
    public class CompanyModel
    {
        public int Company_id { get; set; }
        public string Name { get; set; }
        public DateTime Creation_date { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public CompanyModel(string name, DateTime creation_date, string login, string password)
        {
            Name = name;
            Creation_date = creation_date;
            Login = login;
            Password = password;
        }

        public CompanyModel(int company_id, string name, DateTime creation_date, string login, string password)
        {
            Company_id = company_id;
            Name = name;
            Creation_date = creation_date;
            Login = login;
            Password = password;
        }

        public CompanyModel()
        {

        }
    }
}