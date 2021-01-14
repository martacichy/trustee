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
        public void GetAllTests()
        {
            var output = DataAccess.LabelTypeData.GetAll();

            Assert.IsType<List<LabelTypeModel>>(output);
        }

        [Fact, Order(1)]
        public void AddLableTypeTest()
        {
            LabelTypeModel labelType = new LabelTypeModel(1, "labelTypeNumberOne");

            DataAccess.LabelTypeData.AddLabelType(labelType);
        }

        [Fact, Order(2)]
        public void GetByIdTest()
        {
            var output = DataAccess.LabelTypeData.GetById(1);

            Assert.IsType<LabelTypeModel>(output);
        }
    }
}