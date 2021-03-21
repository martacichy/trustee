using BackendLibrary.Models;
using System.Collections.Generic;
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
            int task_id = await Task.Run(() => DataAccess.TaskData.GetMaxId());
            int label_id = await Task.Run(() => DataAccess.LabelData.GetMaxId());
            TaskLabelModel testLabel = new TaskLabelModel(task_id, label_id);

            await Task.Run(() => DataAccess.TaskLabelData.AddTaskLabel(testLabel));
        }
    }
}