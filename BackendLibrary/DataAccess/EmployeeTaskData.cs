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
    public class EmployeeTaskData : SqlConnector
    {
        // usuwa przypisanie pracownika do zadania
        public static void DeleteTaskModel(EmployeeTaskModel oldEmployeeTask)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = @"delete from database06.employeetask Where task_id = @task_id AND employee_id = @employee_id";

                connection.Execute(sql, oldEmployeeTask);
            }
        }
    }
}
