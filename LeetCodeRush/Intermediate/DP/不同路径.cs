using System;
using NUnit.Framework;

namespace LeetCodeRush.Intermediate.DP
{
    [TestFixture]
    public class 不同路径
    {
        public class Solution
        {
            
            public int UniquePaths(int m, int n)
            {
                int x = Math.Max(m, n);
                int[,] st = new int[x+1, x+1];
                return Helper(m, n, st);
            }

            public int Helper(int m, int n, int[,] st)
            {
                if (m == 0 || n == 0) return 0;
                if (m == 1 || n == 1)
                {
                    return 1;
                }

                if (st[m, n] > 0)
                {
                    return st[m, n];
                }
                else
                {
                    var result = Helper(m - 1, n,st) + Helper(m, n - 1,st);
                    st[m, n] = result;
                    st[n, m] = result;
                    return result;
                }
            }
        }
        [TestCase(3,2,ExpectedResult = 3)]
        [TestCase(7,3, ExpectedResult = 28)]
        public int TestMethods(int m, int n)
        {
            return new Solution().UniquePaths(m,n);
        }
    }
}