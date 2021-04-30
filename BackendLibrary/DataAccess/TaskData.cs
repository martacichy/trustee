using BackendLibrary.Models;
using Dapper;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BackendLibrary.DataAccess
{
    /// <summary>
    ///  Klasa wysyłająca zapytania bazodanowe SQL dotyczące tabeli "task".
    /// </summary>
    public class TaskData : SqlConnector
    {
        /// <summary> Zwraca listę wszystkich tasków. </summary>
        public static List<TaskModel> GetAllTasks()
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = "SELECT * FROM database06.task";
                var data = connection.Query<TaskModel>(sql).ToList();

                return data;
            }
        }

        public static List<TaskModel> GetUnstartedTasksByCompanyId(int company_id)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"SELECT database06.task.* FROM database06.task " +
                    $"WHERE database06.task.task_id NOT IN" +
                             $"(SELECT database06.employeetask.task_id FROM database06.employeetask)" +
                    $" AND database06.task.status = 'Nierozpoczęte' AND database06.task.company_id = {company_id}";
                var data = connection.Query<TaskModel>(sql).ToList();

                return data;
            }
        }

        public static List<TaskModel> GetInProgressTasks(int company_id)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"SELECT * FROM database06.task WHERE (status='W toku' OR status = 'Nierozpoczęte') AND Company_id = {company_id}";
                var data = connection.Query<TaskModel>(sql).ToList();

                return data;
            }
        }

        public static List<TaskModel> GetAllTaskWithoutUnstartedByCompanyId(int company_id)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"SELECT * FROM database06.task WHERE status!='Nierozpoczęte' AND Company_id = {company_id}";
                var data = connection.Query<TaskModel>(sql).ToList();

                return data;
            }
        }



        /// <summary> Zwraca model o przekazanym w argumencie id. </summary>
        public static TaskModel GetById(int task_id)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"SELECT * FROM database06.task WHERE Task_id = {task_id}";
                var data = connection.Query<TaskModel>(sql).FirstOrDefault();

                return data;
            }
        }

        /// <summary>
        /// Zwraca jednoelementowa liste, zawierajaca jeden task, zgodny z przekazanym ID,
        /// funkcja stworzona specjalnie do szczegolow zadania.
        /// </summary>
        public static List<TaskModel> GetByIdList(int task_id)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"SELECT * FROM database06.task WHERE Task_id = {task_id}";
                var data = connection.Query<TaskModel>(sql).ToList();

                return data;
            }
        }

        /// <summary> Zwraca autowygenerowane Id w ostatnio wykonanym insercie.</summary>
        public static int GetMaxId()
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"SELECT max(Task_id) from database06.task";
                int id = connection.Query<int>(sql).First();

                return id;
            }
        }

        /// <summary> Zwraca listę wszystkich tasków danej firmy. </summary>
        public static List<TaskModel> GetAllByCompanyId(int company_id)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"select * from database06.task where Company_id = {company_id}";
                var data = connection.Query<TaskModel>(sql).ToList();

                return data;
            }
        }

        /// <summary> Zwraca listę wszystkich tasków danego pracownika. </summary>
        public static List<TaskModel> GetAllByEmployeeId(int employee_id)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"SELECT database06.task.* FROM database06.task JOIN database06.employeetask ON database06.task.task_id = " +
                    $"database06.employeetask.task_id WHERE database06.employeetask.employee_id = {employee_id} ";
                var data = connection.Query<TaskModel>(sql).ToList();

                return data;
            }
        }

        public static List<TaskModel> GetInProgressTaskByEmployeeId(int employee_id)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"SELECT database06.task.* FROM database06.task JOIN database06.employeetask ON database06.task.task_id = " +
                    $"database06.employeetask.task_id WHERE database06.employeetask.employee_id = {employee_id} AND" +
                    $" (database06.task.status = 'W toku' OR database06.task.status = 'Nierozpoczęte') ";
                var data = connection.Query<TaskModel>(sql).ToList();

                return data;
            }
        }



        /// <summary> Dodaje nowego taska. </summary>
        public static void AddTask(TaskModel newTask)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql;
                if (newTask.Project_id >= 0)
                {
                    sql = @"insert into database06.task (Company_id, Name, Description, Start_time, Deadline, Status, Auto_assigned, Project_id)
                            values (@Company_id, @Name, @Description, @Start_time, @Deadline, @Status, @Auto_assigned, @Project_id)";
                }
                else // gdy zadanie nie ma przypisanego projektu, pole project_id < 0
                {
                    sql = @"insert into database06.task (Company_id, Name, Description, Start_time, Deadline, Status, Auto_assigned)
                            values (@Company_id, @Name, @Description, @Start_time, @Deadline, @Status, @Auto_assigned)";
                }

                connection.Execute(sql, newTask);
            }
        }

        /// <summary> Aktualizuje wybranego taska o nowe wartosci. </summary>
        public static void UpdateTask(TaskModel updatedTask)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql;
                if (updatedTask.Project_id >= 0)
                {
                    sql = @"UPDATE database06.task SET Name = @Name, Description = @Description, Start_time = @Start_time,
                            Deadline = @Deadline, Status = @Status, Auto_assigned = @Auto_assigned, Project_id = @Project_id
                            WHERE task_id = @Task_id";
                }
                else // gdy zadanie nie ma przypisanego projektu, pole project_id < 0
                {
                    sql = @"UPDATE database06.task SET Name = @Name, Description = @Description, Start_time = @Start_time,
                            Deadline = @Deadline, Status = @Status, Auto_assigned = @Auto_assigned, Project_id = null
                            WHERE task_id = @Task_id";
                }

                connection.Execute(sql, updatedTask);
            }
        }

        /// <summary> Usuwa zadanie z bazy danych,
        /// usuwając wcześniej wiersze z innych tabel, gdzie zawarty jest dany klucz obcy z tabeli Task
        /// </summary>
        public static int DeleteTask(int task_id)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"delete from database06.comment Where task_id = {task_id}";

                connection.Execute(sql);

                sql = $"delete from database06.employeetask Where task_id = {task_id}";

                connection.Execute(sql);

                sql = $"delete from database06.tasklabel Where task_id = {task_id}";

                connection.Execute(sql);

                sql = $"delete from database06.task Where task_id = {task_id}";

                int RowsAffected = connection.Execute(sql);
                return RowsAffected;
            }
        }
    }
}