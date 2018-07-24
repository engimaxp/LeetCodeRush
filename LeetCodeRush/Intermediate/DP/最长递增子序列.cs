using System;
using NUnit.Framework;

namespace LeetCodeRush.Intermediate.DP
{
    [TestFixture]
    public class 最长递增子序列
    {
        public class Solution
        {
            public int LengthOfLIS(int[] nums)
            {
                int[] dp = new int[nums.Length];
                int len = 0;
                foreach (int num in nums)
                {
                    int i = Array.BinarySearch(dp, 0, len, num);
                    if (i < 0)
                    {
                        i = -(i + 1);
                    }
                    dp[i] = num;
                    if (i == len)
                    {
                        len++;
                    }
                }
                return len;
            }
        }

        [Test]
        public void TestMethods()
        {
            var result = new Solution().LengthOfLIS(new[] { 10, 9, 2, 5, 3, 7, 101, 18 });
            Assert.AreEqual(4, result);
        }
    }
}