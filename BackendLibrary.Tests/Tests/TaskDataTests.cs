using BackendLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BackendLibrary.Tests.Tests
{
    public class TaskDataTests
    {
        [Fact]
        public void GetTasksShouldReturnList()
        {
            var output = DataAccess.TaskData.GetAllTasks();

            Assert.IsType<List<TaskModel>>(output);
        }

        [Fact]
        public void AddTaskTypeShouldDoItsJob()
        {
            DataAccess.TaskData.GetAllTasks();
        }

        [Fact]
        public void AddTaskTest()
        {
            TaskModel task = new TaskModel(1, "TaskNumberOne", "Task number one description",
                new DateTime(2016, 11, 23), new DateTime(2021, 11, 23), "status", 1);

            DataAccess.TaskData.AddTask(task);
        }

        [Fact]
        public void GetByIdTest()
        {
            var output = DataAccess.TaskData.GetById(1);

            Assert.IsType<TaskModel>(output);
        }
    }
}