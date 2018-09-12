using System;
using System.Diagnostics;
using System.Text;
using NUnit.Framework;

namespace LeetCodeRush.Advance.Arrays
{
    [TestFixture]
    public class 第一个缺失的正数
    {
        /// <summary>
        /// 给定一个未排序的整数数组，找出其中没有出现的最小的正整数。
        /// 示例 1:
        /// 
        /// 输入: [1,2,0]
        /// 输出: 3
        /// 示例 2:
        /// 
        /// 输入: [3,4,-1,1]
        /// 输出: 2
        /// 示例 3:
        /// 
        /// 输入: [7,8,9,11,12]
        /// 输出: 1
        /// 说明:
        /// 
        /// 你的算法的时间复杂度应为O(n)，并且只能使用常数级别的空间。
        /// </summary>
        public class Solution
        {
            public int FirstMissingPositive(int[] nums)
            {
                int n = nums.Length;
                for (int i = 0; i < n; ++i)
                {
                    while (nums[i] > 0 && nums[i] <= n && nums[nums[i] - 1] != nums[i])
                    {
                        Swap(i, nums[i] - 1, nums);
                        Debug.WriteLine(FormatNums(nums));
                    }
                }
                for (int i = 0; i < n; ++i)
                {
                    if (nums[i] != i + 1) return i + 1;
                }
                return n + 1;
            }

            public string FormatNums(int[] nums)
            {
                StringBuilder builder = new StringBuilder();
                foreach (var num in nums)
                {
                    builder.AppendFormat("{0} ", num);
                }

                return builder.ToString();
            }

            public void Swap(int i, int j, int[] nums)
            {
                int temp = nums[j];
                nums[j] = nums[i];
                nums[i] = temp;
            }

        }
        [Test]
        public void TestMethod1()
        {
            Assert.AreEqual(3, new Solution().FirstMissingPositive(new int[]{ 1, 2, 0 }));
        }

        [Test]
        public void TestMethod2()
        {
            Assert.AreEqual(2, new Solution().FirstMissingPositive(new int[] { 3, 4, -1, 1 }));
        }

        [Test]
        public void TestMehod3()
        {
            Assert.AreEqual(1, new Solution().FirstMissingPositive(new int[] { 7, 8, 9, 11, 12 }));
        }
    }
}