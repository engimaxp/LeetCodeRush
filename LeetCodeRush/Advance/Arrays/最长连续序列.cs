using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace LeetCodeRush.Advance.Arrays
{
    [TestFixture]
    public class 最长连续序列
    {
        /// <summary>
        /// 给定一个未排序的整数数组，找出最长连续序列的长度。
        /// 要求算法的时间复杂度为 O(n)。
        /// 
        /// 示例:
        /// 
        /// 输入: [100, 4, 200, 1, 3, 2]
        /// 输出: 4
        /// 解释: 最长连续序列是[1, 2, 3, 4]。它的长度为 4。
        /// </summary>
        public class Solution
        {
            public int LongestConsecutive(int[] nums)
            {
                int res = 0;
                HashSet<int> s = new HashSet<int>();
                foreach (var num in nums)
                {
                    s.Add(num);
                }

                foreach (var num in nums)
                {
                    if (s.Remove(num))
                    {
                        int pre = num - 1, next = num + 1;
                        while (s.Remove(pre)) --pre;
                        while (s.Remove(next)) ++next;
                        res = Math.Max(res, next - pre - 1);
                    }
                }
                return res;
            }
        }
        [Test]
        public void TestMethod()
        {
            Assert.AreEqual(4, new Solution().LongestConsecutive(new int[]{ 100, 4, 200, 1, 3, 2 }));
        }
    }
}