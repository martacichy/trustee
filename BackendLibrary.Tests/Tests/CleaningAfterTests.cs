using System.Threading.Tasks;
using Xunit;
using XUnitPriorityOrderer;

namespace BackendLibrary.Tests.Tests
{
    /// <summary>
    /// Klasa testowa odpowiadająca za czyszczenie danych.
    /// </summary>
    [Order(100)]
    public class CleaningAfterTests : BaseTestClass
    {
        [Fact, Order(100)]
        // DeleteCompany() wywołuje też wszystkie inne delety
        public async void DeleteCompanyTest()
        {
            int id = await Task.Run(() => DataAccess.CompanyData.GetMaxId());
            int rowsAffected = await Task.Run(() => DataAccess.CompanyData.DeleteCompany(id));

            Assert.True(rowsAffected >= 1);
        }
    }
}