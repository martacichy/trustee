using System;
using System.Collections.Generic;
using System.Text;
using BackendLibrary.Models;
using System.Threading.Tasks;
using Xunit;
using XUnitPriorityOrderer;

namespace BackendLibrary.Tests.Tests
{
    [Order(2)]
    public class LabelTypeDataTests : BaseTestClass
    {
        [Fact, Order(3)]
        public async void GetAllTests()
        {
            var output = await Task.Run(() => DataAccess.LabelTypeData.GetAll());

            Assert.IsType<List<LabelTypeModel>>(output);
        }

        [Fact, Order(1)]
        public async void AddLableTypeTest()
        {
            LabelTypeModel labelType = new LabelTypeModel(1, "labelTypeNumberOne");

            await Task.Run(() => DataAccess.LabelTypeData.AddLabelType(labelType));
        }

        [Fact, Order(2)]
        public async void GetByIdTest()
        {
            var output = await Task.Run(() => DataAccess.LabelTypeData.GetById(1));

            Assert.IsType<LabelTypeModel>(output);
        }
    }
}