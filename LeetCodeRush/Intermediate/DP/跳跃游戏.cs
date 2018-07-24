using System;
using NUnit.Framework;

namespace LeetCodeRush.Intermediate.DP
{
    [TestFixture]
    public class 跳跃游戏
    {
        public class Solution
        {
            public bool CanJump(int[] nums)
            {
                int lastPos = nums.Length - 1;
                for (int i = nums.Length - 1; i >= 0; i--)
                {
                    if (i + nums[i] >= lastPos)
                    {
                        lastPos = i;
                    }
                }
                return lastPos == 0;
            }
        }
        public void TestMethods()
        {
            var a = new int[] { 2, 3, 1, 1, 4 };
            var result = new Solution().CanJump(a);
            Assert.AreEqual(true,result);
        }
        public void TestMethods2()
        {
            var a = new int[] { 3, 2, 1, 0, 4 };
            var result = new Solution().CanJump(a);
            Assert.AreEqual(false, result);
        }
    }
}