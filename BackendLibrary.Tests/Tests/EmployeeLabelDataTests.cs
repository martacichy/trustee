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
        public void GetEmployeesShouldReturnList()
        {
            var output = DataAccess.EmployeeLabelData.GetAllLabelsByEmployeeId(1);

            Assert.IsType<List<EmployeeLabelModel>>(output);
        }

        [Fact, Order(1)]
        public void AddEmployeeLabelTest()
        {
            EmployeeLabelModel testLabel = new EmployeeLabelModel(1, 1);

            DataAccess.EmployeeLabelData.AddEmployeeLabel(testLabel);
        }

        [Fact, Order(3)]
        public void DeleteEmployeeLabelTest()
        {
            int rowsAffected = DataAccess.EmployeeLabelData.DeleteEmployeeLabel(1, 1);

            Assert.True(rowsAffected == 1);
        }
    }
}
