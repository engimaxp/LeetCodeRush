using System;
using NUnit.Framework;

namespace LeetCodeRush
{
    [TestFixture]
    public class 存在重复
    {
        [TestCase(new[] { 1, 2, 3, 1 }, ExpectedResult = true)]
        [TestCase(new[] { 1, 2, 3, 4 },  ExpectedResult = false)]
        [TestCase(new[] { 1, 1, 1, 3, 3, 4, 3, 2, 4, 2 },  ExpectedResult = true)]
        [TestCase(new int[]{1}, ExpectedResult = false)]
        [TestCase(new int[0],  ExpectedResult = false)]
        [TestCase((int[])null, ExpectedResult = false)]
        public bool TestSample(int[] nums)
        {
            return new Solution().ContainsDuplicate(nums);
        }
        public class Solution
        {
            public bool ContainsDuplicate(int[] nums)
            {
                if (nums == null || nums.Length <= 1) return false;
                Array.Sort(nums);
                for (int i = 0; i < nums.Length-1; i++)
                {
                    if (nums[i] == nums[i + 1]) return true;
                }

                return false;
            }
        }

    }
}
