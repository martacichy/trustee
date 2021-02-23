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

        /// <summary> Zwraca pole if_manager, jesli login i haslo nie pasuja zwraca -1. </summary>
        public static int GetIfManagerValue(string login, string password)
        {
            var parameters = new { Login = login, Password = password };
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                var sql = $"SELECT if_manager FROM database06.employee WHERE login = @Login and password = @Password";
                try
                {
                    int if_manager = connection.QueryFirst<int>(sql, parameters);
                    return if_manager;
                }
                catch (Exception)
                {
                    return -1;
                }
            }
        }

        /// <summary> zwraca pole company_id, jeśli login i haslo nie pasuja zwraca -1 </summary>
        public static int GetCompany_IdValue(string login, string password)
        {
            var parameters = new { Login = login, Password = password };
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                var sql = $"SELECT company_id FROM database06.employee WHERE login = @Login and password = @Password";
                try
                {
                    int company_id = connection.QueryFirst<int>(sql, parameters);
                    return company_id;
                }
                catch (Exception)
                {
                    return -1;
                }
            }
        }

        /// <summary> zwraca imie pracownika, jesli login i haslo nie pasuja zwraca default_firstname </summary>
        public static string GetFirstNameValue(string login, string password)
        {
            var parameters = new { Login = login, Password = password };
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                var sql = $"SELECT first_name FROM database06.employee WHERE login = @Login and password = @Password";
                try
                {
                    string first_name = connection.QueryFirst<string>(sql, parameters);
                    return first_name;
                }
                catch (Exception)
                {
                    return "forbidden_FirstName";
                }
            }
        }
        /// <summary> zwraca nazwisko pracownika, jesli login i haslo nie pasuja zwraca default_lastname </summary>
        public static string GetLastNameValue(string login, string password)
        {
            var parameters = new { Login = login, Password = password };
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                var sql = $"SELECT last_name FROM database06.employee WHERE login = @Login and password = @Password";
                try
                {
                    string last_name = connection.QueryFirst<string>(sql, parameters);
                    return last_name;
                }
                catch (Exception)
                {
                    return "forbidden_LastName";
                }
            }
        }
        /// <summary> zrwaca mejl pracownika, jesli login i haslo sie nie zgadzaja zwraca default_mail </summary>
        public static string GetEmailValue(string login, string password)
        {
            var parameters = new { Login = login, Password = password };
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                var sql = $"SELECT email FROM database06.employee WHERE login = @Login and password = @Password";
                try
                {
                    string last_name = connection.QueryFirst<string>(sql, parameters);
                    return last_name;
                }
                catch (Exception)
                {
                    return "forbidden_mail";
                }
            }
        }

        public static string GetLoginValue(string login, string password)
        {
            var parameters = new { Login = login, Password = password };
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                var sql = $"SELECT login FROM database06.employee WHERE login = @Login and password = @Password";
                try
                {
                    string login_f = connection.QueryFirst<string>(sql, parameters);
                    return login_f;
                }
                catch (Exception)
                {
                    return "forbidden_login";
                }
            }
        }

        public static string GetPasswordValue(string login, string password)
        {
            var parameters = new { Login = login, Password = password };
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                var sql = $"SELECT password FROM database06.employee WHERE login = @Login and password = @Password";
                try
                {
                    string password_f = connection.QueryFirst<string>(sql, parameters);
                    return password_f;
                }
                catch (Exception)
                {
                    return "forbidden_password";
                }
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
                string sql = "SELECT max(employee_id) from database06.employee";
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