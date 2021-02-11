﻿using BackendLibrary.Models;
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
        [Fact, Order(3)]
        public async void GetTasksShouldReturnList()
        {
            var output = await Task.Run(() => DataAccess.TaskData.GetAllTasks());

            Assert.IsType<List<TaskModel>>(output);
        }

        [Fact, Order(1)]
        public async void AddTaskTest()
        {
            int company_id = await Task.Run(() => DataAccess.CompanyData.GetMaxId());
            TaskModel task = new TaskModel(company_id, "TaskNumberOne", "Task number one description",
                new DateTime(2016, 11, 23), new DateTime(2021, 11, 23), "status", 1);

            await Task.Run(() => DataAccess.TaskData.AddTask(task));
        }
    }
}