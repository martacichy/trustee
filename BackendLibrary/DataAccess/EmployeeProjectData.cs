using BackendLibrary.Models;
using Dapper;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BackendLibrary.DataAccess
{
    /// <summary>
    ///  Klasa wysyłająca zapytania bazodanowe SQL dotyczące tabeli "EmployeeProject".
    /// </summary>
    public class EmployeeProjectData : SqlConnector
    {
        /// <summary> Zwraca listę wszystkich par pracownik-projekt. </summary>
        public static List<EmployeeProjectModel> GetAll()
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = "SELECT * FROM database06.employeeproject";
                var data = connection.Query<EmployeeProjectModel>(sql).ToList();

                return data;
            }
        }

        /// <summary> Zwraca listę wszystkich powiązań projektów z danym ID pracownika. </summary>
        public static List<EmployeeProjectModel> GetAllByEmployeeId(int employeeId)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"SELECT * FROM database06.employeeproject WHERE employee_id = {employeeId}";
                var data = connection.Query<EmployeeProjectModel>(sql).ToList();

                return data;
            }
        }

        /// <summary> Zwraca listę wszystkich powiązań pracowników z danym ID projektu. </summary>
        public static List<EmployeeProjectModel> GetAllByProjectId(int projectId)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"SELECT * FROM database06.employeeproject WHERE project_id = {projectId}";
                var data = connection.Query<EmployeeProjectModel>(sql).ToList();

                return data;
            }
        }

        /// <summary> Dodaje pracownika do projektu. </summary>
        public static void AddEmployeeProject(EmployeeProjectModel newEmpProject)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = @"insert into database06.employeeproject (project_id, employee_id)
                            values (@Project_id, @Employee_id)";

                connection.Execute(sql, newEmpProject);
            }
        }

        /// <summary> Usuwa konkretne przypisanie pracownika do projektu. </summary>
        public static int DeleteEmployeeProject(int employee_id, int project_id)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"delete from database06.employeeproject where employee_id = {employee_id} AND project_id = {project_id}";

                int rowsAffected = connection.Execute(sql);
                return rowsAffected;
            }
        }
    }
}