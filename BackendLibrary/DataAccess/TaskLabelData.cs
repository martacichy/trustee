using BackendLibrary.Models;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendLibrary.DataAccess
{
    public class TaskLabelData : SqlConnector
    {
        public static void DeleteTaskLabel(TaskLabelModel oldTaskLabel)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = @"delete from database06.tasklabel Where task_id = @task_id AND label_id = @label_id";

                connection.Execute(sql, oldTaskLabel);
            }
        }
    }
}
