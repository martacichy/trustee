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
        public async void GetEmployeesShouldReturnList()
        {
            var output = await Task.Run(() => DataAccess.EmployeeData.GetAll());

            Assert.IsType<List<EmployeeModel>>(output);
        }

        [Fact, Order(1)]
        public async void AddEmployeeTest()
        {
            EmployeeModel employee = new EmployeeModel(1, "Jadwiga", "Hymel", "jadwigaHymel@gmail.com", 0);

            await Task.Run(() => DataAccess.EmployeeData.AddEmployee(employee));
            
            DeleteEmployeeTest();
        }

        [Fact, Order(2)]
        public async void GetByIdTest()
        {
            var output = await Task.Run(() => DataAccess.EmployeeData.GetById(1));

            Assert.IsType<EmployeeModel>(output);
        }

        private async void DeleteEmployeeTest()
        {
            int rowsAffected = await Task.Run(() => DataAccess.EmployeeData.DeleteEmployee(1));

            Assert.True(rowsAffected == 1);
        }
    }
}