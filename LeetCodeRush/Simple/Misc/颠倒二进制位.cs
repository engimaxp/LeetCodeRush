using System;
using NUnit.Framework;

namespace LeetCodeRush.Simple.Misc
{
    [TestFixture]
    public class 颠倒二进制位
    {
        public class Solution
        {
            public uint ReverseBits(uint n)
            {
                uint result = 0;
                uint factor = ((uint)1 << 31);
                for (int i = 0; i < 32; i++)
                {
                    if(n <=0) break;
                    if (n % 2 == 1)
                    {
                        result += factor;
                    }
                    factor >>= 1;
                    n >>= 1;
                }

                return result;
            }
        }
        [TestCase((uint)43261596, ExpectedResult = (uint)964176192)]
        public uint TestMethods(uint n)
        {
            return new Solution().ReverseBits(n);
        }
    }
}