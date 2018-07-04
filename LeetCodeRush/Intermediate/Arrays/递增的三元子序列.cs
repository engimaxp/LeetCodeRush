using System;
using NUnit.Framework;

namespace LeetCodeRush.Intermediate.Arrays
{
    [TestFixture]
    public class 递增的三元子序列
    {
        public class Solution
        {
            public bool IncreasingTriplet(int[] nums)
            {
                int m1 = int.MaxValue, m2 = int.MaxValue;
                for (var i = 0;i<nums.Length;i++)
                {
                    if (m1 >= nums[i]) m1 = nums[i];
                    else if (m2 >= nums[i]) m2 = nums[i];
                    else return true;
                }
                return false;
            }
        }

        [Test]
        public void TestMethod()
        {
            var result = new Solution().IncreasingTriplet(new []{ 1, 2, 3, 4, 5});
            Assert.AreEqual(true,result);
        }

        [Test]
        public void TestMethod2()
        {
            var result = new Solution().IncreasingTriplet(new[] { 5, 4, 3, 2, 1 });
            Assert.AreEqual(false, result);
        }
    }
}