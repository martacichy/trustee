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
        public static List<EmployeeModel> GetAll()
        {
            using (IDbConnection connection = new MySqlConnection(connectionString)) {
                string sql = "SELECT * FROM database06.employee";
                var data = connection.Query<EmployeeModel>(sql).ToList();

                return data;
            }
        }
        /// <summary> Zwraca pole if_manager, jesli login i haslo nie pasuja zwraca -1. </summary>
        public static int GetIfManagerValue(string login, string password) 
        {
            var parameters = new { Login = login, Password = password };
            using (IDbConnection connection = new MySqlConnection(connectionString)) {
                var sql = $"SELECT if_manager FROM database06.employee WHERE login = @Login and password = @Password";
                try {
                    int if_manager = connection.QueryFirst<int>(sql, parameters);
                    return if_manager;  
                 } catch(Exception e) {
                      return -1;
                  }
            }
        }

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
                catch (Exception e)
                {
                    return -1;
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
            using (IDbConnection connection = new MySqlConnection(connectionString)) {
                
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

