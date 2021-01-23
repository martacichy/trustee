using BackendLibrary.Models;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BackendLibrary.DataAccess {
    /// <summary>
    ///  Klasa wysyłająca zapytania bazodanowe SQL dotyczące tabeli "task".
    /// </summary>
    public class TaskData : SqlConnector { 

        /// <summary> Zwraca listę wszystkich tasków. </summary>
        public static List<TaskModel> GetAllTasks() {
            using (IDbConnection connection = new MySqlConnection(connectionString)) {
                string sql = "SELECT * FROM database06.task";
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

        /// <summary> Dodaje nowego taska. </summary>
        public static void AddTask(TaskModel newTask) {
            using (IDbConnection connection = new MySqlConnection(connectionString)) {
                string sql = @"insert into database06.task (Company_id, Name, Description, Start_time, Deadline, Status, Auto_assigned)
                            values (@Company_id, @Name, @Description, @Start_time, @Deadline, @Status, @Auto_assigned)";

                connection.Execute(sql, newTask);
            }
        }

        /// <summary> Usuwa zadanie z bazy danych,
        /// usuwając wcześniej wiersze z innych tabel, gdzie zawarty jest dany klucz obcy z tabeli Task
        /// </summary>
        public static int DeleteTask(int task_id)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"delete from database06.employeetask Where task_id = {task_id}";

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
