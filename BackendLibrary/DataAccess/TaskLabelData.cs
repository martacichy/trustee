using BackendLibrary.Models;
using Dapper;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BackendLibrary.DataAccess
{
    /// <summary>
    ///  Klasa wysyłająca zapytania bazodanowe SQL dotyczące tabeli "TaskLabel".
    /// </summary>
    public class TaskLabelData : SqlConnector
    {
        /// <summary> Zwraca listę wszystkich etykiet zadania o danym ID. </summary>
        public static List<TaskLabelModel> GetAllLabelsByTaskId(int taskId)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"SELECT * FROM database06.tasklabel WHERE task_id = {taskId}";
                var data = connection.Query<TaskLabelModel>(sql).ToList();

                return data;
            }
        }

        /// <summary> Dodaje nową etykietę do zadania. </summary>
        public static void AddTaskLabel(TaskLabelModel newTaskLabel)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = @"insert into database06.tasklabel (task_id, label_id)
                            values (@Task_id, @Label_id)";

                connection.Execute(sql, newTaskLabel);
            }
        }

        /// <summary> Usuwa konkretną etykietę zadania. </summary>
        public static int DeleteTaskLabel(int task_id, int label_id)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"delete from database06.tasklabel where task_id = {task_id} AND label_id = {label_id}";

                int rowsAffected = connection.Execute(sql);
                return rowsAffected;
            }
        }
    }
}