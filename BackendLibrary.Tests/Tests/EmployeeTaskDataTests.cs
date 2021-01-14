using System;
using System.Collections.Generic;
using System.Text;
using BackendLibrary.Models;
using System.Threading.Tasks;
using Xunit;
using XUnitPriorityOrderer;

namespace BackendLibrary.Tests.Tests
{
    [Order(8)]
    public class EmployeeTaskDataTests
    {
        [Fact, Order(2)]
        public async void GetEmployeesShouldReturnList()
        {
            var output = await Task.Run(() => DataAccess.EmployeeTaskData.GetAllLabelsByEmployeeId(1));

            Assert.IsType<List<EmployeeTaskModel>>(output);
        }

        [Fact, Order(1)]
        public async void AddEmployeeTaskTest()
        {
            EmployeeTaskModel testTask = new EmployeeTaskModel(1, 1, "przypisane");

            await Task.Run(() => DataAccess.EmployeeTaskData.AddEmployeeTask(testTask));

            DeleteEmployeeTaskTest();
        }

        // wywołujemy ten test w innych testach, więc nie dajemy tu już [Fact]
        private async void DeleteEmployeeTaskTest()
        {
            int rowsAffected = await Task.Run(() => DataAccess.EmployeeTaskData.DeleteEmployeeTask(1, 1));

            Assert.True(rowsAffected == 1);
        }
    }
}
