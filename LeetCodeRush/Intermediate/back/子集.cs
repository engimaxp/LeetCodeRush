using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace LeetCodeRush.Intermediate.back
{
    [TestFixture]
    public class 子集
    {
        public class Solution
        {
            public IList<IList<int>> Subsets(int[] nums)
            {
                var result = new List<IList<int>>(){new List<int>()};

                for (int i = 0; i < nums.Length; i++)
                {
                    var result2 = new List<IList<int>>();
                    result.ForEach(x=>result2.Add(x.ToList()));
                    result2.ForEach(x=>x.Add(nums[i]));
                    result.AddRange(result2);
                }

                return result;
            }
        }
        [Test]
        public void TestMethod()
        {
            var result = new Solution().Subsets(new int[]{ 1, 2, 3 });
            Assert.IsNotNull(result);
        }
        
    }
}