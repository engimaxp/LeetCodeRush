using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace LeetCodeRush.Intermediate.SortSearch
{
    [TestFixture]
    public class 寻找峰值
    {
        public class Solution
        {
            public int FindPeakElement(int[] nums)
            {
                int left = 0, right = nums.Length - 1;
                while (left < right)
                {
                    int mid = left + (right - left) / 2;
                    if (nums[mid] < nums[mid + 1]) left = mid + 1;
                    else right = mid;
                }
                return right;
            }
        }
        [Test]
        public void TestMethod()
        {
            var colors = new int[] { 1, 2, 3, 1 };
            int result = new Solution().FindPeakElement(colors);
            Assert.AreEqual(2,result);
        }
        [Test]
        public void TestMethod2()
        {
            var colors = new int[] { 1, 2, 1, 3, 5, 6, 4 };
            int result = new Solution().FindPeakElement(colors);
            Assert.IsTrue(result == 1 || result == 5);
        }
    }
}