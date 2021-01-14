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
        public void GetAllTest()
        {
            var output = DataAccess.CompanyData.GetAll();

            Assert.IsType<List<CompanyModel>> (output);
        }

        [Fact, Order(1)]
        public void AddCompanyTest()
        {
            CompanyModel company = new CompanyModel("HymelCompany", new DateTime(2016, 11, 23));

            DataAccess.CompanyData.AddCompany(company);
        }

        [Fact, Order(2)]
        public void GetByIdTest()
        {
            var output = DataAccess.CompanyData.GetById(1);

            Assert.IsType<CompanyModel>(output);
        }
    }
}
