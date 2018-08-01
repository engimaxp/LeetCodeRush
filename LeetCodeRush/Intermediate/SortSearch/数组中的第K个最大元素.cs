using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace LeetCodeRush.Intermediate.SortSearch
{
    [TestFixture]
    public class 数组中的第K个最大元素
    {
        public class Solution
        {
            public void Swap(int i, int j, int[] array)
            {
                var temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }

            public int FindKthLargest(int[] nums, int k)
            {
                int lo = 0;
                int hi = nums.Length - 1;
                return Partition(nums, lo, hi, k);
            }

            private int Partition(int[] nums, int lo, int hi, int k)
            {
                if (lo >= hi) return nums[lo];
                int i = lo, j = hi + 1;
                int v = nums[lo];
                while (true)
                {
                    while (nums[++i]<v)
                    {
                        if(i == hi) break;
                    }

                    while (v<nums[--j])
                    {
                        if(j == lo) break;
                    }
                    if(i>=j)break;
                    Swap(i,j,nums);
                }
                Swap(lo,j,nums);

                var length = hi - lo+1;
                if (length - (j - lo) == k) return nums[j];
                else if (length - (j - lo) > k)
                {
                    return Partition(nums, j + 1, hi, k);
                }
                else
                {
                    return Partition(nums, lo, j-1, k - (length - (j - lo)) );
                }
            }
        }
        [Test]
        public void TestMethod()
        {
            var colors = new int[] { 3, 2, 1, 5, 6, 4 };
            int result = new Solution().FindKthLargest(colors,2);
            Assert.AreEqual(5,result);
        }
        [Test]
        public void TestMethod2()
        {
            var colors = new int[] { 3, 2, 3, 1, 2, 4, 5, 5, 6 };
            int result = new Solution().FindKthLargest(colors, 4);
            Assert.AreEqual(4, result);
        }
    }
}