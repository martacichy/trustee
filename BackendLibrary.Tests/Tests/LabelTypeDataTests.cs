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
            int company_id = await Task.Run(() => DataAccess.CompanyData.GetMaxId());
            LabelTypeModel labelType = new LabelTypeModel(company_id, "labelTypeNumberOne");

            await Task.Run(() => DataAccess.LabelTypeData.AddLabelType(labelType));
        }

        [Fact, Order(2)]
        public async void GetByIdTest()
        {
            int id = await Task.Run(() => DataAccess.LabelTypeData.GetMaxId());
            var output = await Task.Run(() => DataAccess.LabelTypeData.GetById(id));

            Assert.IsType<LabelTypeModel>(output);
        }
    }
}