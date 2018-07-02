using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace LeetCodeRush.Simple.Misc
{
    [TestFixture]
    public class 缺失数字
    {
        //高斯方程求和后减原有数和即可求出缺失数字
        public class Solution
        {
            public int MissingNumber(int[] nums)
            {
                if (nums.Length ==0) return 0;
                if (nums.Length == 1)
                {
                    if (nums[0] == 0) return 1;
                    else return 0;
                }
                Array.Sort(nums);
                if (nums[0] != 0) return 0;
                for (int i = 0; i < nums.Length-1; i++)
                {
                    if (nums[i] + 1 < nums[i + 1])
                    {
                        return nums[i] + 1;
                    }
                }

                return nums.Length;
            }
        }

        [Test]
        public void TestMethod1()
        {
            var result = new Solution().MissingNumber(new int[]{ 3, 0, 1 });
            Assert.AreEqual(2,result);
        }
        [Test]
        public void TestMethod2()
        {
            var result = new Solution().MissingNumber(new int[] { 9, 6, 4, 2, 3, 5, 7, 0, 1 });
            Assert.AreEqual(8, result);
        }
    }
}