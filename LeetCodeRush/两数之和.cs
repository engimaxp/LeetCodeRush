using System;
using NUnit.Framework;

namespace LeetCodeRush
{
    [TestFixture]
    public class 两数之和
    {
        [TestCase(new[] {3, 2, 4 }, 6,
            ExpectedResult = new[] { 1,2 })]
        [TestCase(new[] { 2, 7, 11, 15 },9,
            ExpectedResult = new[] { 0,1 })]
        [TestCase(new[] { 2, 7, 11, 15 },5,
            ExpectedResult = new int[0])]
        [TestCase(new int[0], 0,
            ExpectedResult = new int[0])]
        [TestCase(null, 0,
            ExpectedResult = new int[0])]
        public int[] TestSample(int[] nums, int target)
        {
            return new Solution().TwoSum(nums, target);
        }
        public class Solution
        {
            public int[] TwoSum(int[] nums, int target)
            {
                if (nums == null || nums.Length == 0) return new int[0];
                int[] subs = new int[nums.Length];
                Array.Copy(nums, subs,nums.Length);
                for (int i = 0; i < subs.Length; i++)
                {
                    subs[i] = target - subs[i];
                }

                for (int j = 0; j < nums.Length; j++)
                {
                    for (int k = j+1; k < subs.Length; k++)
                    {
                        if (nums[j] == subs[k])
                        {
                            return new int[]{j,k};
                        }
                    }
                }
                return new int[0];
            }
        }
    }
}