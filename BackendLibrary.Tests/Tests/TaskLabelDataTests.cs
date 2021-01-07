using BackendLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BackendLibrary.Tests.Tests
{
    public class TaskLabelDataTests
    {
        [Fact]
        public void DeleteTaskLabelTest()
        {
            TaskLabelModel oldTaskLabel = new TaskLabelModel(1, 1);

            DataAccess.TaskLabelData.DeleteTaskLabel(oldTaskLabel);
        }
    }
}
