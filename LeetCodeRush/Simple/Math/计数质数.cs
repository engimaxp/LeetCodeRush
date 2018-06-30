using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace LeetCodeRush.Simple.Calculate
{
    [TestFixture]
    public class 计数质数
    {
        public class Solution
        {
            public int CountPrimes(int n)
            {
                int result = 0;
                bool[] array= new bool[n+1];//isnotprime

                int i = 1;
                for (; i*i <= n; i++)
                {
                    if (i == 0 || i == 1) continue;
                    if (!array[i])
                    {
                        result++;
                        for (int j = 2; j * i < n; j++)
                        {
                            array[j * i] = true;
                        }
                    }
                }

                for (int k = i; k < n; k++)
                {
                    if (!array[k]) result++;
                }

                return result;
            }
        }
        [Test]
        public void TestMethods()
        {
            Assert.AreEqual(6, new Solution().CountPrimes(15));
            Assert.AreEqual(4, new Solution().CountPrimes(10));
        }
    }
}