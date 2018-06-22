using NUnit.Framework;

namespace LeetCodeRush
{
    [TestFixture]
    public class 从排序数组中删除重复项
    {
        [TestCase(new[] { 1, 1, 2, 2, 3, 4 }, ExpectedResult = 4)]
        [TestCase(new[] { 1 }, ExpectedResult = 1)]
        [TestCase(new int[0], ExpectedResult = 0)]
        [TestCase((int[])null, ExpectedResult = 0)]
        public int TestSample(int[] arrays)
        {
            return new Solution().RemoveDuplicates(arrays);
        }
        /// <summary>
        /// 快慢指针法
        /// </summary>
        public class Solution
        {
            public int RemoveDuplicates(int[] nums)
            {
                if (nums == null || nums.Length == 0)
                {
                    return 0;
                }
                int cur = 0;
                for (int pre = 0; pre < nums.Length; pre++)
                {
                    if (nums[cur] != nums[pre])
                    {
                        nums[++cur] = nums[pre];
                    }
                }
                return ++cur;
            }
        }

    }
}
