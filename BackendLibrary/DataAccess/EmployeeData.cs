using BackendLibrary.Models;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendLibrary.DataAccess {
    /// <summary>
    ///  Klasa wysyłająca zapytania bazodanowe SQL dotyczące tabeli "Employee".
    /// </summary>
    public class EmployeeData : SqlConnector {
    
        /// <summary> Zwraca listę wszystkich pracownikow. </summary>
        public static List<EmployeeModel> GetAllEmployees() {
            using (IDbConnection connection = new MySqlConnection(connectionString)) {
                string sql = "SELECT * FROM database06.employee";
                var data = connection.Query<EmployeeModel>(sql).ToList();

                return data;
            }
        }
        /// <summary> Dodaje nowego pracownika. </summary>
        public static void AddEmployee(EmployeeModel newEmployee) {
            using (IDbConnection connection = new MySqlConnection(connectionString)) {
                
                string sql = @"insert into database06.employee (Company_id, First_name, Last_name, Email, If_manager)
                            values (@Company_id, @First_name, @Last_name, @Email, @If_manager)";
                
                connection.Execute(sql, newEmployee);
                  
            }
        }
    }
}

