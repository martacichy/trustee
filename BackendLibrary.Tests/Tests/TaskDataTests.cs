using BackendLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using XUnitPriorityOrderer;

namespace BackendLibrary.Tests.Tests
{
    [Order(6)]
    public class TaskDataTests
    {
        [Fact, Order(2)]
        public async void GetTasksShouldReturnList()
        {
            var output = await Task.Run(() => DataAccess.TaskData.GetAllTasks());

            Assert.IsType<List<TaskModel>>(output);
        }

        [Fact, Order(1)]
        public async void AddTaskTest()
        {
            TaskModel task = new TaskModel(1, "TaskNumberOne", "Task number one description",
                new DateTime(2016, 11, 23), new DateTime(2021, 11, 23), "status", 1);

            await Task.Run(() => DataAccess.TaskData.AddTask(task));

            DeleteTaskTest();
        }

        [Fact, Order(3)]
        public async void GetByIdTest()
        {
            var output = await Task.Run(() => DataAccess.TaskData.GetById(1));

            Assert.True(output.Task_id == 1);
        }

        private async void DeleteTaskTest()
        {
            int rowsAffected = await Task.Run(() => DataAccess.TaskData.DeleteTask(1));

            Assert.True(rowsAffected == 1);
        }
    }
}