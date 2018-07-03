using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace LeetCodeRush.Intermediate.Arrays
{
    [TestFixture]
    public class 三数之和
    {
        public class Solution
        {
            public IList<IList<int>> ThreeSum(int[] nums)
            {
                Array.Sort(nums);
                var result = new List<IList<int>>();
                for (int i = 0; i < nums.Length-1 && nums[i]<=0; i++)
                {
                    if (i > 0 && nums[i] == nums[i - 1]) continue;
                    var target = -nums[i];
                    int j = i + 1;
                    int k = nums.Length - 1;
                    while (k > j)
                    {
                        if (nums[k] + nums[j] == target)
                        {
                            result.Add(new List<int>() { nums[i], nums[j], nums[k] });
                            while (j < k && nums[j] == nums[j + 1]) ++j;
                            while (j < k && nums[k] == nums[k - 1]) --k;
                            j++;
                            k--;
                        }
                        else if (nums[j] + nums[k] < target) ++j;
                        else --k;
                    }
                }
                return result;
            }
        }

        [Test]
        public void TestMethod()
        {
            var result = new Solution().ThreeSum(new []{ -1, 0, 1, 2, -1, -4 });
            Assert.IsNotNull(result);
        }
        [Test]
        public void TestMethod2()
        {
            var result = new Solution().ThreeSum(new[] { -1, 1,0, -1, -1, 0, -1, 1, 0, -1, 1, 0, -1 });
            Assert.IsNotNull(result);
        }
    }
}