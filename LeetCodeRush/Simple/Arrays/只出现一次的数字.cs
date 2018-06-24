using System;
using NUnit.Framework;

namespace LeetCodeRush.Simple.ArrayTest
{
    [TestFixture]
    public class 只出现一次的数字
    {
        [TestCase(new[] { 2, 2, 1 }, ExpectedResult = 1)]
        [TestCase(new[] { 4, 1, 2, 1, 2 },  ExpectedResult = 4)]
        [TestCase(new[] { 4, 4, 2, 2, 1 }, ExpectedResult = 1)]
        [TestCase(new[] { 1,5,2,4,3,3,4,2,5,1 }, ExpectedResult = 0)]
        [TestCase(new int[]{1}, ExpectedResult = 1)]
        [TestCase(new int[0],  ExpectedResult = 0)]
        [TestCase((int[])null, ExpectedResult = 0)]
        public int TestSample(int[] nums)
        {
            return new Solution().SingleNumber(nums);
        }
        public class Solution
        {
            public int SingleNumber(int[] nums)
            {
                if (nums == null || nums.Length <= 0) return 0;
                if (nums.Length == 1) return nums[0];
                Array.Sort(nums);
                int k = 0;
                for (int i = 0; i < nums.Length-1; i++)
                {
                    if (k != nums[i])
                    {
                        k = nums[i];
                        if (k != nums[i + 1])
                        {
                            return k;
                        }
                    }
                }

                if (k != nums[nums.Length - 1])
                {
                    return nums[nums.Length - 1];
                }

                return 0;
            }
        }
    }
}
