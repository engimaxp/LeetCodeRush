using NUnit.Framework;

namespace LeetCodeRush.Simple.ArrayTest
{
    [TestFixture]
    public class 买卖股票的最佳时机II
    {
        [TestCase(new[] { 7, 1, 5, 3, 6, 4 }, ExpectedResult = 7)]
        [TestCase(new[] { 7, 1, 4, 8, 3, 6 }, ExpectedResult = 10)]
        [TestCase(new[] { 7, 1, 4,2, 8, 3, 6 }, ExpectedResult = 12)]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, ExpectedResult = 4)]
        [TestCase(new[] { 7, 6, 4, 3, 1 }, ExpectedResult = 0)]
        [TestCase(new int[0], ExpectedResult = 0)]
        [TestCase((int[])null, ExpectedResult = 0)]
        public int TestSample(int[] arrays)
        {
            return new Solution().MaxProfit(arrays);
        }
        /// <summary>
        /// 假设第i天买入，第（i+1）天卖出，利润为profit = prices[i+1] - prices[i]，若第（i+2）天的价格更高，则profit = prices[i+2] - prices[i] = (prices[i+2] - prices[i+1]) + (prices[i+1] - prices[i])。基于以上分析可得递推公式 profit += max{(prices[i + 1] - prices[i]), 0}
    /// </summary>
    public class Solution
        {
            public int MaxProfit(int[] prices)
            {
                if (prices == null || prices.Length <= 1) return 0;
                int profit = 0;
                for(int i = 0;i< prices.Length-1;i++){
                    if (prices[i + 1] - prices[i] > 0)
                    {
                        profit += prices[i + 1] - prices[i];
                    }
                }
                return profit;
            }
        }

    }
}
