﻿using BackendLibrary.Models;
using Dapper;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;

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

        /// <summary> Zwraca firmę o danym ID. </summary>
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

        /// <summary> Zwraca autowygenerowane ID w ostatnio wykonanym insercie.</summary>
        public static int GetMaxId()
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = "SELECT max(Company_id) from database06.company";
                int id = connection.Query<int>(sql).First();

                return id;
            }
        }

        /// <summary> Usuwa firmę z bazy danych,
        /// usuwając wcześniej wszystkie wpisy z innych tabel związane z daną firmą.
        /// </summary>
        public static int DeleteCompany(int company_id)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                var labeltypes = ProjectData.GetAllByCompanyId(company_id);
                var labels = LabelData.GetAllByCompanyId(company_id);
                var tasks = TaskData.GetAllByCompanyId(company_id);
                var employees = EmployeeData.GetAllByCompanyId(company_id);

                foreach (var item in labeltypes) { ProjectData.DeleteProject(item.Project_id); }
                foreach (var item in labels) { LabelData.DeleteLabel(item.Label_id); }
                foreach (var item in tasks) { TaskData.DeleteTask(item.Task_id); }
                foreach (var item in employees) { EmployeeData.DeleteEmployee(item.Employee_id); }

                string sql = $"delete from database06.company Where company_id = {company_id}";
                int RowsAffected = connection.Execute(sql);
                return RowsAffected;
            }
        }
    }
}