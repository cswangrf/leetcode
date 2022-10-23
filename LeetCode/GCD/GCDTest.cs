namespace LeetCode.GCD
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public class GCDTest:TestBase
    {
        [TestMethod]
        [DataRow(new int[] { 9, 3, 1, 2, 6, 3 }, 3, 4)]
        [DataRow(new int[] { 9, 3, 1, 2, 6 }, 1, 10)]
        public void SubarrayGCDTest(int[] nums, int k, int expected)
        {
            int actual = this.Solutions.SubarrayGCD(nums, k);
            Assert.AreEqual(expected, actual);
        }
    }
}
