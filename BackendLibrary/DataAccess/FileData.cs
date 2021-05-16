using BackendLibrary.Models;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Configuration;
using System.IO;
using System.Web;
using Syroot.Windows.IO;


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
        /// <summary>
        /// zwraca wszystkie pliki przypisane do konkretnego zadania
        /// </summary>
        public static List<FileModel> GetAllByTaskId(int task_id)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"SELECT * FROM database06.file WHERE Task_id = {task_id}";
                var data = connection.Query<FileModel>(sql).ToList();

                return data;
            }
        }

        /// <summary>
        /// usuwa wybrany plik
        /// </summary>
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
        /// <summary>
        /// pobiera wybrany plik z bazy na nasz komputer(możliwe, że działa tylko pod windowsem)
        /// </summary>
        public static void DownloadFile(FileModel SelectedFile)
        {
            byte[] bytes;
            string fileName, contentType;
            int filesize;
            string downloadsPath = new KnownFolder(KnownFolderType.Downloads).Path;
            FileStream fs;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandText = $"SELECT file_name, file_rawData, file_size from database06.file where file_id = {SelectedFile.File_id}";
                    cmd.Connection = connection;
                    connection.Open();
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        bytes = (byte[])sdr["file_rawData"];
                        filesize = (int)sdr["file_size"];
                        fileName = sdr["file_name"].ToString();
                        contentType = Path.GetExtension(SelectedFile.File_name);
                    }
                    
                    fs = new FileStream($"{downloadsPath}\\{fileName}", FileMode.OpenOrCreate, FileAccess.Write);
                    fs.Write(bytes, 0, filesize);
                    fs.Close();
                           
                    connection.Close();
                }
                

            }
        }
    }  
}
