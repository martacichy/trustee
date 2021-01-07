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
        public static List<LabelModel> GetAllLabels() {
            using (IDbConnection connection = new MySqlConnection(connectionString)) {
                string sql = "SELECT * FROM database06.label";
                var data = connection.Query<LabelModel>(sql).ToList();

                return data;
            }
        }

        /// <summary> Dodaje nową etykietę </summary>
        public static void AddLabel(LabelModel newLabel) {
            using (IDbConnection connection = new MySqlConnection(connectionString)) {

                string sql = @"insert into database06.label (Company_id, Label_type_id, Name, Description)
                            values (@Company_id, @Label_type_id, @Name, @Description)";

                connection.Execute(sql, newLabel);

            }
        }
    }
}
