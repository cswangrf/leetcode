namespace LeetCode.PrefixSum
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public class PrefixSumTest: TestBase
    {
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
