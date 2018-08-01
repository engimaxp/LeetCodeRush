using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace LeetCodeRush.Intermediate.SortSearch
{
    [TestFixture]
    public class 前K个高频元素
    {
        public class Solution
        {
            public IList<int> TopKFrequent(int[] nums, int k)
            {
                Dictionary<int, int> m = new Dictionary<int, int>();
                List<IList<int>> bucket = new List<IList<int>>();
                List<int> res = new List<int>();
                foreach (var a in nums)
                {
                    if (m.ContainsKey(a)) ++m[a];
                    else {m.Add(a,1); }
                }

                for (int i = 0; i < nums.Length+1; i++)
                {
                    bucket.Add(new List<int>());
                }
                foreach (var it in m.Keys)
                {
                    bucket[m[it]].Add(it);
                }
                for (int i = nums.Length; i >= 0; --i)
                {
                    for (int j = 0; j < bucket[i].Count; ++j)
                    {
                        res.Add(bucket[i][j]);
                        if (res.Count == k) return res;
                    }
                }
                return res;
            }
        }
        [Test]
        public void TestMethod()
        {
            var colors = new int[] { -1,-1 };
            var result = new Solution().TopKFrequent(colors,2);
            Assert.IsNotNull(result);
        }
    }
}