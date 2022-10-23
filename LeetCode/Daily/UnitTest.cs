namespace LeetCode.Trail
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Threading;

    [TestClass]
    public class UnitTest1: TestBase
    {
        [TestMethod]
        [DataRow(new int[] { 1, 13, 10, 12, 31 }, 6)]
        public void CountDistinctIntegersTest(int[] nums, int expected)
        {
            int actual = this.Solutions.CountDistinctIntegers(nums);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CalculateTaxTest()
        {
            int[][] a = { new int []{3,50 }, new int[] { 7, 10 }, new int[] { 12,25 } };
            this.Solutions.CalculateTax(a, 10);
        }

        [TestMethod]
        [DataRow("leetcode", "coats", 7)]
        public void MinStepsTest(string s, string t, int expected)
        {
            int actual = this.Solutions.MinSteps(s, t);
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void CPUTest()
        {
            for(; ; )
            {
                for(int i = 0; i < 9600000; i++)
                {
                    Thread.Sleep(5);
                }

            }

        }

        [TestMethod]
        [DataRow(new int[] { 5, 5, 4}, 1, 1)]
        public void FindLeastNumOfUniqueIntsTest(int[] arr, int k, int expected)
        {
            int actual = this.Solutions.FindLeastNumOfUniqueInts(arr, k);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("tryhard", 3, 1)]
        public void MaxVowelsTest(string s, int k, int expected)
        {
            int actual = this.Solutions.MaxVowels(s, k);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CountTripletsTest()
        {
            int a = 2;
            int b = 3;
            int c = a ^ b;
        }

        [TestMethod]
        [DataRow(new int[] {10, 1, 2, 4, 7, 2 }, 5, 4)]
        public void LongestSubarrayTest(int[] nums, int limit, int expected)
        {
            int actual = this.Solutions.LongestSubarray(nums, limit);
        }
        [TestMethod]
        [DataRow("a0b1c2", "0a1b2c")]
        public void ReformatTest(string input, string expected)
        {
            string actual = this.Solutions.Reformat(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(new int[] { 2, 2, 2, 3, 3 }, -1)]
        [DataRow(new int[] { 2, 2, 4, 4 }, 2)]
        [DataRow(new int[] { 1, 2, 2, 3, 3, 3 }, 3)]
        [DataRow(new int[] {10, 1, 17, 18, 19, 12, 14,
            7, 10, 6, 20, 15, 20, 18, 14, 1, 8, 11, 11,
            1, 17, 5, 9, 5, 11, 2, 4, 7, 3, 6, 3, 16, 
            17, 7, 3, 10, 1, 16, 13, 7, 10, 5, 8, 6, 13,
            7, 10, 13, 14, 16, 12, 15, 13, 12, 14, 20, 
            13, 11, 11, 20, 6, 13, 6, 4, 14, 1, 4, 11, 
            16, 17, 12, 4, 11, 1, 10, 2, 18, 5, 6, 3, 
            9, 2, 14, 9, 18, 13, 14, 5, 11, 6, 9, 1, 5, 
            12, 4, 8, 7, 7, 17, 1, 19, 16, 12, 10, 16, 4, 
            8, 18, 3, 15, 2, 20, 15, 14, 16, 20, 16, 3, 
            18, 8, 16, 20, 7, 12, 5, 14, 11, 7, 3, 11, 
            19, 12, 20, 12, 3, 20, 8, 15, 20, 19, 2, 3, 14, 17},
            -1)]
        public void FindLuckyTest(int[] arr, int expected)
        {
            int actual = this.Solutions.FindLucky(arr);
            Assert.AreEqual(expected, actual, "FindLuckyTest");
        }

        public void NumTeamsTest(int[] arr, int expected)
        {

        }
    }
}
