using BackendLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BackendLibrary.Tests.Tests {
    public class LabelDataTests {
        [Fact]    
        public void GetLabelsShouldReturnList() {
            var output = DataAccess.LabelData.GetAllLabels();

            Assert.IsType<List<LabelModel>>(output);
        }
        [Fact]
        public void AddLabelShouldDoItsJob() {
            DataAccess.LabelData.GetAllLabels();
        }

        [Fact]
        public void AddLabelTest() {
            LabelModel label = new LabelModel(1, 1, "testowa etykieta", "Opis etykiety");

            DataAccess.LabelData.AddLabel(label);
        }

        [Fact]
        public void GetByIdTest()
        {
            var output = DataAccess.LabelData.GetById(1);

            Assert.IsType<LabelModel>(output);
        }
    }
}
