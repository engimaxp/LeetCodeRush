﻿using System;
using NUnit.Framework;

namespace LeetCodeRush.Advance.Arrays
{
    [TestFixture]
    public class ProductofArrayExceptSelf
    {
        /// <summary>
        /// 给定长度为 n 的整数数组 nums，其中 n > 1，返回输出数组 output ，其中 output[i] 等于 nums 中除 nums[i] 之外其余各元素的乘积。
        /// 示例:
        /// 输入: [1,2,3,4]
        /// 输出: [24,12,8,6]
        /// 说明: 请不要使用除法，且在 O(n) 时间复杂度内完成此题。
        /// 进阶：
        /// 你可以在常数空间复杂度内完成这个题目吗？（ 出于对空间复杂度分析的目的，输出数组不被视为额外空间。）
        /// </summary>
        public class Solution
        {
            public int[] ProductExceptSelf(int[] nums)
            {
                int n = nums.Length, right = 1;
                int[] res = new int[n];
                res[0] = 1;
                for (int i = 1; i < n; ++i)
                {
                    res[i] = res[i - 1] * nums[i - 1];
                }
                for (int i = n - 1; i >= 0; --i)
                {
                    res[i] *= right;
                    right *= nums[i];
                }
                return res;
            }
        }
        [Test]
        public void TestMethod()
        {
            Assert.AreEqual(new int[]{ 24, 12, 8, 6 }, new Solution().ProductExceptSelf(new int[]{ 1, 2, 3, 4 }));
        }
    }
}