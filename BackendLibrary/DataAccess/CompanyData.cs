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
        public static List<CompanyModel> GetAllCompanies()
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = "SELECT * FROM database06.company";
                var data = connection.Query<CompanyModel>(sql).ToList();

                return data;
            }
        }

        /// <summary> Dodaje nową firmę. </summary>
        public static void AddCompany(CompanyModel newCompany)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString)) {
                
                 // https://github.com/StackExchange/Dapper/tree/main/Dapper.Contrib
                //tu znalazłem takie ulatwienie niby 
                string sql = @"insert into database06.company (Name, Creation_date)
                            values (@Name, @Creation_date)";

                connection.Execute(sql, newCompany);
            }
        }
    }
}
