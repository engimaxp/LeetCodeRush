using System;
using NUnit.Framework;

namespace LeetCodeRush.Simple.DPTest
{
    [TestFixture]
    public class 爬楼梯
    {
        [TestCase(2,ExpectedResult = 2)]
        [TestCase(3, ExpectedResult = 3)]
        public int TestSample(int n)
        {
            return new Solution().ClimbStairs(n);
            
        }
        public class Solution
        {
            public int ClimbStairs(int n)
            {
                if (n <= 0) return 0;
                if (n == 1) return 1;
                if (n == 2) return 2;
                int[] array = new int[n];
                return calculateDP(n, array);
            }

            public int calculateDP(int n,int[] array)
            {
                if (n == 1) return 1;
                if (n == 2) return 2;
                if (array[n - 1] > 0) return array[n - 1];
                array[n - 1] = calculateDP(n - 1, array) + calculateDP(n - 2, array);
                return array[n - 1];
            }
        }
    }
}