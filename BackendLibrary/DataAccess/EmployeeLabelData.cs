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
    class EmployeeLabelData : SqlConnector
    {
        /// <summary> Dodaje nową etykietę pracownikowi. </summary>
        public static void AddEmployeeLabel(EmployeeLabelData newEmpLabel)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = @"insert into database06.employeelabel (employee_id, label_id)
                            values (@employee_id, @label_id)";

                connection.Execute(sql, newEmpLabel);
            }
        }

    }
}
