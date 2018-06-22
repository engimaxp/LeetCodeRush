using System;
using NUnit.Framework;

namespace LeetCodeRush
{
    [TestFixture]
    public class 两个数组的交集II
    {
        [TestCase(new[] { 1, 2, 2, 1 }, new[] { 2, 2 },
            ExpectedResult = new[] { 2, 2 })]
        [TestCase(new[] { 1, 2,3, 2, 1 }, new[] { 2,3, 2 },
            ExpectedResult = new[] { 2, 2, 3 })]
        [TestCase(new[] { 1,2 }, new[] { 2,1 },
            ExpectedResult = new[] { 1,2 })]
        [TestCase(new[] { 1, 2 }, new[] { 1, 1 },
            ExpectedResult = new[] { 1 })]
        public int[] TestSample(int[] nums1, int[] nums2)
        {
            return new Solution().Intersect(nums1,nums2);
        }
        public class Solution
        {
            public int[] Intersect(int[] nums1, int[] nums2)
            {
                if (nums1 == null || nums2 == null) return null;
                if (nums1.Length == 0) return nums1;
                if (nums2.Length == 0) return nums2;
                Array.Sort(nums1);
                Array.Sort(nums2);
                int newarrayLength =  nums1.Length > nums2.Length ? nums2.Length : nums1.Length;
                int[] result = new int[newarrayLength];
                int index = 0;
                int i=0,j = 0;
                while (i < nums1.Length && j < nums2.Length)
                {
                    if (nums2[j] > nums1[i])
                    {
                        i++;
                    }
                    else if (nums2[j] < nums1[i])
                    {
                        j++;
                    }
                    else
                    {
                        result[index++] = nums1[i];
                        i++;
                        j++;
                    }
                }

                var finalresult = new int[index];
                Array.Copy(result, finalresult,index);
                return finalresult;
            }
        }
    }
}
