using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BackendLibrary.DataAccess
{
    /// <summary>
    /// Klasa przetrzymująca dane połączenia z bazą danych.
    /// Dziedziczą po niej wszystkie klasy z folderu DataAccess.
    /// </summary>
    public class SqlConnector
    {
        // Dane logowania do bazy z WebApp/appsettings.json
        public static readonly string connectionString =
            "server=localhost;user id=team06;password=progzesp123;database=database06";


        /// <summary> Zwraca autowygenerowane Id w ostatnio wykonanym insercie.</summary>
        public static int LastInstertId()
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = "SELECT LAST_INSERT_ID()";
                int id = connection.Query(sql).FirstOrDefault();

                return id;
            }
        }
    }
}
