namespace LeetCode
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public class TestBase
    {
        public TestContext TestContext { get; set; }

        public Solutions Solutions { get; set; } = new Solutions();
    }
}
