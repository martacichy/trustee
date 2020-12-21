using System;
using System.Collections.Generic;
using System.Text;
using BackendLibrary.Models;
using System.Threading.Tasks;
using Xunit;

namespace BackendLibrary.Tests.Tests
{
    public class CompanyDataTests
    {
        [Fact]
        public void GetCompaniesShouldReturnList()
        {
            var output = DataAccess.CompanyData.GetAllCompanies();

            Assert.IsType<List<CompanyModel>> (output);
        }

        [Fact]
        public void AddCompanyShouldDoItsJob()
        {
            DataAccess.CompanyData.GetAllCompanies();
        }
    }
}
