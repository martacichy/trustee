using System;
using System.Collections.Generic;
using System.Text;
using BackendLibrary.Models;
using System.Threading.Tasks;
using Xunit;
using XUnitPriorityOrderer;

namespace BackendLibrary.Tests.Tests
{
    [Order(4)]
    public class EmployeeDataTests : BaseTestClass
    {
        [Fact, Order(3)]
        public void GetEmployeesShouldReturnList()
        {
            var output = DataAccess.EmployeeData.GetAll();

            Assert.IsType<List<EmployeeModel>>(output);
        }

        [Fact, Order(1)]
        public void AddEmployeeTest()
        {
            EmployeeModel employee = new EmployeeModel(1, "Jadwiga", "Hymel", "jadwigaHymel@gmail.com", 0);

            DataAccess.EmployeeData.AddEmployee(employee);
        }

        [Fact, Order(2)]
        public void GetByIdTest()
        {
            var output = DataAccess.EmployeeData.GetById(1);

            Assert.IsType<EmployeeModel>(output);
        }
    }
}