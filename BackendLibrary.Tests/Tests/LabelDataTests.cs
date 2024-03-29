﻿using BackendLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using XUnitPriorityOrderer;

namespace BackendLibrary.Tests.Tests
{
    /// <summary>
    /// Klasa testowa dla klasy LabelData.
    /// </summary>
    [Order(3)]
    public class LabelDataTests
    {
        [Fact, Order(3)]
        public async void GetLabelsShouldReturnList()
        {
            var output = await Task.Run(() => DataAccess.LabelData.GetAllLabels());

            Assert.IsType<List<LabelModel>>(output);
        }

        [Fact, Order(1)]
        public async void AddLabelTest()
        {
            int company_id = await Task.Run(() => DataAccess.CompanyData.GetMaxId());
            LabelModel label = new LabelModel(company_id, "testowa etykieta", "Opis etykiety");

            await Task.Run(() => DataAccess.LabelData.AddLabel(label));
        }
    }
}