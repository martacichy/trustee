using BackendLibrary.Models;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BackendLibrary.DataAccess
{
    /// <summary>
    ///  Klasa wysyłająca zapytania bazodanowe SQL dotyczące tabeli "company".
    /// </summary>
    public class CompanyData : SqlConnector
    {
        /// <summary> Zwraca listę wszystkich firm. </summary>
        public static List<CompanyModel> GetAll()
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = "SELECT * FROM database06.company";
                var data = connection.Query<CompanyModel>(sql).ToList();

                return data;
            }
        }

        /// <summary> Zwraca model o przekazanym w argumencie id. </summary>
        public static CompanyModel GetById(int company_id)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = $"SELECT * FROM database06.company WHERE Company_id = {company_id}";
                var data = connection.Query<CompanyModel>(sql).FirstOrDefault();

                return data;
            }
        }

        /// <summary> Dodaje nową firmę. </summary>
        public static void AddCompany(CompanyModel newCompany)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = @"insert into database06.company (Name, Creation_date, Login, Password)
                            values (@Name, @Creation_date, @Login, @Password)";

                connection.Execute(sql, newCompany);
            }
        }
    }
}
