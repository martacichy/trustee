using System;
using System.Collections.Generic;
using System.Text;
using BackendLibrary.Models;
using System.Threading.Tasks;
using Xunit;

namespace BackendLibrary.Tests.Tests {
    public class LabelTypeDataTests {
        [Fact]
        public void GetLabelTypesShouldReturnList() {
            var output = DataAccess.LabelTypeData.GetAllLabelsType();

            Assert.IsType<List<LabelTypeModel>>(output);
        }
        [Fact]
        public void AddLabelTypeShouldDoItsJob() {
            DataAccess.LabelTypeData.GetAllLabelsType();
        }

        [Fact]
        public void AddLableTypeTest() {
            LabelTypeModel labelType = new LabelTypeModel(1, "labelTypeNumberOne");

            DataAccess.LabelTypeData.AddLabelType(labelType);
        }
    }
}