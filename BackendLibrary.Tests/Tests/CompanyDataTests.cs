using System;
using System.Collections.Generic;
using System.Text;
using BackendLibrary.Models;
using System.Threading.Tasks;
using Xunit;
using XUnitPriorityOrderer;

namespace BackendLibrary.Tests.Tests
{
    [Order(1)]
    public class CompanyDataTests : BaseTestClass
    {
        [Fact, Order(3)]
        public async void GetAllTest()
        {
            var output = await Task.Run(() => DataAccess.CompanyData.GetAll());

            Assert.IsType<List<CompanyModel>> (output);
        }

        [Fact, Order(1)]
        public async void AddCompanyTest()
        {
            CompanyModel company = new CompanyModel("HymelCompany", new DateTime(2016, 11, 23),
                                                    "firma1@gmail.com", "pass123");

            await Task.Run(() => DataAccess.CompanyData.AddCompany(company));
        }

        [Fact, Order(2)]
        public async void GetByIdTest()
        {
            int id = await Task.Run(() => DataAccess.CompanyData.GetMaxId());
            var output = await Task.Run(() => DataAccess.CompanyData.GetById(id));

            Assert.IsType<CompanyModel>(output);
        }
    }
}
