using BackendLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using XUnitPriorityOrderer;

namespace BackendLibrary.Tests.Tests
{
    /// <summary>
    /// Klasa testowa dla klasy EmployeeTaskData.
    /// </summary>
    [Order(8)]
    public class EmployeeTaskDataTests : BaseTestClass
    {
        [Fact, Order(2)]
        public async void GetEmployeesShouldReturnList()
        {
            var output = await Task.Run(() => DataAccess.EmployeeTaskData.GetAllTasksByEmployeeId(1));

            Assert.IsType<List<EmployeeTaskModel>>(output);
        }

        [Fact, Order(1)]
        public async void AddEmployeeTaskTest()
        {
            int task_id = await Task.Run(() => DataAccess.TaskData.GetMaxId());
            int emp_id = await Task.Run(() => DataAccess.EmployeeData.GetMaxId());
            EmployeeTaskModel testTask = new EmployeeTaskModel(task_id, emp_id, "przypisane");

            await Task.Run(() => DataAccess.EmployeeTaskData.AddEmployeeTask(testTask));
        }
    }
}