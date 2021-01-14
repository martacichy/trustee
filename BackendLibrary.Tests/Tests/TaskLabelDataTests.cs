using BackendLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using XUnitPriorityOrderer;

namespace BackendLibrary.Tests.Tests
{
    [Order(7)]
    public class TaskLabelDataTests
    {
        [Fact, Order(2)]
        public async void GetTaskShouldReturnList()
        {
            var output = await Task.Run(() => DataAccess.TaskLabelData.GetAllLabelsByTaskId(1));

            Assert.IsType<List<TaskLabelModel>>(output);
        }

        [Fact, Order(1)]
        public async void AddTaskLabelTest()
        {
            TaskLabelModel testLabel = new TaskLabelModel(1, 1);

            await Task.Run(() => DataAccess.TaskLabelData.AddTaskLabel(testLabel));

            DeleteTaskLabelTest();
        }

        // wywołujemy ten test w innych testach, więc nie dajemy tu już [Fact]
        private async void DeleteTaskLabelTest()
        {
            int rowsAffected = await Task.Run(() => DataAccess.TaskLabelData.DeleteTaskLabel(1, 1));

            Assert.True(rowsAffected == 1);
        }
    }
}
