namespace LeetCode.PrefixSum
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PrefixSumTest : TestBase
    {
        [TestMethod]
        [DataRow(new int[] { 2, 1, -1 }, 0)]
        [DataRow(new int[] { 1, 2, 3 }, -1)]
        [DataRow(new int[] { 1, 7, 3, 6, 5, 6 }, 3)]
        public void PivotIndexTest(int[] nums, int expected)
        {
            int actual = this.Solutions.PivotIndex(nums);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(new int[] { 1, 2, 3 }, 3, 2)]
        [DataRow(new int[] { 1, 1, 1 }, 2, 2)]
        [DataRow(new int[] { 1, -1, 0 }, 0, 3)]
        [DataRow(new int[] { 1 }, 1, 1)]
        public void SubarraySumTest(int[] nums, int k, int expected)
        {
            int actual = this.Solutions.SubarraySum(nums, k);
            Assert.AreEqual(expected, actual);
        }
    }
}
