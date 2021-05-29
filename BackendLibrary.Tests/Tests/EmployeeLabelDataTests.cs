using BackendLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using XUnitPriorityOrderer;

namespace BackendLibrary.Tests.Tests
{
    /// <summary>
    /// Klasa testowa dla klasy EmployeeLabelData.
    /// </summary>
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
            int emp_id = await Task.Run(() => DataAccess.EmployeeData.GetMaxId());
            int label_id = await Task.Run(() => DataAccess.LabelData.GetMaxId());
            EmployeeLabelModel testLabel = new EmployeeLabelModel(emp_id, label_id);

            await Task.Run(() => DataAccess.EmployeeLabelData.AddEmployeeLabel(testLabel));
        }
    }
}