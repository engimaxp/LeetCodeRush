using System;
using System.Text;
using NUnit.Framework;

namespace LeetCodeRush.Simple.StringTest
{
    [TestFixture]
    public class 最长公共前缀
    {
        [Test]
        public void TestSample1()
        {
            string[] strs = new[] {"flower", "flow", "flight"};
            var result =  new Solution().LongestCommonPrefix(strs);
            Assert.AreEqual("fl", result);
        }
        [Test]
        public void TestSample2()
        {
            string[] strs = new[] { "dog", "racecar", "car" };
            var result = new Solution().LongestCommonPrefix(strs);
            Assert.AreEqual("", result);
        }
        public class Solution
        {
            public string LongestCommonPrefix(string[] strs)
            {
                if (strs == null || strs.Length == 0) return "";
                if (strs.Length == 1) return strs[0];
                Array.Sort(strs);
                StringBuilder s = new StringBuilder(){Capacity = strs[0].Length };
                    for (int j = 0; j < strs[0].Length; j++)
                {
                    for (int i = 0; i < strs.Length - 1; i++)
                    {
                        if (strs[i][j] != strs[i + 1][j])
                        {
                            return s.ToString();
                        }
                    }

                    s.Append(strs[0][j]);
                }

                return s.ToString();
            }
        }
    }
}