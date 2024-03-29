﻿using BackendLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using XUnitPriorityOrderer;

namespace BackendLibrary.Tests.Tests
{
    /// <summary>
    /// Klasa testowa dla klasy EmployeeData.
    /// </summary>
    [Order(4)]
    public class EmployeeDataTests : BaseTestClass
    {
        [Fact, Order(4)]
        public async void GetIdByMailTest()
        {
            var output = await Task.Run(() => DataAccess.EmployeeData.GetIdByEmail("nieistniejący mail"));

            Assert.True(output == 0);
        }

        [Fact, Order(3)]
        public async void GetEmployeesShouldReturnList()
        {
            var output = await Task.Run(() => DataAccess.EmployeeData.GetAll());

            Assert.IsType<List<EmployeeModel>>(output);
        }

        [Fact, Order(1)]
        public async void AddEmployeeTest()
        {
            int company_id = await Task.Run(() => DataAccess.CompanyData.GetMaxId());
            EmployeeModel employee = new EmployeeModel(company_id, "Jadwiga", "Hymel", "jadwigaHymel@gmail.com",
                                                        0, "jadwigaHymel@gmail.com", "pass123");

            await Task.Run(() => DataAccess.EmployeeData.AddEmployee(employee));
        }

        [Fact, Order(2)]
        public async void GetByIdTest()
        {
            int id = await Task.Run(() => DataAccess.EmployeeData.GetMaxId());
            var output = await Task.Run(() => DataAccess.EmployeeData.GetById(id));

            Assert.True(output.Employee_id == id);
        }
    }
}