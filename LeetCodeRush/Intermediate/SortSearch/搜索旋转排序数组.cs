using System;
using NUnit.Framework;

namespace LeetCodeRush.Intermediate.SortSearch
{
    [TestFixture]
    public class 搜索旋转排序数组
    {
        public class Solution
        {
            public int Search(int[] nums, int target)
            {
                if (nums == null || nums.Length == 0) return -1;
                if (nums.Length == 1 && nums[0] != target) return -1;
                if (nums.Length == 1 && nums[0] == target) return 0;
                int start = 0;
                int end = nums.Length - 1;

                while (start + 1 < end)
                {
                    int mid = (end + start) / 2;
                    if (nums[mid] == target)
                    {
                        return mid;
                    }
                    if (nums[start] < nums[mid])
                    { // 左边升序
                        // situation 1, red line
                        if (nums[start] <= target && target <= nums[mid])
                        {
                            end = mid;
                        }
                        else
                        {
                            start = mid;
                        }
                    }
                    else
                    { // 右边升序
                        // situation 2, green line
                        if (nums[mid] <= target && target <= nums[end])
                        {
                            start = mid;
                        }
                        else
                        {
                            end = mid;
                        }
                    }
                } // while


                if (nums[start] == target) return start;
                if (nums[end] == target) return end;
                return -1;
            }
            
        }

        [TestCase(new[] {4, 5, 6, 7, 0, 1, 2}, 0, ExpectedResult = 4)]
        [TestCase(new[] {4, 5, 6, 7, 0, 1, 2}, 3, ExpectedResult = -1)]
        [TestCase(new[] { 1,3 }, 2, ExpectedResult = -1)]
        [TestCase(new[] { 1, 3 ,5}, 0, ExpectedResult = -1)]
        [TestCase(new[] { 1, 3 }, 3, ExpectedResult = 1)]
        [TestCase(new[] { 3,1 }, 1, ExpectedResult = 1)]
        public int TestMethod(int[] nums, int target)
        {
            return new Solution().Search(nums, target);
        }
    }
}