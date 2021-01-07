using BackendLibrary.Models;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendLibrary.DataAccess
{
    public class EmployeeLabelData : SqlConnector
    {
        public static void DeleteEmployeeLabel(EmployeeLabelModel oldEmployeeLabel)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = @"delete from database06.employeelabel Where label_id = @label_id AND employee_id = @employee_id";

                connection.Execute(sql, oldEmployeeLabel);
            }
        }
    }
}
