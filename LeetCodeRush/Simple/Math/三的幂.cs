using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace LeetCodeRush.Simple.Calculate
{
    [TestFixture]
    public class 三的幂
    {
        public class Solution
        {
            public bool IsPowerOfThree(int n)
            {
                if (n <= 0) return false;
                int max = (int)Math.Pow(3, (int)(Math.Log(0x7fffffff) / Math.Log(3)));
                return max % n == 0;
            }
        }
        [Test]
        public void TestMethods()
        {
            Assert.AreEqual(true, new Solution().IsPowerOfThree(27));
            Assert.AreEqual(false, new Solution().IsPowerOfThree(0));
            Assert.AreEqual(true, new Solution().IsPowerOfThree(9));
            Assert.AreEqual(false, new Solution().IsPowerOfThree(45));
            Assert.AreEqual(false, new Solution().IsPowerOfThree(-3));
        }
    }
}