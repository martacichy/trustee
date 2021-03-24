using BackendLibrary.Models;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BackendLibrary.DataAccess
{
    /// <summary>
    ///  Klasa wysyłająca zapytania bazodanowe SQL dotyczące tabeli "Employee".
    /// </summary>
    public class EmployeeData : SqlConnector
    {
        /// <summary> Zwraca listę wszystkich pracownikow. </summary>
        public static List<EmployeeModel> GetAll()
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = "SELECT * FROM database06.employee";
                var data = connection.Query<EmployeeModel>(sql).ToList();

                return data;
            }
        }

        /// <summary>
        /// Zwraca pracownika. Jeśli hasło/login jest niepoprawny - zwraca obiekt z polem If_manager = -1.
        /// </summary>
        public static EmployeeModel LoginEmployee(string login, string password)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                var sql = $"SELECT * FROM database06.employee WHERE login = '{login}' and password = '{password}'";
                try
                {
                    var output = connection.Query<EmployeeModel>(sql).First();
                    return output;
                }
                catch (Exception)
                {
                    EmployeeModel errorEmployee = new EmployeeModel(-1);

                    return errorEmployee;
                }
            }
        }

        /// <summary> Przypisuje dane id firmy danemu pracownikowi. </summary>
        public static Boolean SetCompanyForEmployee(int employeeId, int companyId)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"UPDATE database06.employee SET company_id = {companyId} WHERE employee_id = {employeeId}";
                int rowsAffected = connection.Execute(sql);

                if (rowsAffected == 0)
                    return false;
                else
                    return true;
            }
        }

        /// <summary> Zwraca model o przekazanym w argumencie id. </summary>
        public static EmployeeModel GetById(int employee_id)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"SELECT * FROM database06.employee WHERE Employee_id = {employee_id}";
                var data = connection.Query<EmployeeModel>(sql).FirstOrDefault();

                return data;
            }
        }

        /// <summary> Zwraca id pracownika o podanym mailu. </summary>
        public static int GetIdByEmail(string email)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"SELECT Employee_id from database06.employee where email = '{email}'";
                int id = connection.Query<int>(sql).FirstOrDefault();

                return id;
            }
        }

        /// <summary> Zwraca listę wszystkich pracownikow danej firmy. </summary>
        public static List<EmployeeModel> GetAllByCompanyId(int company_id)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"SELECT * FROM database06.employee where Company_id = {company_id}";
                var data = connection.Query<EmployeeModel>(sql).ToList();

                return data;
            }
        }

        /// <summary> Zwraca autowygenerowane Id w ostatnio wykonanym insercie.</summary>
        public static int GetMaxId()
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"SELECT max(employee_id) from database06.employee";
                int id = connection.Query<int>(sql).First();

                return id;
            }
        }

        /// <summary> Dodaje nowego pracownika. </summary>
        public static void AddEmployee(EmployeeModel newEmployee)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = @"insert into database06.employee (Company_id, First_name, Last_name,
                            Email, If_manager, Login, Password) values (@Company_id, @First_name,
                            @Last_name, @Email, @If_manager, @Login, @Password)";

                connection.Execute(sql, newEmployee);
            }
        }

        /// <summary> Usuwa pracownika z bazy danych,
        /// usuwając wcześniej wiersze z innych tabel, gdzie zawarty jest dany klucz obcy z tabeli Employee
        /// </summary>
        public static int DeleteEmployee(int employee_id)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"delete from database06.employeetask Where employee_id = {employee_id}";

                connection.Execute(sql);

                sql = $"delete from database06.employeelabel Where employee_id = {employee_id}";

                connection.Execute(sql);

                sql = $"delete from database06.employee Where employee_id = {employee_id}";

                int RowsAffected = connection.Execute(sql);
                return RowsAffected;
            }
        }
    }
}