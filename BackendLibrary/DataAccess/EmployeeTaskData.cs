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
    /// <summary>
    ///  Klasa wysyłająca zapytania bazodanowe SQL dotyczące tabeli "EmployeeTask".
    /// </summary>
    public class EmployeeTaskData : SqlConnector
    {
        /// <summary> Zwraca listę wszystkich zadań danego pracownika. </summary>
        public static List<EmployeeTaskModel> GetAllLabelsByEmployeeId(int employeeId)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"SELECT * FROM database06.employeetask WHERE employee_id = {employeeId}";
                var data = connection.Query<EmployeeTaskModel>(sql).ToList();

                return data;
            }
        }

        /// <summary> Przypisuje zadanie pracownikowi. </summary>
        public static int AddEmployeeTask(EmployeeTaskModel newEmpTask)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = @"insert into database06.employeetask (employee_id, task_id)
                            values (@Employee_id, @Task_id)";

                int rowsAffected = connection.Execute(sql, newEmpTask);
                return rowsAffected;
            }
        }

        /// <summary> Odpina zadanie od pracownika. </summary>
        public static int DeleteEmployeeTask(int employee_id, int task_id)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"delete from database06.employeetask where task_id = {task_id} AND employee_id = {employee_id}";

                int rowsAffected = connection.Execute(sql);
                return rowsAffected;
            }
        }
    }
}
