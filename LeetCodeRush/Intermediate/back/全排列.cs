using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace LeetCodeRush.Intermediate.back
{
    [TestFixture]
    public class 全排列
    {
        public class Solution
        {
            public IList<IList<int>> Permute(int[] nums)
            {
                if(nums == null||nums.Length == 0) return new List<IList<int>>();
                int n = 0;
                List<IList<int>> result = new List<IList<int>>();
                for (int i = 0; i < nums.Length; i++,n++)
                {
                    if (n == 0)
                    {
                        result.Add(new List<int>(){nums[i] });
                    }
                    else
                    {
                        var temp = new List<IList<int>>();
                        for (int j = 0; j < result.Count; j++)
                        {
                            for (int k = 0; k <= result[j].Count; k++)
                            {
                                var temp2 = result[j].ToList();
                                temp2.Insert(k,nums[i]);
                                temp.Add(temp2);
                            }
                        }

                        result = temp;
                    }
                }

                return result;
            }
        }
        [Test]
        public void TestMethod()
        {
            var result = new Solution().Permute(new int[]{ 1, 2, 3 });
            Assert.AreEqual(new List<List<int>>{
                
                new List<int>(){1, 2, 3},
                new List<int>(){1, 3, 2},
                new List<int>(){2, 1, 3},
                new List<int>(){2, 3, 1},
                new List<int>(){3, 1, 2},
                new List<int>(){3, 2, 1 }
                    
                 },result);
        }
        
    }
}