namespace LeetCode.BinarySearch
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Threading;

    [TestClass]
    public partial class BinarySearchTest: TestBase
    {
        [TestMethod]
        [DataRow(new int[] { 1, 3, 5, 2 }, new int[] { 2, 3, 1, 14 }, 8)]
        public void MinCostTest(int[] nums, int[] cost, long expected)
        {
            long actual = this.Solutions.MinCost(nums, cost);
            Assert.AreEqual(expected, actual);
        }
    }
}
