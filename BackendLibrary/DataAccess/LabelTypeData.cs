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

        /// <summary> Zwraca listę wszystkich typów etykiet danej firmy. </summary>
        public static List<LabelTypeModel> GetAllByCompanyId(int company_id)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"SELECT * FROM database06.labeltype where Company_id = {company_id}";
                var data = connection.Query<LabelTypeModel>(sql).ToList();

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

        /// <summary> Usuwa rodzaj etykiety z bazy danych,
        /// a w etykietach, w których był użyty usuwa informację o rodzaju etykiety
        /// </summary>
        public static int DeleteLabelType(int label_type_id)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {

                string sql = $"update database06.label set label_type_id = NULL" +
                             $" where label_id = {label_type_id}";
                connection.Execute(sql);

                sql = $"delete from database06.labeltype where Label_type_id = {label_type_id}";
                int RowsAffected = connection.Execute(sql);

                return RowsAffected;
            }
        }
    }
}
