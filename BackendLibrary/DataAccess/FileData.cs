using BackendLibrary.Models;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BackendLibrary.DataAccess
{
    public class FileData : SqlConnector
    {
        /// <summary>
        /// dodaje nowy plik do bazy
        /// </summary>
        public static void AddFile(FileModel newFile)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = @"INSERT into database06.file (Task_id, Employee_id, Date, File_name, File_size, File_rawData)
                            values (@task_id, @employee_id, @date, @file_name, @file_size, @file_rawData)";

                connection.Execute(sql, newFile);
            }
        }

        public static List<FileModel> GetAllByTaskId(int task_id)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"SELECT * FROM database06.file WHERE Task_id = {task_id}";
                var data = connection.Query<FileModel>(sql).ToList();

                return data;
            }
        }

        public static int DeleteFile(int file_id)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"DELETE FROM database06.file WHERE File_id = {file_id}";

                connection.Execute(sql);

                int RowsAffected = connection.Execute(sql);
                return RowsAffected;
            }
        }
    }
}
