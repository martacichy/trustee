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
    ///  Klasa wysyłająca zapytania bazodanowe SQL dotyczące tabeli "Label".
    /// </summary>
    public class LabelData : SqlConnector {

        /// <summary> Zwraca listę wszystkich etykiet. </summary>
        public static List<LabelModel> GetAllLabels()
        {
            using (IDbConnection connection = new MySqlConnection(connectionString)) {
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
                string sql = "SELECT max(Label_id) from database06.label";
                int id = connection.Query<int>(sql).First();

                return id;
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
        public static void AddLabel(LabelModel newLabel) {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {

                string sql = @"insert into database06.label (Company_id, Label_type_id, Name, Description)
                            values (@Company_id, @Label_type_id, @Name, @Description)";

                connection.Execute(sql, newLabel);

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
