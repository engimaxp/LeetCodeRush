using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace LeetCodeRush.Intermediate.back
{
    [TestFixture]
    public class 生成括号
    {
        public class Solution
        {
            public IList<string> GenerateParenthesis(int n)
            {
                List<string> res = new List<string>();
                Helper(n, n, "", res);
                return res;
            }
            private void Helper(int left, int right, string output, List<String> res)
            {
                if (left < 0 || right < 0 || left > right) return;
                if (left == 0 && right == 0)
                {
                    res.Add(output);
                    return;
                }
                Helper(left - 1, right, output+"(", res);
                Helper(left, right - 1, output+")", res);
            }
        }

        [Test]
        public void TestMethod()
        {
            var result = new Solution().GenerateParenthesis(3);
            Assert.AreEqual(new string[]{ "((()))",
                "(()())",
                "(())()",
                "()(())",
                "()()()" },result.ToArray());
        }
        
    }
}