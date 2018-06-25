using System;
using NUnit.Framework;

namespace LeetCodeRush.Simple.DPTest
{
    [TestFixture]
    public class 买卖股票的最佳时机
    {
        [Test]
        public void TestSample1()
        {
            int[] strs = new[] { 7, 1, 5, 3, 6, 4 };
            var result = new Solution().MaxProfit(strs);
            Assert.AreEqual(5, result);
        }
        [Test]
        public void TestSample2()
        {
            int[] strs = new[] { 7, 6, 4, 3, 1};
            var result = new Solution().MaxProfit(strs);
            Assert.AreEqual(0, result);
        }
        public class Solution
        {
            public int MaxProfit(int[] prices)
            {
                // write your code here
                if (prices.Length < 2)
                    return 0;
                int low = prices[0];
                int max = 0;//代表买卖股票的差价
                for (int i = 1; i < prices.Length; i++)
                {
                    max = (max >= prices[i] - low) ? max : prices[i] - low;
                    low = (low <= prices[i]) ? low : prices[i];
                }
                return max;
            }
        }
    }
}