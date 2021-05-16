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
    ///  Klasa wysyłająca zapytania bazodanowe SQL dotyczące tabeli "Label".
    /// </summary>
    public class LabelData : SqlConnector
    {
        /// <summary> Zwraca listę wszystkich etykiet. </summary>
        public static List<LabelModel> GetAllLabels()
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = "SELECT * FROM database06.label";
                var data = connection.Query<LabelModel>(sql).ToList();

                return data;
            }
        }

        /// <summary> Zwraca model o przekazanym w argumencie id. </summary>
        public static LabelModel GetById(int label_id)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"SELECT * FROM database06.label WHERE Label_id = {label_id}";
                var data = connection.Query<LabelModel>(sql).FirstOrDefault();

                return data;
            }
        }

        /// <summary> Zwraca autowygenerowane Id w ostatnio wykonanym insercie.</summary>
        public static int GetMaxId()
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"SELECT max(Label_id) from database06.label";
                int id = connection.Query<int>(sql).First();

                return id;
            }
        }

        public static int GetIdByName(String name)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"SELECT Label_id from database06.label where name = '{name}'";
                int id = connection.Query<int>(sql).First();

                return id;
            }
        }

        public static string GetNameById(int id)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"SELECT Name from database06.label where Label_id= {id}";
                string name = connection.Query<string>(sql).FirstOrDefault();

                return name;
            }
        }

        /// <summary> Zwraca listę wszystkich etykiet danej firmy. </summary>
        public static List<LabelModel> GetAllByCompanyId(int company_id)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"SELECT * FROM database06.label where Company_id = {company_id}";
                var data = connection.Query<LabelModel>(sql).ToList();

                return data;
            }
        }

        /// <summary> Dodaje nową etykietę </summary>
        public static void AddLabel(LabelModel newLabel)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql;
                if (!String.IsNullOrEmpty(newLabel.Description))
                {
                    sql = @"insert into database06.label (Company_id, Name, Description)
                            values (@Company_id, @Name, @Description)";
                }
                else 
                {
                    sql = @"insert into database06.label (Company_id, Name)
                            values (@Company_id, @Name)";
                }

                connection.Execute(sql, newLabel);
            }
        }

        /// <summary> Aktualizuje daną etykietę </summary>
        public static void UpdateLabel(LabelModel updatedLabel)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = @"UPDATE database06.label SET Name = @Name, Description = @Description
                    WHERE label_id = @label_id";

                connection.Execute(sql, updatedLabel);
            }
        }

        /// <summary> Usuwa etykietę z bazy danych,
        /// usuwając wcześniej wiersze z innych tabel, gdzie zawarty jest dany klucz obcy z tabeli Label
        /// </summary>
        public static int DeleteLabel(int label_id)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"delete from database06.tasklabel Where label_id = {label_id}";
                connection.Execute(sql);

                sql = $"delete from database06.employeelabel Where label_id = {label_id}";
                connection.Execute(sql);

                sql = $"delete from database06.label Where label_id = {label_id}";
                int RowsAffected = connection.Execute(sql);

                return RowsAffected;
            }
        }
    }
}