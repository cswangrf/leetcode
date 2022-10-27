namespace LeetCode
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    public partial class Solutions
    {
        #region 724. Find Pivot Index
        /// <summary>
        /// Given an array of integers nums, calculate the pivot 
        /// index of this array.
        /// The pivot index is the index where the sum of all the
        /// numbers strictly to the left of the index is equal to
        /// the sum of all the numbers strictly to the index's 
        /// right.
        /// If the index is on the left edge of the array, then
        /// the left sum is 0 because there are no elements to 
        /// the left.This also applies to the right edge of the 
        /// array.
        /// Return the leftmost pivot index.If no such index 
        /// exists, return -1.
        /// https://leetcode.com/problems/find-pivot-index/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int PivotIndex(int[] nums)
        {
            /*
             * Runtime: 482 ms, faster than 18.39% of C# online submissions for Find Pivot Index.
             * Memory Usage: 45.7 MB, less than 14.48% of C# online submissions for Find Pivot Index.
             */
            //for (int i = 0; i < nums.Length; i++)
            //{
            //    int leftSum = 0, rightSum = 0;
            //    int left = 0, right = nums.Length - 1;
            //    while(left < i) leftSum+=nums[left++];
            //    while(right>i) rightSum +=nums[right--];
            //    if(leftSum == rightSum) return i;
            //}
            //return -1;

            /*
             * Runtime: 184 ms, faster than 66.78% of C# online submissions for Find Pivot Index.
             * Memory Usage: 39.6 MB, less than 87.02% of C# online submissions for Find Pivot Index.
             */
            int sum = 0;
            foreach (int i in nums)
            {
                sum += i;
            }

            int temp = 0;
            for(int i = 0; i < nums.Length; i++)
            {
                if(sum - 2* temp == nums[i]) return i;
                temp += nums[i];
            }
            return -1;
        }
        #endregion

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
