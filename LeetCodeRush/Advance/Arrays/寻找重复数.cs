using System;
using NUnit.Framework;

namespace LeetCodeRush.Advance.Arrays
{
    [TestFixture]
    public class 寻找重复数
    {
        /// <summary>
        /// 给定一个包含 n + 1 个整数的数组 nums，其数字都在 1 到 n 之间（包括 1 和 n），可知至少存在一个重复的整数。假设只有一个重复的整数，找出这个重复的数。
        /// 示例 1:
        /// 
        /// 输入: [1,3,4,2,2]
        /// 输出: 2
        /// 示例 2:
        /// 
        /// 输入: [3,1,3,4,2]
        /// 输出: 3
        /// 说明：
        /// 
        /// 不能更改原数组（假设数组是只读的）。
        /// 只能使用额外的 O(1) 的空间。
        /// 时间复杂度小于 O(n2) 。
        /// 数组中只有一个重复的数字，但它可能不止重复出现一次。
        /// </summary>
        public class Solution
        {
            public int FindDuplicate(int[] nums)
            {
                int slow = 0, fast = 0, t = 0;
                while (true)
                {
                    slow = nums[slow];
                    fast = nums[nums[fast]];
                    if (slow == fast) break;
                }
                while (true)
                {
                    slow = nums[slow];
                    t = nums[t];
                    if (slow == t) break;
                }
                return slow;
            }
        }
        [Test]
        public void TestMethod1()
        {
            Assert.AreEqual(2, new Solution().FindDuplicate(new int[]{ 1, 3, 4, 2, 2 }));
        }
        [Test]
        public void TestMethod2()
        {
            Assert.AreEqual(3, new Solution().FindDuplicate(new int[] { 3, 1, 3, 4, 2 }));
        }
    }
}