using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace LeetCodeRush.Simple.Misc
{
    [TestFixture]
    public class 位1的个数
    {
        public class Solution
        {
            public int HammingWeight(uint n)
            {
                int result = 0;
                while (n>0)
                {
                    if (n % 2 == 1) result++;
                    n = n >> 1;
                }

                return result;
            }
        }
        [TestCase((uint)11,ExpectedResult = 3)]
        [TestCase((uint)128, ExpectedResult = 1)]
        public int TestMethods(uint n)
        {
            return new Solution().HammingWeight(n);
        }
    }
}