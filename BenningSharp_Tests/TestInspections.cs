using BenningSharp;
using BenningSharp.Manager;

namespace BenningSharp_Tests
{
    public class TestInspections
    {
        private static string DB_PATH = "C:\\Users\\Patrick\\Desktop\\LAV2022.db";
        private RunManager _runManager= RunManager.Instance;
        private Database? database = null;
        [SetUp]
        public void Setup()
        {
            database = DatabaseManager.Instance.OpenOrGetDatabase(DB_PATH);
        }
        [Test]
        public void TestAllInspectionResultsHaveWrapper()
        {
            InspectionsManager manager = InspectionsManager.Instance;

            Assert.That(database, Is.Not.Null);
            var list = database.InspectionResults.SelectMany(ir => ir.Data.Select(d => d.Value.InspectionMajorKey)).Distinct().ToList();
            var except = manager.Inspections.Select(i => i.Type).Except(list);
            Assert.That(except.Count(), Is.EqualTo(0));
        }
    }
}
