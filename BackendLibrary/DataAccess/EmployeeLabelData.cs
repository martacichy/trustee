using BackendLibrary.Models;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;

namespace BackendLibrary.DataAccess
{
    /// <summary>
    ///  Klasa wysyłająca zapytania bazodanowe SQL dotyczące tabeli "EmployeeLabel".
    /// </summary>
    public class EmployeeLabelData : SqlConnector
    {
        /// <summary> Zwraca listę wszystkich etykiet danego pracownika 
        /// (szukając po id pracownika). </summary>
        public static List<EmployeeLabelModel> GetAllLabelsByEmployeeId(int employeeId)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"SELECT * FROM database06.employeelabel WHERE employee_id = {employeeId}";
                var data = connection.Query<EmployeeLabelModel>(sql).ToList();

                return data;
            }
        }

        /// <summary> Dodaje nową etykietę pracownikowi. </summary>
        public static void AddEmployeeLabel(EmployeeLabelModel newEmpLabel)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = @"insert into database06.employeelabel (employee_id, label_id)
                            values (@Employee_id, @Label_id)";

                connection.Execute(sql, newEmpLabel);
            }
        }

        /// <summary> Usuwa konkretną etykietę pracownika. </summary>
        public static int DeleteEmployeeLabel(int employee_id, int label_id)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"delete from database06.employeelabel where employee_id = {employee_id} AND label_id = {label_id}";

                int rowsAffected = connection.Execute(sql);
                return rowsAffected;
            }
        }
    }
}
