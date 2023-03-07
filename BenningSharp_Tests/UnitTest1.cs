using BenningSharp;

namespace BenningSharp_Tests
{
    public class Tests
    {
        private static string DB_PATH = "C:\\Users\\Patrick\\Desktop\\LAV2022.db";
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Database database = new Database(DB_PATH);
            Assert.Pass();
        }
    }
}