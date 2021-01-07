﻿using System;
using System.Collections.Generic;
using System.Text;
using BackendLibrary.Models;
using System.Threading.Tasks;
using Xunit;

namespace BackendLibrary.Tests.Tests {
    public class EmployeeDataTests {
        [Fact]
        public void GetEmployeesShouldReturnList() {
            var output = DataAccess.EmployeeData.GetAllEmployees();

            Assert.IsType<List<EmployeeModel>>(output);
        }
        [Fact]
        public void AddEmployeeShouldDoItsJob() {
            DataAccess.EmployeeData.GetAllEmployees();
        }

        [Fact]
        public void AddEmployeeTest() {
            EmployeeModel employee = new EmployeeModel(3, "Jadwiga", "Hymel", "jadwigaHymel@gmail.com", 1);

            DataAccess.EmployeeData.AddEmployee(employee);
        }
    }
}