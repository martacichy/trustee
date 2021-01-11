﻿using System;
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

        [Fact]
        public void AddCompanyTest()
        {
            CompanyModel company = new CompanyModel("HymelCompany", new DateTime(2016, 11, 23));

            DataAccess.CompanyData.AddCompany(company);
        }

        [Fact]
        public void GetByIdTest()
        {
            var output = DataAccess.CompanyData.GetById(1);

            Assert.IsType<CompanyModel>(output);
        }
    }
}
