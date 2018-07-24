using System;
using NUnit.Framework;

namespace LeetCodeRush.Intermediate.DP
{
    [TestFixture]
    public class 零钱兑换
    {
        public class Solution
        {
            public int CoinChange(int[] coins, int amount)
            {
                int max = amount + 1;
                int[] dp = new int[amount + 1];
                for (int i = 0; i < dp.Length; i++)
                {
                    dp[i] = max;
                }
                dp[0] = 0;
                for (int i = 1; i <= amount; i++)
                {
                    for (int j = 0; j < coins.Length; j++)
                    {
                        if (coins[j] <= i)
                        {
                            dp[i] = Math.Min(dp[i], dp[i - coins[j]] + 1);
                        }
                    }
                }
                return dp[amount] > amount ? -1 : dp[amount];
            }
        }

        [Test]
        public void TestMethods()
        {
            var result = new Solution().CoinChange(new int[] {1, 2, 5}, 11);
            Assert.AreEqual(3,result);
        }
        [Test]
        public void TestMethods2()
        {
            var result = new Solution().CoinChange(new int[] { 2 }, 3);
            Assert.AreEqual(-1, result);
        }
        [Test]
        public void TestMethods3()
        {
            var result = new Solution().CoinChange(new int[] { 186, 419, 83, 408 }, 6249);
            Assert.AreEqual(20, result);
        }
    }
}