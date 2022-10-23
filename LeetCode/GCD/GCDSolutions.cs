namespace LeetCode
{
    using System;
    using System.Collections.Generic;

    public partial class Solutions
    {
        #region 2447. Number of Subarrays With GCD Equal to K
        /// <summary>
        /// Given an integer array nums and an integer k, return the
        /// number of subarrays of nums where the greatest common 
        /// divisor of the subarray's elements is k.
        /// https://leetcode.com/problems/number-of-subarrays-with-gcd-equal-to-k/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int SubarrayGCD(int[] nums, int k)
        {
            int ret = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                int gcdValue = 0;
                for (int j = i; j < nums.Length; j++)
                {
                    gcdValue = gcd1(nums[j], gcdValue);
                    if (gcdValue == k) ret++;
                    else break;
                }
            }
            return ret;
        }
        #endregion

        #region 1979. Find Greatest Common Divisor of Array
        /// <summary>
        /// Given an integer array nums, return the greatest common
        /// divisor of the smallest number and largest number in nums.
        /// The greatest common divisor of two numbers is the largest
        /// positive integer that evenly divides both numbers.
        /// https://leetcode.com/problems/find-greatest-common-divisor-of-array/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindGCD(int[] nums)
        {
            Array.Sort(nums);
            // Solution1: return gcd1(nums[0], nums[nums.Length - 1]);
            // Solution2:
            int min = nums[0];
            int max = nums[nums.Length - 1];
            while (max - min != 0)
            {
                int temp = Math.Max(min, max - min);
                min = Math.Min(min, max - min);
                max = temp;
            }
            return min;
        }
        #endregion

        #region 1952. Three Divisors
        /// <summary>
        /// Given an integer n, return true if n has exactly three
        /// positive divisors. Otherwise, return false.
        /// An integer m is a divisor of n if there exists an integer
        /// k such that n = k * m.
        /// https://leetcode.com/problems/three-divisors/
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool IsThree(int n)
        {
            return false;
        }

        /*
         * Runtime: 41 ms
         * Memory Usage: 27.6 MB
         */
        public bool IsThree1(int n)
        {
            List<int> list = new List<int>();
            for (int i = 1; i <= n; i++)
            {
                if (!list.Contains(i)) {
                    if (n % i == 0)
                    {
                        list.Add(i);
                        if (list.Count > 3) break;
                    }
                }
            }
            return list.Count == 3;
        }

        /*
         * Runtime: 48 ms
         * Memory Usage: 27 MB
         */
        public bool IsThree2(int n)
        {
            if (n <= 3) return false;
            double d = Math.Sqrt(n);
            int i = (int)d;
            double d1 = d - i;
            if (d1 > 0) return false;
            else
            {
                for (int j = 2; j < i; j++)
                {
                    if (n % j == 0) return false;
                }
                return !IsThree2(i);
            }
        }

        /*
         * Runtime: 45 ms
         * Memory Usage: 29 MB
         */
        public bool IsThree3(int n)
        {
            HashSet<int> list = new HashSet<int>();
            for (int i = 1; i <= n; i++)
            {
                if (!list.Contains(i))
                {
                    if (n % i == 0)
                    {
                        list.Add(i);
                        list.Add(n / i);
                        if (list.Count > 3) break;
                    }
                }
            }
            return list.Count == 3;
        }
        #endregion

        private int gcd1(int a, int b)
        {
            if (b == 0) return a;
            return gcd1(b, a % b);
        }
    }
}
