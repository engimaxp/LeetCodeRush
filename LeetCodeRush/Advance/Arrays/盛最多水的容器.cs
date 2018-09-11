using System;
using NUnit.Framework;

namespace LeetCodeRush.Advance.Arrays
{
    [TestFixture]
    public class 盛最多水的容器
    {
        /// <summary>
        /// 给定 n 个非负整数 a1，a2，...，an，每个数代表坐标中的一个点 (i, ai) 。在坐标内画 n 条垂直线，垂直线 i 的两个端点分别为 (i, ai) 和 (i, 0)。找出其中的两条线，使得它们与 x 轴共同构成的容器可以容纳最多的水。
        /// 说明：你不能倾斜容器，且 n 的值至少为 2。
        /// 
        /// 图中垂直线代表输入数组[1, 8, 6, 2, 5, 4, 8, 3, 7]。在此情况下，容器能够容纳水（表示为蓝色部分）的最大值为 49。
        /// 示例:
        /// 
        /// 输入: [1,8,6,2,5,4,8,3,7]
        /// 输出: 49
        /// </summary>
        public class Solution
        {
            public int MaxArea(int[] height)
            {
                int max = 0;
                int start = 0, end = height.Length - 1;
                while (start < end)
                {
                    int value = (end - start) * Math.Min(height[start], height[end]);
                    if (max < value)
                        max = value;
                    if (height[start] < height[end])
                        start++;
                    else
                        end--;

                }
                return max;
            }
        }
        [Test]
        public void TestMethod()
        {
            Assert.AreEqual(49, new Solution().MaxArea(new int[]{ 1, 8, 6, 2, 5, 4, 8, 3, 7 }));
        }
    }
}