namespace LeetCode

{
    using System;

    public partial class Solutions
    {
        #region 2448. Minimum Cost to Make Array Equal
        /// <summary>
        /// You are given two 0-indexed arrays nums and cost consisting each of n positive integers.
        /// You can do the following operation any number of times:
        /// Increase or decrease any element of the array nums by 1.
        /// The cost of doing one operation on the ith element is cost[i].
        /// Return the minimum total cost such that all the elements of the array nums become equal.
        /// https://leetcode.com/problems/minimum-cost-to-make-array-equal/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="cost"></param>
        /// <returns></returns>
        public long MinCost(int[] nums, int[] cost)
        {
            // TODO: Time Limit Exceeded
            long ret = long.MaxValue;
            for(int i = 0; i< nums.Length;i++)
            {
                long temp = 0;
                for(int j = 0; j<nums.Length;j++)
                {
                    if (i == j) continue;
                    if (temp > ret) break;
                    temp += (long)Math.Abs(nums[i] - nums[j]) * cost[j];
                }
                ret = Math.Min(ret, temp);
            }
            return ret;
        }
        #endregion
    }
}
