using BackendLibrary.Models;
using Dapper;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BackendLibrary.DataAccess
{
    /// <summary>
    ///  Klasa wysyłająca zapytania bazodanowe SQL dotyczące tabeli "comment".
    /// </summary>
    public class CommentData : SqlConnector
    {
        /// <summary> Zwraca model o przekazanym w argumencie id zadania. </summary>
        public static CommentModel GetByTaskId(int task_id)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"SELECT * FROM database06.comment WHERE Task_id = {task_id}";
                var data = connection.Query<CommentModel>(sql).FirstOrDefault();

                return data;
            }
        }

        /// <summary> Zwraca model o przekazanym w argumencie id pracownika. </summary>
        public static CommentModel GetByEmployeeId(int employee_id)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"SELECT * FROM database06.comment WHERE Task_id = {employee_id}";
                var data = connection.Query<CommentModel>(sql).FirstOrDefault();

                return data;
            }
        }

        /// <summary> Dodaje nowy komentarz. </summary>
        public static void AddComment(CommentModel newComment)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = @"insert into database06.comment (Task_id, Employee_id, Date, Description)
                            values (@Task_id, @Employee_id, @Date, @Description)";

                connection.Execute(sql, newComment);
            }
        }

        /// <summary> Usuwa komentarz o zadanym id. </summary>
        public static int DeleteComment(int comment_id)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"delete from database06.comment Where comment_id = {comment_id}";

                connection.Execute(sql);

                int RowsAffected = connection.Execute(sql);
                return RowsAffected;
            }
        }
    }
}