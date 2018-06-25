using System;
using NUnit.Framework;

namespace LeetCodeRush.Simple.DPTest
{
    [TestFixture]
    public class 打家劫舍
    {
        [Test]
        public void TestSample1()
        {
            int[] strs = new[] { 1, 2, 3, 1 };
            var result = new Solution().Rob(strs);
            Assert.AreEqual(4, result);
        }
        [Test]
        public void TestSample2()
        {
            int[] strs = new[] { 2, 7, 9, 3, 1 };
            var result = new Solution().Rob(strs);
            Assert.AreEqual(12, result);
        }
        [Test]
        public void TestSample3()
        {
            int[] strs = new[] { 2,  1 };
            var result = new Solution().Rob(strs);
            Assert.AreEqual(2, result);
        }
        [Test]
        public void TestSample4()
        {
            int[] strs = new[] { 1 };
            var result = new Solution().Rob(strs);
            Assert.AreEqual(1, result);
        }
        public class Solution
        {
            public int Rob(int[] nums)
            {
                if (nums == null || nums.Length ==0) return 0;
                if (nums.Length == 1) return nums[0];

                int max = 0;
                int t = 0;
                for (int i = 0; i < nums.Length; i++)
                {
                    int tmp = max;
                    max = Math.Max(max, t + nums[i]);
                    t = tmp;
                }

                return max;
            }
        }
    }
}