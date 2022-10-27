namespace LeetCode
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public class TestBase
    {
        public TestContext TestContext { get; set; }

        public Solutions Solutions { get; set; } = new Solutions();

        [TestInitialize]
        public void TestInitialize()
        {
            this.TestContext.WriteLine("Test methods started.");
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.TestContext.WriteLine("Test methods finished.");
        }
    }
}
