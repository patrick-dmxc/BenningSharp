using BenningSharp.Manager;

namespace BenningSharp_Tests
{
    public class TestManagers
    {
        private RunManager _runManager= RunManager.Instance;
        [SetUp]
        public void Setup()
        {

        }
        [Test]
        public void TestInspectionsManager()
        {
            InspectionsManager manager = InspectionsManager.Instance;
            Assert.That(manager, Is.Not.Null);
            Assert.That(manager.IsInitializing, Is.True);
            Assert.That(manager.Inspections.Count, Is.EqualTo(5));
        }
    }
}
