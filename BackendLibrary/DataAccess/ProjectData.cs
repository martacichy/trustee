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
    ///  Klasa wysyłająca zapytania bazodanowe SQL dotyczące tabeli "LabelType".
    /// </summary>
    public class ProjectData : SqlConnector
    {
        /// <summary> Zwraca listę wszystkich projektów. </summary>
        public static List<ProjectModel> GetAll()
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = "SELECT * FROM database06.project";
                var data = connection.Query<ProjectModel>(sql).ToList();

                return data;
            }
        }

        /// <summary> Zwraca projekt o danym ID. </summary>
        public static ProjectModel GetById(int project_id)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"SELECT * FROM database06.project WHERE project_id = {project_id}";
                var data = connection.Query<ProjectModel>(sql).FirstOrDefault();

                return data;
            }
        }
        /// <summary> Zwraca projekt o danym ID zadania. </summary>
        public static ProjectModel GetByTaskId(int task_id)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"SELECT * FROM database06.project WHERE project_id IN (select project_id from database06.task where task_id = {task_id})";
                var data = connection.Query<ProjectModel>(sql).FirstOrDefault();

                return data;
            }
        }
        /// <summary> Zwraca nazwę projektu o danym ID. </summary>
        public static string GetNameById(int project_id)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"SELECT name FROM database06.project WHERE project_id = {project_id}";
                var data = connection.Query<string>(sql).FirstOrDefault();

                return data;
            }

        }
        /// <summary> Zwraca ID projektu o danej nazwie. </summary>
        public static int GetIdByName(String name)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"SELECT project_id from database06.project WHERE name = '{name}'";
                int id = connection.Query<int>(sql).First();

                return id;
            }
        }


        /// <summary> Zwraca autowygenerowane ID w ostatnio wykonanym insercie.</summary>
        public static int GetMaxId()
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"SELECT max(project_id) from database06.project";
                int id = connection.Query<int>(sql).First();

                return id;
            }
        }

        /// <summary> Zwraca listę wszystkich projektów firmy o danym ID. </summary>
        public static List<ProjectModel> GetAllByCompanyId(int company_id)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"SELECT * FROM database06.project where Company_id = {company_id}";
                var data = connection.Query<ProjectModel>(sql).ToList();

                return data;
            }
        }

        /// <summary> Dodaje nowy projekt. </summary>
        public static void AddProject(ProjectModel newProject)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = @"insert into database06.project (company_id, name)
                            values (@Company_id, @Name)";

                connection.Execute(sql, newProject);
            }
        }

        /// <summary> Usuwa projekt z bazy danych,
        /// zmieniając wcześniej wiersze z tabeli Task, gdzie zawarty jest dany klucz obcy na wartość NULL </summary>
        public static int DeleteProject(int project_id)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"update database06.task set project_id = NULL where project_id = {project_id}";
                connection.Execute(sql);

                sql = $"delete from database06.project where project_id = {project_id}";
                int RowsAffected = connection.Execute(sql);

                return RowsAffected;
            }
        }
    }
}