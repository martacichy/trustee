using System;
using System.Collections.Generic;
using System.Text;
using BackendLibrary.Models;
using System.Threading.Tasks;
using Xunit;
using XUnitPriorityOrderer;

namespace BackendLibrary.Tests.Tests
{
    [Order(5)]
    public class EmployeeLabelDataTests : BaseTestClass
    {
        [Fact, Order(2)]
        public async void GetEmployeesShouldReturnList()
        {
            var output = await Task.Run(() => DataAccess.EmployeeLabelData.GetAllLabelsByEmployeeId(1));

            Assert.IsType<List<EmployeeLabelModel>>(output);
        }

        [Fact, Order(1)]
        public async void AddEmployeeLabelTest()
        {
            EmployeeLabelModel testLabel = new EmployeeLabelModel(1, 1);

            await Task.Run(() => DataAccess.EmployeeLabelData.AddEmployeeLabel(testLabel));

            DeleteEmployeeLabelTest();
        }

        // wywołujemy ten test w innych testach, więc nie dajemy tu już [Fact]
        private async void DeleteEmployeeLabelTest()
        {
            int rowsAffected = await Task.Run(() => DataAccess.EmployeeLabelData.DeleteEmployeeLabel(1, 1));

            Assert.True(rowsAffected == 1);
        }
    }
}
