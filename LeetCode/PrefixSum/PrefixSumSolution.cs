namespace LeetCode
{
    using System.Collections.Generic;

    public partial class Solutions
    {
        #region 560. Subarray Sum Equals K
        /// <summary>
        /// Given an array of integers nums and an integer k, return
        /// the total number of subarrays whose sum equals to k.
        /// A subarray is a contiguous non-empty sequence of elements
        /// within an array.
        /// https://leetcode.com/problems/subarray-sum-equals-k/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int SubarraySum(int[] nums, int k)
        {
            int ret = 0;
            Dictionary<int, int> dict = new Dictionary<int, int>();
            int current = 0;
            dict.Add(0, 1);
            for (int i = 0; i < nums.Length; i++)
            {
                current += nums[i];
                if (dict.ContainsKey(current - k))
                {
                    ret += dict[current - k];
                }
                if (dict.ContainsKey(current))
                {
                    dict[current] += 1;
                }
                else
                {
                    dict.Add(current, 1);
                }
            }
            return ret;
        }
        #endregion

        #region 523. Continuous Subarray Sum
        /// <summary>
        /// Given an integer array nums and an integer k, return true
        /// if nums has a continuous subarray of size at least two whose
        /// elements sum up to a multiple of k, or false otherwise.
        /// An integer x is a multiple of k if there exists an integer n
        /// such that x = n * k. 0 is always a multiple of k.
        /// https://leetcode.com/problems/continuous-subarray-sum/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public bool CheckSubarraySum(int[] nums, int k)
        {
            //for (int i = 0; i < nums.Length - 1; i++)
            //{
            //    int v = nums[i];
            //    for (int j = i + 1; j < nums.Length; j++)
            //    {
            //        v += nums[j];
            //        if (v % k == 0)
            //        {
            //            return true;
            //        }
            //    }
            //}
            //return false;
            HashSet<int> modSet = new HashSet<int>();
            int currSum = 0, prevSum = 0;
            foreach (int n in nums)
            {
                currSum += n;
                if (modSet.Contains(currSum % k))
                {
                    return true;
                }
                currSum %= k;
                modSet.Add(prevSum);
                prevSum = currSum;
            }
            return false;
        }
        #endregion
    }
}
