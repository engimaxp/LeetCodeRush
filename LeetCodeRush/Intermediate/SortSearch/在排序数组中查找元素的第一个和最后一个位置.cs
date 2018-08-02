using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace LeetCodeRush.Intermediate.SortSearch
{
    [TestFixture]
    public class 在排序数组中查找元素的第一个和最后一个位置
    {
        public class Solution
        {
            public int[] SearchRange(int[] nums, int target)
            {
                if(nums.Length == 1 && target == nums[0]) return new int[]{0,0};
                int find = -1;
                int left = 0, right = nums.Length - 1;
                while (left <= right)
                {
                    int mid = left + (right - left) / 2;
                    if (nums[mid] == target)
                    {
                        find = mid;
                        break;
                    }
                    else if (nums[mid] < target) left = mid + 1;
                    else
                    {
                        if(left == right) break;
                        right = mid;
                    }
                }

                if (find < 0) return new[] {-1, -1};
                left = 0;
                right = find;
                while (left<right)
                {
                    int mid = left + (right - left) / 2;
                    if (nums[mid] < target) left = mid + 1;
                    else right = mid;
                }

                int leftmost = right;

                int rightmost = find;
                left = find;
                right = nums.Length-1;
                while (left <= right)
                {
                    int mid = left + (right - left) / 2;
                    if (nums[mid] == target)
                    {
                        rightmost = mid;
                        left = mid + 1;
                    }
                    else
                    {
                        if (left == right)
                        {
                            break;
                        }
                        right = mid;
                    }
                }

                return new int[]{leftmost,rightmost};
            }
        }
        [Test]
        public void TestMethod()
        {
            var colors = new int[] { 5, 7, 7, 8, 8, 10 };
            var result = new Solution().SearchRange(colors,8);
            Assert.AreEqual(new int[]{3,4},result);
        }
        [Test]
        public void TestMethod3()
        {
            var colors = new int[] { 2,2 };
            var result = new Solution().SearchRange(colors, 2);
            Assert.AreEqual(new int[] { 0,1 }, result);
        }
        [Test]
        public void TestMethod2()
        {
            var colors = new int[] { 5, 7, 7, 8, 8, 10 };
            var result = new Solution().SearchRange(colors, 6);
            Assert.AreEqual(new int[] {-1,-1 }, result);
        }
        [Test]
        public void TestMethod4()
        {
            var colors = new int[] { 1,4 };
            var result = new Solution().SearchRange(colors, 4);
            Assert.AreEqual(new int[] { 1,1 }, result);
        }
    }
}