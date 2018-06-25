using System;
using NUnit.Framework;

namespace LeetCodeRush.Simple.DPTest
{
    [TestFixture]
    public class 最大子序和
    {
        [Test]
        public void TestSample1()
        {
            int[] strs = new[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            var result = new Solution().MaxSubArray(strs);
            Assert.AreEqual(6, result);
        }
        //        [Test]
        //        public void TestSample2()
        //        {
        //            int[] strs = new[] { 7, 6, 4, 3, 1};
        //            var result = new Solution().MaxProfit(strs);
        //            Assert.AreEqual(0, result);
        //        }
        public class Solution
        {
            public int MaxSubArray(int[] nums)
            {
                if (nums == null || nums.Length == 0) return 0;
                return divide(nums, 0, nums.Length - 1);
            }

            public int divide(int[] nums, int l, int r)
            {
                if (l == r) return nums[l];
                if (l == r - 1) return Math.Max(nums[l] + nums[r], Math.Max(nums[l], nums[r]));

                int mid = (l + r) >> 1;
                int lret = divide(nums, l, mid - 1);
                int rret = divide(nums, mid + 1, r);

                int mret = nums[mid];
                int sum = mret;
                for (int i = mid - 1; i >= l; i--)
                {
                    sum += nums[i];;  
                    mret = Math.Max(mret, sum);
                }
                sum = mret;    //保存已经计算过的左边的最大子序和  
                for (int i = mid + 1; i <= r; i++)
                {
                    sum += nums[i];
                    //    if(sum < 0) sum = 0;  
                    mret = Math.Max(mret, sum);
                }

                return Math.Max(mret, Math.Max(lret, rret));
            }
        }
    }
}