using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace BackendLibrary.Models
{
    public class FileModel
    {
        /// <summary>
        /// klasa dla plików, zgodnie z poradą ze stackoverflow :) 
        /// </summary>
        public int File_id { get; set; }
        public int Task_id { get; set; }
        public int Employee_id { get; set; }
        public DateTime Date { get; set; }
        public string File_name { get; set; }
        public int File_size { get; set; }
        public byte[] File_rawData { get; set; }

        public FileModel(int file_id , int task_id, int employee_id, DateTime date, string path_to_file)
        {
            FileInfo info = new FileInfo(path_to_file);

            File_id = file_id;
            Task_id = task_id;
            Employee_id = employee_id;
            Date = date;
            File_name = path_to_file;
            File_size = Convert.ToInt32(info.Length);
            File_rawData = File.ReadAllBytes(path_to_file);
        }

        public FileModel(int task_id, int employee_id, DateTime date, string path_to_file)
        {
            FileInfo info = new FileInfo(path_to_file);

            Task_id = task_id;
            Employee_id = employee_id;
            Date = date;
            File_name = path_to_file;
            File_size = Convert.ToInt32(info.Length);
            File_rawData = File.ReadAllBytes(path_to_file);
        }

        public FileModel()
        {

        }
    }
}
