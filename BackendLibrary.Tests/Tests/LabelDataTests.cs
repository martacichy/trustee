using BackendLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using XUnitPriorityOrderer;

namespace BackendLibrary.Tests.Tests
{
    [Order(3)]
    public class LabelDataTests
    {
        [Fact, Order(2)]    
        public async void GetLabelsShouldReturnList()
        {
            var output = await Task.Run(() => DataAccess.LabelData.GetAllLabels());

            Assert.IsType<List<LabelModel>>(output);
        }

        [Fact, Order(1)]
        public async void AddLabelTest()
        {
            LabelModel label = new LabelModel(1, 1, "testowa etykieta", "Opis etykiety");

            await Task.Run(() => DataAccess.LabelData.AddLabel(label));

            DeleteLabelTest();
        }

        [Fact, Order(3)]
        public async void GetByIdTest()
        {
            var output = await Task.Run(() => DataAccess.LabelData.GetById(1));

            Assert.True(output.Label_id == 1);
        }

        private async void DeleteLabelTest()
        {
            int rowsAffected = await Task.Run(() => DataAccess.LabelData.DeleteLabel(1));

            Assert.True(rowsAffected == 1);
        }
    }
}
