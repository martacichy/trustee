using Xunit;
using XUnitPriorityOrderer;

/// <summary>
/// https://github.com/frederic-prusse/XUnitPriorityOrderer
/// </summary>

[assembly: CollectionBehavior(DisableTestParallelization = true)]
[assembly: TestCollectionOrderer(CollectionPriorityOrderer.TypeName, CollectionPriorityOrderer.AssembyName)]

namespace BackendLibrary.Tests.Tests
{
    [TestCaseOrderer(CasePriorityOrderer.TypeName, CasePriorityOrderer.AssembyName)]
    public class BaseTestClass { }
}