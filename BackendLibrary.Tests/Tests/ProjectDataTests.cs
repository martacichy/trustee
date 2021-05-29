using BackendLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using XUnitPriorityOrderer;

namespace BackendLibrary.Tests.Tests
{
    /// <summary>
    /// Klasa testowa dla klasy ProjectData.
    /// </summary>
    [Order(2)]
    public class ProjectDataTests : BaseTestClass
    {
        [Fact, Order(3)]
        public async void GetAllTests()
        {
            var output = await Task.Run(() => DataAccess.ProjectData.GetAll());

            Assert.IsType<List<ProjectModel>>(output);
        }

        [Fact, Order(1)]
        public async void AddProjectTest()
        {
            int company_id = await Task.Run(() => DataAccess.CompanyData.GetMaxId());
            ProjectModel project = new ProjectModel(company_id, "projekt testowy");

            await Task.Run(() => DataAccess.ProjectData.AddProject(project));
        }

        [Fact, Order(2)]
        public async void GetByIdTest()
        {
            int id = await Task.Run(() => DataAccess.ProjectData.GetMaxId());
            var output = await Task.Run(() => DataAccess.ProjectData.GetById(id));

            Assert.IsType<ProjectModel>(output);
        }
    }
}