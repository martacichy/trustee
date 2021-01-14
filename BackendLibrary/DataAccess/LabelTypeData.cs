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
    ///  Klasa wysyłająca zapytania bazodanowe SQL dotyczące tabeli "LabelType".
    /// </summary>
    public class LabelTypeData : SqlConnector {

        /// <summary> Zwraca listę wszystkich typów etykiet. </summary>
        public static List<LabelTypeModel> GetAll()
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = "SELECT * FROM database06.labeltype";
                var data = connection.Query<LabelTypeModel>(sql).ToList();

                return data;
            }
        }

        /// <summary> Zwraca model o przekazanym w argumencie id. </summary>
        public static LabelTypeModel GetById(int label_type_id)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"SELECT * FROM database06.labeltype WHERE Label_type_id = {label_type_id}";
                var data = connection.Query<LabelTypeModel>(sql).FirstOrDefault();

                return data;
            }
        }

        /// <summary> Dodaje nowy typ etykiety </summary>
        public static void AddLabelType(LabelTypeModel newLabelType) {
            using (IDbConnection connection = new MySqlConnection(connectionString)) {

                string sql = @"insert into database06.labeltype (Label_type_id, Name)
                            values (@Label_type_id, @Name)";

                connection.Execute(sql, newLabelType);

            }
        }
    }
}
