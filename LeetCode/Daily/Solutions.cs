namespace LeetCode
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public partial class Solutions
    {
        public Solutions()
        {

        }

        #region 49. Group Anagrams
        /// <summary>
        /// Given an array of strings strs, group the anagrams
        /// together. You can return the answer in any order.
        /// An Anagram is a word or phrase formed by rearranging
        /// the letters of a different word or phrase, typically
        /// using all the original letters exactly once.
        /// https://leetcode.com/problems/group-anagrams/
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            /*
             * Runtime: 340 ms, faster than 49.02% of C# online submissions for Group Anagrams.
             * Memory Usage: 51.5 MB, less than 26.12% of C# online submissions for Group Anagrams.
             */
            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
            foreach (string str in strs)
            {
                char[] chars = str.ToCharArray();
                Array.Sort(chars);
                string key = string.Concat(chars);
                if (!dict.ContainsKey(key))
                {
                    dict.Add(key, new List<string>());
                }
                dict[key].Add(str);
            }
            List<IList<string>> list = new List<IList<string>>();
            foreach (KeyValuePair<string, List<string>> keyValuePair in dict)
            {
                list.Add(keyValuePair.Value);
            }
            return list;
        }
        #endregion

        #region 22. Generate Parentheses
        /// <summary>
        /// Given n pairs of parentheses, write a function to 
        /// generate all combinations of well-formed parentheses.
        /// Example 1:
        /// Input: n = 3
        /// Output: ["((()))","(()())","(())()","()(())","()()()"]
        /// Example 2:
        /// Input: n = 1
        /// Output: ["()"]
        /// Constraints:
        /// 1 <= n <= 8
        /// https://leetcode.com/problems/generate-parentheses/
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<string> GenerateParenthesis(int n)
        {
            /*
             * Runtime: 206 ms, faster than 69.64% of C# online submissions for Generate Parentheses.
             * Memory Usage: 44.7 MB, less than 56.05% of C# online submissions for Generate Parentheses.
             */
            Dictionary<int, HashSet<int>> dict = new Dictionary<int, HashSet<int>>();
            for (int i = 1; i <= n; i++)
            {
                int root = 1;
                int t = i - 1;
                while (t > 0)
                {
                    root = (root << 1) + 1;
                    t--;
                }
                root = root << i;
                dict.Add(i, new HashSet<int>());
                dict[i].Add(root);
                for (int j = 1; j <= i / 2; j++)
                {
                    foreach (int d1 in dict[i - j])
                    {
                        foreach (int d2 in dict[j])
                        {
                            dict[i].Add(d2 << 2 * (i - j) | d1);
                            dict[i].Add(d1 << 2 * j | d2);
                            if (j == 1)
                            {
                                dict[i].Add((1 << 2 * (i - j) | d1) << 1);
                            }
                        }
                    }
                }
            }
            foreach (KeyValuePair<int, HashSet<int>> keyValuePair in dict)
            {
                foreach (int i in keyValuePair.Value)
                {
                    Console.WriteLine(Convert.ToString(i, 2));
                }
            }
            List<string> ret = new List<string>();
            foreach (int i in dict[n])
            {
                ret.Add(Convert.ToString(i, 2).Replace("1", "(").Replace("0", ")"));
                Console.WriteLine(Convert.ToString(i, 2).Replace("1", "(").Replace("0", ")"));
            }
            return ret;
        }
        #endregion

        #region 1662. Check If Two String Arrays are Equivalent
        /// <summary>
        /// Given two string arrays word1 and word2, return true if the
        /// two arrays represent the same string, and false otherwise.
        /// A string is represented by an array if the array elements
        /// concatenated in order forms the string.
        /// https://leetcode.com/problems/check-if-two-string-arrays-are-equivalent/
        /// </summary>
        /// <param name="word1"></param>
        /// <param name="word2"></param>
        /// <returns></returns>
        public bool ArrayStringsAreEqual(string[] word1, string[] word2)
        {
            /*
             * Runtime: 114 ms, faster than 83.76% of C# online submissions for Check If Two String Arrays are Equivalent.
             * Memory Usage: 40.3 MB, less than 15.38% of C# online submissions for Check If Two String Arrays are Equivalent.
             */
            ArrayStrings arrayStrings1 = new ArrayStrings(word1);
            ArrayStrings arrayStrings2 = new ArrayStrings(word2);
            IEnumerator enumerator1 = arrayStrings1.GetEnumerator();
            IEnumerator enumerator2 = arrayStrings2.GetEnumerator();
            bool hasNext1 = enumerator1.MoveNext();
            bool hasNext2 = enumerator2.MoveNext();
            while (hasNext1 && hasNext2)
            {
                if (!enumerator1.Current.Equals(enumerator2.Current))
                {
                    return false;
                }
                hasNext1 = enumerator1.MoveNext();
                hasNext2 = enumerator2.MoveNext();
            }
            if (hasNext1 == hasNext2 && enumerator1.Current.Equals(enumerator2.Current))
            {
                return true;
            }
            else
            {
                return false;
            }
            /*
             * Runtime: 97 ms, faster than 94.87% of C# online submissions for Check If Two String Arrays are Equivalent.
             * Memory Usage: 40.9 MB, less than 8.55% of C# online submissions for Check If Two String Arrays are Equivalent.
             */
            // return String.Join("", word1).Equals(String.Join("", word2));

            /*
             * Runtime: 151 ms, faster than 58.97% of C# online submissions for Check If Two String Arrays are Equivalent.
             * Memory Usage: 39.6 MB, less than 47.86% of C# online submissions for Check If Two String Arrays are Equivalent.
             */
            //int i = 0, j = 0;
            //int m = 0, n = 0;
            //while(i < word1.Length && j < word2.Length)
            //{
            //    if (m == word1[i].Length || n == word2[j].Length)
            //    {
            //        if (m == word1[i].Length)
            //        {
            //            m = 0;
            //            i++;
            //        }
            //        if (n == word2[j].Length)
            //        {
            //            n = 0;
            //            j++;
            //        }
            //        continue;
            //    }
            //    if(word1[i][m] == word2[j][n])
            //    {
            //        m++;
            //        n++;
            //        continue;
            //    }
            //    else
            //    {
            //        return false;
            //    }
            //}
            //if (i == word1.Length && m == 0 && j == word2.Length && n == 0)
            //    return true;
            //else
            //    return false;
        }

        class ArrayStrings : IEnumerable
        {
            private string[] words;
            public ArrayStrings(string[] words)
            {
                this.words = words;
            }
            public IEnumerator GetEnumerator()
            {
                foreach (string word in this.words)
                {
                    foreach (char c in word)
                    {
                        yield return c;
                    }
                }
            }
        }
        #endregion

        #region TODO 1239. Maximum Length of a Concatenated String with Unique Characters
        /// <summary>
        /// You are given an array of strings arr. A string s is formed by the 
        /// concatenation of a subsequence of arr that has unique characters.
        /// A subsequence is an array that can be derived from another array 
        /// by deleting some or no elements without changing the order of the
        /// remaining elements.
        /// https://leetcode.com/problems/maximum-length-of-a-concatenated-string-with-unique-characters/
        /// </summary>
        /// <param name="arr"></param>
        /// <returns>Return the maximum possible length of s.</returns>
        public int MaxLength(IList<string> arr)
        {
            int[] array = new int[arr.Count];
            for (int i = 0; i < arr.Count; i++)
            {
                array[i] = 0;
                foreach (char c in arr[i])
                {
                    int t = 1 << c - 'a';
                    if ((array[i] & t) == 0)
                    {
                        array[i] += t;
                    }
                    else
                    {
                        array[i] = 0;
                        break;
                    }
                }
            }
            int ret = 0;
            for (int i = 0; i < arr.Count; i++)
            {
                if (array[i] == 0) continue;
                int temp = array[i];
                int tempRet = arr[i].Length;
                List<int> conflicts = new List<int>();
                for (int j = 0; j < arr.Count; j++)
                {
                    if (i == j) continue;
                    if ((temp & array[j]) == 0)
                    {
                        temp = temp | array[j];
                        tempRet += arr[j].Length;
                    }
                    else
                    {
                        conflicts.Add(j);
                    }
                }
                foreach (int c in conflicts)
                {
                    temp = array[i];
                    tempRet = arr[i].Length;
                    if ((temp & array[c]) == 0)
                    {
                        temp = temp | array[c];
                        tempRet += arr[c].Length;
                        for (int j = 0; j < arr.Count; j++)
                        {
                            if (i == j || c == j) continue;
                            if ((temp & array[j]) == 0)
                            {
                                temp = temp | array[j];
                                tempRet += arr[j].Length;
                            }
                        }
                    }
                }
                ret = Math.Max(ret, tempRet);
            }

            return ret;
        }
        #endregion

        #region TODO 29. Divide Two Integers
        /// <summary>
        /// Given two integers dividend and divisor, divide two integers
        /// without using multiplication, division, and mod operator.
        /// The integer division should truncate toward zero, which means
        /// losing its fractional part. For example, 8.345 would be truncated
        /// to 8, and -2.7335 would be truncated to -2.
        /// Return the quotient after dividing dividend by divisor.
        /// Note: Assume we are dealing with an environment that could only
        /// store integers within the 32-bit signed integer range: 
        /// [−2<31>, 2<31> − 1]. For this problem, if the quotient is strictly
        /// greater than 2<31> - 1, then return 2<31> - 1, and if the quotient 
        /// is strictly less than -231, then return -2<31>.
        /// https://leetcode.com/problems/divide-two-integers/
        /// </summary>
        /// <param name="dividend"></param>
        /// <param name="divisor"></param>
        /// <returns></returns>
        public int Divide(int dividend, int divisor)
        {
            if (dividend == divisor) return 1;
            if ((dividend > 0 && divisor > 0 && dividend < divisor)
                || (dividend < 0 && divisor < 0 && dividend > divisor))
                return 1;
            Stack<int> stack = new Stack<int>();
            while (dividend > divisor)
            {
                stack.Push(dividend & 1);
                dividend >>= 1;
            }
            int ret = Math.Abs(dividend - divisor);
            ret <<= stack.Count;
            while (stack.Count > 0)
            {
                ret += stack.Pop();
                ret <<= stack.Count;
            }
            return ret;

            // Time Limit Exceeded
            //if (dividend == 0) return 0;
            //long ret = 0;
            //long d1 = Math.Abs((long)dividend);
            //long d2 = Math.Abs((long)divisor);
            //if (d1 == d2)
            //{
            //    ret = 1;
            //}
            //else if(d1 < d2)
            //{
            //    ret = 0;
            //}
            //else
            //{

            //    while (d1 >= d2)
            //    {
            //        d1 -= d2;
            //        ret++;
            //    }
            //}
            //if ((dividend <= 0 && divisor <= 0) || (dividend >= 0 && divisor >= 0))
            //{
            //}
            //else
            //{
            //    ret = 0 - ret;
            //}
            //if(ret > 2147483647)
            //    ret = 2147483647;
            //if (ret < -2147483648)
            //    ret = -2147483648;
            //return (int)ret;
        }
        #endregion

        #region 645. Set Mismatch
        /// <summary>
        /// You have a set of integers s, which originally contains all
        /// the numbers from 1 to n. Unfortunately, due to some error, 
        /// one of the numbers in s got duplicated to another number in
        /// the set, which results in repetition of one number and loss
        /// of another number.
        /// You are given an integer array nums representing the data 
        /// status of this set after the error.
        /// Find the number that occurs twice and the number that is 
        /// missing and return them in the form of an array.
        /// https://leetcode.com/problems/set-mismatch/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] FindErrorNums(int[] nums)
        {
            Array.Sort(nums);
            int[] result = new int[2];
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == nums[i - 1])
                {
                    result[0] = nums[i];
                    result[1] = nums[i] + 1;
                    break;
                }
            }
            return result;
        }
        #endregion

        #region 6214. Determine if Two Events Have Conflict
        /// <summary>
        /// You are given two arrays of strings that represent two inclusive 
        /// events that happened on the same day, event1 and event2, where:
        /// event1 = [startTime1, endTime1] and
        /// event2 = [startTime2, endTime2].
        /// Event times are valid 24 hours format in the form of HH:MM.
        /// A conflict happens when two events have some non-empty intersection
        /// (i.e., some moment is common to both events).
        /// Return true if there is a conflict between two events. 
        /// Otherwise, return false.
        /// </summary>
        /// <param name="event1"></param>
        /// <param name="event2"></param>
        /// <returns></returns>
        public bool HaveConflict(string[] event1, string[] event2)
        {
            if (TimeCompare(event1[1], event2[0]) == -1) return false;
            if (TimeCompare(event2[1], event1[0]) == -1) return false;
            return true;
        }

        private int TimeCompare(string time1, string time2)
        {
            int h1 = int.Parse(time1.Split(':')[0]);
            int h2 = int.Parse(time2.Split(':')[0]);
            int s1 = int.Parse(time1.Split(':')[1]);
            int s2 = int.Parse(time2.Split(':')[1]);
            if (h1 < h2) return -1;
            if (h1 > h2) return 1;
            if (s1 < s2) return -1;
            if (s1 > s2) return 1;
            return 0;
        }
        #endregion

        #region 76. Minimum Window Substring
        /// <summary>
        /// Given two strings s and t of lengths m and n respectively, 
        /// return the minimum window substring of s such that every 
        /// character in t (including duplicates) is included in the window. 
        /// If there is no such substring, return the empty string "".
        /// The testcases will be generated such that the answer is unique.
        /// A substring is a contiguous sequence of characters within the string.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public string MinWindow(string s, string t)
        {
            //Dictionary<char, int> dicts = new Dictionary<char, int>();
            //Dictionary<char, int> dictt = new Dictionary<char, int>();
            //foreach(char c in s)
            //{
            //    if (dicts.ContainsKey(c))
            //    {
            //        dicts[c] = dicts[c] + 1;
            //    }
            //    else
            //    {
            //        dicts.Add(c, 1);
            //    }
            //}
            //foreach (char c in t)
            //{
            //    if (dictt.ContainsKey(c))
            //    {
            //        dictt[c] = dictt[c] + 1;
            //    }
            //    else
            //    {
            //        dictt.Add(c, 1);
            //    }
            //}
            //foreach(KeyValuePair<char, int> kvp in dictt)
            //{
            //    if(!dicts.ContainsKey(kvp.Key) || dicts[kvp.Key] < dictt[kvp.Key])
            //    {
            //        return "";
            //    }
            //}
            //dicts = new Dictionary<char, int>();
            //foreach(char c in s)
            //{

            //}
            return "";
        }
        #endregion

        #region 219. Contains Duplicate II
        /// <summary>
        /// Given an integer array nums and an integer k, return true
        /// if there are two distinct indices i and j in the array such
        /// that nums[i] == nums[j] and abs(i - j) <= k.
        /// https://leetcode.com/problems/contains-duplicate-ii/submissions/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            /*
             * Runtime: 457 ms, faster than 33.74% of C# online submissions for Contains Duplicate II.
             * Memory Usage: 51 MB, less than 37.59% of C# online submissions for Contains Duplicate II.
             */
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (dict.ContainsKey(nums[i]))
                {
                    if (i - dict[nums[i]] <= k)
                        return true;
                    else
                        dict[nums[i]] = i;
                }
                else
                    dict.Add(nums[i], i);
            }
            return false;
        }
        #endregion

        #region 2437. Number of Valid Clock Times
        /// <summary>
        /// You are given a string of length 5 called time, representing the 
        /// current time on a digital clock in the format "hh:mm". The earliest
        /// possible time is "00:00" and the latest possible time is "23:59".
        /// </summary>
        /// <param name="time">In the string time, the digits represented by 
        /// the ? symbol are unknown, and must be replaced with a digit from 0 to 9.
        /// </param>
        /// <returns>Return an integer answer, the number of valid clock times
        /// that can be created by replacing every ? with a digit from 0 to 9.
        /// </returns>
        /// 
        /*
         * Example 1:

            Input: time = "?5:00"
            Output: 2
            Explanation: We can replace the ? with either a 0 or 1, producing "05:00" or "15:00". Note that we cannot replace it with a 2, since the time "25:00" is invalid. In total, we have two choices.

            Example 2:

            Input: time = "0?:0?"
            Output: 100
            Explanation: Each ? can be replaced by any digit from 0 to 9, so we have 100 total choices.

            Example 3:

            Input: time = "??:??"
            Output: 1440
            Explanation: There are 24 possible choices for the hours, and 60 possible choices for the minutes. In total, we have 24 * 60 = 1440 choices.

         */
        public int CountTime(string time)
        {
            int a = 1, b = 1;
            if (time[0] == '?' && time[1] == '?')
            {
                a = 24;
            }
            else if (time[0] == '?')
            {
                if (time[1] >= '0' && time[1] < '4')
                {
                    a = 3;
                }
                else
                {
                    a = 2;
                }
            }
            else if (time[0] == '2' && time[1] == '?')
            {
                a = 4;
            }
            else if (time[1] == '?')
            {
                a = 10;
            }

            if (time[3] == '?' && time[4] == '?')
            {
                b = 60;
            }
            else if (time[3] == '?')
            {
                b = 6;
            }
            else if (time[4] == '?')
            {
                b = 10;
            }

            return a * b;
        }
        #endregion

        #region 6219. Sum of Number and Its Reverse
        /// <summary>
        /// Given a non-negative integer num, return true if num can
        /// be expressed as the sum of any non-negative integer and 
        /// its reverse, or false otherwise.
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool SumOfNumberAndReverse(int num)
        {
            for (int i = num - 1; i > 0; i--)
            {
                if (i + reverseInt(i) == num)
                    return true;
            }

            return false;
        }
        #endregion

        #region 6205. Count Number of Distinct Integers After Reverse Operations
        /// <summary>
        /// You are given an array nums consisting of positive integers.
        /// You have to take each integer in the array, reverse its digits, 
        /// and add it to the end of the array. You should apply this 
        /// operation to the original integers in nums.
        /// </summary>
        /// <param name="nums">an array nums consisting of positive integers</param>
        /// <returns>Return the number of distinct integers in the final array.</returns>
        public int CountDistinctIntegers(int[] nums)
        {
            HashSet<int> set = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                set.Add(nums[i]);
                set.Add(reverseInt(nums[i]));
            }
            return set.Count;
        }

        private int reverseInt(int val)
        {
            Queue<int> stack = new Queue<int>();
            int a = val;
            while (a != 0)
            {
                stack.Enqueue(a % 10);
                a = a / 10;
            }
            int ret = stack.Dequeue();
            while (stack.Count > 0)
            {
                ret = ret * 10 + stack.Dequeue();
            }
            return ret;
        }
        #endregion

        #region 6204. Largest Positive Integer That Exists With Its Negative
        /// <summary>
        /// Given an integer array nums that does not contain any zeros, find
        /// the largest positive integer k such that -k also exists in the array.
        /// Return the positive integer k.If there is no such integer, return -1.
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindMaxK(int[] nums)
        {
            Array.Sort(nums);
            int ret = -1;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] >= 0) break;
                for (int j = nums.Length - 1; j > i; j--)
                {
                    if (nums[j] <= 0) break;
                    if (nums[i] + nums[j] == 0)
                    {
                        ret = Math.Max(ret, nums[j]);
                    }
                }
            }
            return ret;
        }
        #endregion

        #region 6111. Spiral Matrix IV
        /**
         * Definition for singly-linked list.
         * public class ListNode {
         *     public int val;
         *     public ListNode next;
         *     public ListNode(int val=0, ListNode next=null) {
         *         this.val = val;
         *         this.next = next;
         *     }
         * }
         */
        public int[][] SpiralMatrix(int m, int n, ListNode head)
        {
            int[][] ret = new int[m][];
            for (int i = 0; i < m; i++)
            {
                ret[m] = new int[n];
                for (int j = 0; j < n; j++)
                {
                    ret[m][n] = -1;
                }
            }
            int index = 0;
            int r = 1, c = 1;
            while (head != null)
            {

                index++;
            }


            return ret;
        }
        #endregion

        #region 6108. Decode the Message
        public string DecodeMessage(string key, string message)
        {
            char a = 'a';
            Dictionary<char, char> dict = new Dictionary<char, char>();
            foreach (char c in key)
            {
                if (dict.ContainsKey(c) || c == ' ')
                {
                    continue;
                }
                dict.Add(c, a);
                a++;
            }
            StringBuilder builder = new StringBuilder();
            foreach (char c in message)
            {
                if (c == ' ')
                    builder.Append(c);
                else
                    builder.Append(dict[c]);
            }
            return builder.ToString();
        }
        #endregion

        #region
        //public int DistributeCookies(int[] cookies, int k)
        //{
        //    Array.Sort(cookies);
        //    int sum = 0;
        //    foreach (int i in cookies) sum += i;
        //    int p = sum / k;
        //    int[] bucket = new int[k];

        //}
        #endregion

        #region 5259. Calculate Amount Paid in Taxes
        public double CalculateTax(int[][] brackets, int income)
        {
            double ret = 0;
            for (int i = 0; i < brackets.Length; i++)
            {
                int tmp = brackets[i][0];
                tmp = tmp < income ? tmp : income;
                if (i > 0)
                {
                    tmp -= brackets[i - 1][0];
                }
                double r = (double)brackets[i][1] / 100;
                ret += tmp * r;
                if (brackets[i][0] >= income) break;
            }
            return ret;
        }
        #endregion

        #region 6010. Minimum Time to Complete Trips
        /// <summary>
        /// You are given an array time where time[i] denotes the time taken by the ith bus to complete one trip.
        /// Each bus can make multiple trips successively; that is, the next trip can start immediately after 
        /// completing the current trip.Also, each bus operates independently; that is, the trips of one bus do not
        /// influence the trips of any other bus.
        /// You are also given an integer totalTrips, which denotes the number of trips all buses should make in total.
        /// Return the minimum time required for all buses to complete at least totalTrips trips.
        /// </summary>
        /// <param name="time"></param>
        /// <param name="totalTrips"></param>
        /// <returns></returns>
        public long MinimumTime(int[] time, int totalTrips)
        {
            long l = 0, r = long.MaxValue / time.Length;
            while (l < r)
            {
                long m = (l + r) / 2, trips = 0;
                foreach (int t in time)
                    trips += m / t;
                if (trips < totalTrips)
                    l = m + 1;
                else
                    r = m;
            }
            return l;
        }
        #endregion

        #region 6009. Minimum Number of Steps to Make Two Strings Anagram II
        /// <summary>
        /// You are given two strings s and t. In one step, you can append
        /// any character to either s or t.
        /// Return the minimum number of steps to make s and t anagrams of each other.
        /// An anagram of a string is a string that contains the same characters with
        /// a different(or the same) ordering.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public int MinSteps(string s, string t)
        {
            Dictionary<char, int> dicts = new Dictionary<char, int>();
            Dictionary<char, int> dictt = new Dictionary<char, int>();
            for (char a = 'a'; a <= 'z'; a++)
            {
                dicts.Add(a, 0);
                dictt.Add(a, 0);
            }
            foreach (char c in s)
            {
                dicts[c] = dicts[c] + 1;
            }
            foreach (char c in t)
            {
                if (dicts[c] > 0)
                {
                    dicts[c] = dicts[c] - 1;
                }
                else
                {
                    dictt[c] = dictt[c] + 1;
                }
            }
            int ret = 0;
            for (char c = 'a'; c <= 'z'; c++)
            {
                ret += dicts[c] + dictt[c];
            }
            return ret;
        }
        #endregion

        #region 6008. Counting Words With a Given Prefix
        /// <summary>
        /// You are given an array of strings words and a string pref.
        /// Return the number of strings in words that contain pref as a prefix.
        /// A prefix of a string s is any leading contiguous substring of s.
        /// </summary>
        /// <param name="words"></param>
        /// <param name="pref"></param>
        /// <returns></returns>
        public int PrefixCount(string[] words, string pref)
        {
            int ret = 0;
            foreach (string word in words)
            {
                if (word.StartsWith(pref))
                    ret++;
            }
            return ret;
        }
        #endregion

        #region 5916. Minimum Operations to Convert Number
        /// <summary>
        /// You are given a 0-indexed integer array nums containing distinct numbers, 
        /// an integer start, and an integer goal. 
        /// There is an integer x that is initially set to start, and you want to perform
        /// operations on x such that it is converted to goal. You can perform the following 
        /// operation repeatedly on the number x:
        /// If 0 <= x <= 1000, then for any index i in the array(0 <= i<nums.length), 
        /// you can set x to any of the following:
        /// x + nums[i]
        /// x - nums[i]
        /// x ^ nums[i] (bitwise-XOR)
        /// Note that you can use each nums[i] any number of times in any order.
        /// Operations that set x to be out of the range 0 <= x <= 1000 are valid,
        /// but no more operations can be done afterward.
        /// Return the minimum number of operations needed to convert x = start into goal, 
        /// and -1 if it is not possible.
        /// 
        /// Example 1:
        /// Input: nums = [1,3], start = 6, goal = 4
        /// Output: 2
        /// Explanation:
        /// We can go from 6 → 7 → 4 with the following 2 operations.
        /// - 6 ^ 1 = 7
        /// - 7 ^ 3 = 4
        /// 
        /// Example 2:
        /// Input: nums = [2,4,12], start = 2, goal = 12
        /// Output: 2
        /// Explanation:
        /// We can go from 2 → 14 → 12 with the following 2 operations.
        /// - 2 + 12 = 14
        /// - 14 - 2 = 12
        /// 
        /// Example 3:
        /// Input: nums = [3,5,7], start = 0, goal = -4
        /// Output: 2
        /// Explanation:
        /// We can go from 0 → 3 → -4 with the following 2 operations.
        /// - 0 + 3 = 3
        /// - 3 - 7 = -4
        /// Note that the last operation sets x out of the range 0 <= x <= 1000, which is valid.
        /// 
        /// Example 4:
        /// Input: nums = [2,8,16], start = 0, goal = 1
        /// Output: -1
        /// Explanation:
        /// There is no way to convert 0 into 1.
        /// 
        /// Example 5:
        /// Input: nums = [1], start = 0, goal = 3
        /// Output: 3
        /// Explanation: 
        /// We can go from 0 → 1 → 2 → 3 with the following 3 operations.
        /// - 0 + 1 = 1 
        /// - 1 + 1 = 2
        /// - 2 + 1 = 3
        /// 
        /// Constraints:
        /// 1 <= nums.length <= 1000
        /// -109 <= nums[i], goal <= 109
        /// 0 <= start <= 1000
        /// start != goal
        /// All the integers in nums are distinct.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="start"></param>
        /// <param name="goal"></param>
        /// <returns></returns>
        public int MinimumOperations(int[] nums, int start, int goal)
        {
            return -1;
        }
        #endregion

        #region 5915. Find the Minimum and Maximum Number of Nodes Between Critical Points
        /**
         * Definition for singly-linked list.
         * public class ListNode {
         *     public int val;
         *     public ListNode next;
         *     public ListNode(int val=0, ListNode next=null) {
         *         this.val = val;
         *         this.next = next;
         *     }
         * }
         */

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        /// <summary>
        /// A critical point in a linked list is defined as either a local maxima or a local minima.
        /// A node is a local maxima if the current node has a value strictly greater than the previous
        /// node and the next node.
        /// A node is a local minima if the current node has a value strictly smaller than the previous
        /// node and the next node.
        /// Note that a node can only be a local maxima/minima if there exists both a previous node and a next node.
        /// Given a linked list head, return an array of length 2 containing[minDistance, maxDistance] 
        /// where minDistance is the minimum distance between any two distinct critical points and maxDistance 
        /// is the maximum distance between any two distinct critical points.
        /// If there are fewer than two critical points, return [-1, -1].
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public int[] NodesBetweenCriticalPoints(ListNode head)
        {
            int[] ret = new int[] { int.MaxValue, 0 };
            int index = 0;
            int pre = -1;
            int current = -1;
            while (head.next != null)
            {
                index++;
                bool b = NextNodeIsLocalMaxOrMin(head);
                if (b)
                {
                    pre = current;
                    current = index;
                }
                if (pre != current && pre != -1)
                {
                    ret[0] = Math.Min(ret[0], current - pre);
                    ret[1] = ret[1] + current - pre;
                    pre = current;
                }
                head = head.next;
            }
            if (ret[0] == int.MaxValue)
            {
                ret = new int[] { -1, -1 };
            }
            return ret;
        }

        private bool NextNodeIsLocalMaxOrMin(ListNode head)
        {
            if (head.next != null & head.next.next != null)
            {
                ListNode middle = head.next;
                ListNode previous = head;
                ListNode next = middle.next;
                if ((middle.val > previous.val && middle.val > next.val)
                    || (middle.val < previous.val && middle.val < next.val))
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region
        public int SmallestEqual(int[] nums)
        {
            int ret = int.MaxValue;
            for (int i = 0; i < nums.Length; i++)
            {
                if (i % 10 == nums[i])
                {
                    ret = Math.Min(ret, i);
                }
            }

            return ret == int.MaxValue ? -1 : ret;
        }
        #endregion

        #region Rearrange Spaces Between Words
        //public string ReorderSpaces(string text)
        //{
        //    Stack<byte> stack = new Stack<byte>();
        //    foreach(char c in text)
        //    {
        //        if ((c == ' ' && stack.Peek() == 0)
        //            || (c != ' ' && stack.Peek() == 1))
        //        {
        //            continue;
        //        }
        //        else if (c == ' ')
        //            stack.Push(0);
        //        else
        //            stack.Push(1);
        //    }
        //}
        #endregion

        #region 5499. Detect Pattern of Length M Repeated K or More Times
        public bool ContainsPattern(int[] arr, int m, int k)
        {
            bool ret = false;
            for (int i = 0; i < arr.Length - m; i++)
            {
                if ((arr.Length - i) / m < k) return false;
                int count = 0;
                for (int l = i; l < arr.Length - m; l += m)
                {
                    if (count == k) return true;
                    bool _equal = true;
                    for (int j = 0; j < m && l + m + j < arr.Length; j++)
                    {
                        if (arr[l + j] != arr[l + m + j])
                        {
                            _equal = false;
                            break;
                        }
                    }
                    if (_equal) count++;
                    else
                    {
                        count = 0;
                        continue;
                    }
                }
            }

            return ret;
        }
        #endregion

        #region
        //public int MaxDistance(int[] position, int m)
        //{

        //}
        #endregion

        #region 5488. Minimum Operations to Make Array Equal
        public int MinOperations(int n)
        {
            if (n % 2 == 0)
            {
                int ret = 0;
                for (int i = 0; i < n / 2; i++)
                {
                    ret += 2 * i + 1;
                }
                return ret;
            }
            else
            {
                int k = 0;
                for (int i = 0; i < n; i++)
                {
                    k += 2 * i + 1;
                }
                k = k / n;
                int ret = 0;
                for (int i = 0; i < n / 2; i++)
                {
                    ret += k - (2 * i + 1);
                }
                return ret;
            }
        }

        private int FMinOperations(int n)
        {
            return 0;
        }
        #endregion

        #region
        public bool ThreeConsecutiveOdds(int[] arr)
        {
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 != 0)
                {
                    count++;
                    if (count == 3)
                        return true;
                }
                else
                    count = 0;
            }
            return false;
        }
        #endregion

        #region 1536. Minimum Swaps to Arrange a Binary Grid
        public int MinSwaps(int[][] grid)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int row = 0; row < grid.Length; row++)
            {
                for (int col = grid[0].Length - 1; col > row; col--)
                {
                    int i = grid[row][col];
                    if (i == 1)
                    {
                        if (dict.ContainsKey(col))
                            return -1;
                        else
                            dict.Add(col, row);
                    }
                }
            }
            foreach (KeyValuePair<int, int> pair in dict)
            {

            }

            return -1;
        }
        #endregion

        #region 5476. Find the Winner of an Array Game
        public int GetWinner(int[] arr, int k)
        {
            if (k >= arr.Length - 1)
            {
                Array.Sort(arr);
                return arr[arr.Length - 1];
            }
            int ret = arr[0];
            int count = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                if (count == k)
                {
                    break;
                }
                if (ret > arr[i])
                {
                    count++;
                }
                else
                {
                    ret = arr[i];
                    count = 1;
                }
            }

            return ret;
        }
        #endregion

        #region 5475. Count Good Triplets
        public int CountGoodTriplets(int[] arr, int a, int b, int c)
        {
            int ret = 0;
            for (int i = 0; i < arr.Length - 2; i++)
            {
                for (int j = i + 1; j < arr.Length - 1; j++)
                {
                    for (int k = j + 1; k < arr.Length; k++)
                    {
                        if (Math.Abs(arr[i] - arr[j]) <= a
                            && Math.Abs(arr[j] - arr[k]) <= b
                            && Math.Abs(arr[i] - arr[k]) <= c)
                            ret++;

                    }
                }
            }
            return ret;
        }
        #endregion

        #region 5466. Maximum Number of Non-Overlapping Substrings
        public IList<string> MaxNumOfSubstrings(string s)
        {
            List<string> ret = new List<string>();
            Dictionary<char, int> dict = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (dict.ContainsKey(c))
                {
                    dict[c] = dict[c] + 1;
                }
                else
                {
                    dict.Add(c, 1);
                }
            }

            return ret;
        }
        #endregion

        #region 5464. Water Bottles
        /// <summary>
        /// Given numBottles full water bottles, you can exchange numExchange
        /// empty water bottles for one full water bottle.
        /// The operation of drinking a full water bottle turns it into an empty bottle.
        /// Return the maximum number of water bottles you can drink.
        /// </summary>
        /// <param name="numBottles"></param>
        /// <param name="numExchange"></param>
        /// <returns></returns>
        public int NumWaterBottles(int numBottles, int numExchange)
        {
            int ret = numBottles;
            int mod = 0;
            int div = 0;
            while (numBottles > numExchange)
            {
                mod = numBottles % numExchange;
                div = numBottles / numExchange;
                ret += div;
                numBottles = mod + div;
            }
            return ret;
        }
        #endregion

        #region 5441. Making File Names Unique
        public string[] GetFolderNames(string[] names)
        {
            List<string> list = new List<string>();
            Dictionary<string, int> dict = new Dictionary<string, int>();
            foreach (string name in names)
            {
                if (dict.ContainsKey(name) || list.Contains(name))
                {
                    if (dict.ContainsKey(name))
                    {
                        int i = dict[name];
                        while (list.Contains(name + string.Format("({0})", i)))
                        {
                            i++;
                        }
                        list.Add(name + string.Format("({0})", i));
                        dict[name] = i;
                    }
                    else
                    {
                        int i = 1;
                        while (list.Contains(name + string.Format("({0})", i)))
                        {
                            i++;
                        }
                        list.Add(name + string.Format("({0})", i));
                        dict.Add(name, i);
                    }
                }
                else
                {
                    dict.Add(name, 1);
                    list.Add(name);
                }
            }

            return list.ToArray();
        }
        #endregion

        #region 5440. XOR Operation in an Array
        public int XorOperation(int n, int start)
        {
            int ret = start;
            for (int i = 1; i < n; i++)
            {
                ret = ret ^ (start + 2 * i);
            }
            return ret;
        }
        #endregion

        #region
        public int MinDays(int[] bloomDay, int m, int k)
        {
            if (m * k > bloomDay.Length)
                return -1;
            int left = 1;
            int right = 1;
            for (int j = 0; j < bloomDay.Length; j++)
                if (right < bloomDay[j])
                    right = bloomDay[j];
            while (left < right)
            {
                int mid = (left + right) / 2;
                int flower = 0;
                int bouquet = 0;
                for (int i = 0; i < bloomDay.Length; i++)
                {
                    if (bloomDay[i] > mid)
                        flower = 0;
                    else if (++flower == k)
                    {
                        bouquet++;
                        flower = 0;
                    }
                }
                if (bouquet < m)
                    left = mid;
                else
                    right = mid;
            }
            return left;
        }
        #endregion

        #region
        public int FindLeastNumOfUniqueInts(int[] arr, int k)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            foreach (int i in arr)
            {
                if (dict.ContainsKey(i))
                    dict[i]++;
                else
                    dict.Add(i, 1);
            }
            int[] tmp = new int[dict.Count];
            int index = 0;
            foreach (KeyValuePair<int, int> pair in dict)
            {
                tmp[index++] = pair.Value;
            }
            Array.Sort(tmp);
            int ret = tmp.Length;
            for (int j = 0; j < tmp.Length; j++)
            {
                k = k - tmp[j];
                if (k >= 0)
                    ret--;
                if (k <= 0)
                    break;
            }
            return ret;
        }
        #endregion

        #region 5436. Running Sum of 1d Array
        /// <summary>
        /// 5436. Running Sum of 1d Array
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] RunningSum(int[] nums)
        {
            for (int i = 1; i < nums.Length; i++)
            {
                nums[i] = nums[i] + nums[i - 1];
            }
            return nums;
        }

        public int[] Shuffle(int[] nums, int n)
        {
            int[] tmp = new int[n];
            for (int i = 0; i < n; i++)
            {
                tmp[i] = nums[i + n];
            }
            for (int i = n - 1; i > 0; i--)
            {
                nums[2 * i] = nums[i];
            }
            int j = 0;
            for (int i = 1; i < 2 * n - 1; i += 2)
            {
                nums[i] = tmp[j++];
            }

            return nums;
        }
        #endregion

        #region 5418. Pseudo-Palindromic Paths in a Binary Tree
        public int PseudoPalindromicPaths(TreeNode root)
        {
            int ret = 0;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            Stack<int> flag = new Stack<int>();
            List<int> records = new List<int>();
            stack.Push(root);
            flag.Push(2);
            records.Add(root.val);

            return ret;
        }
        #endregion

        #region 5417. Maximum Number of Vowels in a Substring of Given Length
        /// <summary>
        /// Given a string s and an integer k.
        /// Return the maximum number of vowel letters in any substring of s with length k.
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MaxVowels(string s, int k)
        {
            int tmpMax = 0;
            int index = 0;
            Dictionary<int, int> dic = new Dictionary<int, int>();
            foreach (char c in s)
            {
                if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u')
                    dic.Add(index, 1);
                else
                    dic.Add(index, 0);
                index++;
            }

            for (int i = 0; i < k; i++)
            {
                if (i == s.Length) break;
                tmpMax += dic[i];
            }

            int ret = tmpMax;
            for (int j = k; j < s.Length; j++)
            {
                tmpMax = tmpMax - dic[j - k] + dic[k];
                ret = Math.Max(ret, tmpMax);
            }

            return ret;
        }
        #endregion

        #region
        public int IsPrefixOfWord(string sentence, string searchWord)
        {
            int ret = -1;
            string[] strs = sentence.Split(' ');
            for (int i = 0; i < strs.Length; i++)
            {
                for (int j = 0; j < searchWord.Length; j++)
                {
                    if (j >= strs[i].Length) break;
                    if (strs[i][j] != searchWord[j]) break;
                    if (j == searchWord.Length - 1) return i + 1;
                }
            }

            return ret;
        }
        #endregion

        #region 5412. Number of Students Doing Homework at a Given Time
        /// <summary>
        /// Given two integer arrays startTime and endTime and given an integer queryTime.
        /// The ith student started doing their homework at the time startTime[i] and finished
        /// it at time endTime[i].
        /// Return the number of students doing their homework at time queryTime.
        /// More formally, return the number of students where queryTime lays in the 
        /// interval[startTime[i], endTime[i]] inclusive.
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="queryTime"></param>
        /// <returns></returns>
        public int BusyStudent(int[] startTime, int[] endTime, int queryTime)
        {
            return -1;
        }
        #endregion

        #region 5405. Count Triplets That Can Form Two Arrays of Equal XOR
        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int CountTriplets(int[] arr)
        {
            int ret = 0, left = -1, right = -1;
            for (int i = 1; i < arr.Length; i++)
            {
                ret += CountTriplets(arr, 0, i, ref left)
                    + CountTriplets(arr, i + 1, arr.Length - 1, ref right);
                if (left >= 0 && right >= 0)
                    ret += left == right ? 1 : 0;
            }
            return ret;
        }

        private int CountTriplets(int[] arr, int start, int end, ref int var)
        {
            if (start >= end)
            {
                var = arr[end];
                return 0;
            }
            if (start + 1 == end)
            {
                var = arr[start] ^ arr[end];
                return var == 0 ? 1 : 0;
            }
            int ret = 0, left = -1, right = -1;
            var = -1;
            for (int i = start + 1; i < end; i++)
            {
                ret += CountTriplets(arr, start, i, ref left)
                    + CountTriplets(arr, i + 1, end, ref right);
                if (left >= 0 && right >= 0)
                {
                    ret += left == right ? 1 : 0;
                    var = left ^ right;
                }
            }
            return ret;
        }
        #endregion

        #region 5404. Build an Array With Stack Operations
        /// <summary>
        /// Given an array target and an integer n. In each iteration, 
        /// you will read a number from  list = {1,2,3..., n}.
        /// Build the target array using the following operations:
        /// Push: Read a new element from the beginning list, and push it in the array.
        /// Pop: delete the last element of the array.
        /// If the target array is already built, stop reading more elements.
        /// You are guaranteed that the target array is strictly increasing,
        /// only containing numbers between 1 to n inclusive.
        /// Return the operations to build the target array.
        /// You are guaranteed that the answer is unique.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<string> BuildArray(int[] target, int n)
        {
            int index = -1;
            List<string> ret = new List<string>();
            for (int i = 1; i <= n; i++)
            {
                index++;
                if (index >= target.Length)
                    break;
                if (i == target[index])
                    ret.Add("Push");
                else
                {
                    index--;
                    ret.Add("Push");
                    ret.Add("Pop");
                }
            }
            return ret;
        }
        #endregion

        #region 5402. Longest Continuous Subarray With Absolute Diff Less Than or Equal to Limit
        public int LongestSubarray(int[] nums, int limit)
        {
            if (limit == 0) return nums.Length;

            int max = 1;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (max > nums.Length - i) break;
                int tmp = 1;
                int tMax = nums[i], tMin = nums[i];
                for (int j = i + 1; j < nums.Length; j++)
                {
                    tMax = Math.Max(tMax, nums[j]);
                    tMin = Math.Min(tMin, nums[j]);
                    if (Math.Abs(tMax - tMin) <= limit)
                        tmp++;
                    else
                        break;
                }

                max = Math.Max(max, tmp);
            }

            return max;
        }
        #endregion

        #region 5401. Check If All 1's Are at Least Length K Places Away
        public bool KLengthApart(int[] nums, int k)
        {
            int distance = -1;
            int ret = 0;
            foreach (int i in nums)
            {
                ret += i;
                if (ret == 0)
                    continue;
                if (ret == 1)
                    distance++;
                if (ret == 2)
                {
                    if (distance < k)
                        return false;
                    else
                    {
                        ret = 1;
                        distance = 0;
                    }
                }
            }

            return true;
        }
        #endregion

        #region 5400. Destination City
        /*
         * You are given the array paths, where paths[i] = [cityAi, cityBi] means
         * there exists a direct path going from cityAi to cityBi. 
         * Return the destination city, that is, the city without any path outgoing
         * to another city.
         * It is guaranteed that the graph of paths forms a line without any loop, 
         * therefore, there will be exactly one destination city.
         */
        public string DestCity(IList<IList<string>> paths)
        {
            string ret = string.Empty;
            List<string> reachable = new List<string>();
            List<string> unreachabel = new List<string>();

            foreach (IList<string> path in paths)
            {
                if (!reachable.Contains(path[0]))
                    reachable.Add(path[0]);
                if (unreachabel.Contains(path[0]))
                    unreachabel.Remove(path[0]);

                if (!reachable.Contains(path[1]))
                    unreachabel.Add(path[1]);
            }

            return unreachabel.Count == 0 ? ret : unreachabel[0];
        }

        #endregion

        #region 5388. Reformat The String
        /// <summary>
        /// Given alphanumeric string s. (Alphanumeric string is a string consisting 
        /// of lowercase English letters and digits).
        /// You have to find a permutation of the string where no letter is followed 
        /// by another letter and no digit is followed by another digit.That is, no 
        /// two adjacent characters have the same type.
        /// Return the reformatted string or return an empty string if it is impossible
        /// to reformat the string.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string Reformat(string s)
        {
            StringBuilder bufferChar = new StringBuilder();
            StringBuilder bufferNum = new StringBuilder();
            foreach (char c in s)
            {
                if (c >= 'a' && c <= 'z')
                    bufferChar.Append(c);
                else
                    bufferNum.Append(c);
            }

            if (Math.Abs(bufferChar.Length - bufferNum.Length) > 1)
                return string.Empty;

            StringBuilder longStr = bufferChar.Length >= bufferNum.Length ? bufferChar : bufferNum;
            StringBuilder shortStr = bufferChar.Length < bufferNum.Length ? bufferChar : bufferNum;

            for (int i = 0; i < shortStr.Length; i++)
            {
                longStr.Insert(i * 2 + 1, shortStr[i]);
            }

            return longStr.ToString();
        }
        #endregion

        public int FindLucky(int[] arr)
        {
            Array.Sort(arr);
            int ret = -1;
            int max = arr[arr.Length - 1];
            int fre = 1;
            for (int i = arr.Length - 1; i > 0; i--)
            {
                if (arr[i] == arr[i - 1])
                {
                    fre++;
                    if (fre <= max)
                        continue;
                    else
                    {
                        fre = 0;
                        while (i > 0 && arr[i] == arr[i - 1]) i--;
                        max = i > 0 ? arr[i - 1] : arr[i];
                    }
                }
                else
                {
                    if (fre == max)
                    {
                        return max;
                    }
                    else
                    {
                        max = arr[i - 1];
                        fre = 1;
                    }
                }
            }

            if (fre == max)
            {
                return max;
            }

            return ret;
        }

        public int NumTeams(int[] rating)
        {
            int ret = 0;
            if (rating == null || rating.Length < 3) return ret;
            if (rating.Length == 3)
            {
                if (rating[0] > rating[1] && rating[1] > rating[2])
                    ret++;
                if (rating[0] < rating[1] && rating[1] < rating[2])
                    ret++;
                return ret;
            }
            return ret;
        }
    }
}
