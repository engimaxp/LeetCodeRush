using System;
using NUnit.Framework;

namespace LeetCodeRush.Simple.SortAndSearch
{
    [TestFixture]
    public class 合并两个有序数组
    {
        [Test]
        public void TestSample1()
        {
            var nums1 = new[] {1, 2, 3, 0, 0, 0};
            int m = 3;

            var nums2 = new[] {2, 5, 6};
            int n = 3;
            new Solution().Merge(nums1,m,nums2,n);

            Assert.AreEqual(new []{ 1, 2, 2, 3, 5, 6 },nums1);
        }
        [Test]
        public void TestSample2()
        {
            var nums1 = new[] { 0};
            int m = 0;

            var nums2 = new[] { 1 };
            int n = 1;
            new Solution().Merge(nums1, m, nums2, n);

            Assert.AreEqual(new[] { 1 }, nums1);
        }
        [Test]
        public void TestSample3()
        {
            var nums1 = new[] { 2,0 };
            int m = 1;

            var nums2 = new[] { 1 };
            int n = 1;
            new Solution().Merge(nums1, m, nums2, n);

            Assert.AreEqual(new[] { 1,2 }, nums1);
        }
        public class Solution
        {
            public void Merge(int[] nums1, int m, int[] nums2, int n)
            {
                if (m == 0)
                {
                    for (int k = 0; k < nums2.Length; k++)
                    {
                        nums1[k] = nums2[k];
                    }
                    return;
                }
                if (n == 0) return;
                int j = n-1;
                int i = m-1;
                int z = m+n-1;
                while (z>=0 && j>=0)
                {
                    if (i < 0)
                    {
                        nums1[z] = nums2[j];
                        j--;

                    }
                    else if (nums1[i] > nums2[j])
                    {
                        nums1[z] = nums1[i];
                        i--;
                    }
                    else
                    {
                        nums1[z] = nums2[j];
                        j--;
                    }
                    z--;
                }
            }
        }
    }
}