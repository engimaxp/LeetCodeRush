using System;
using NUnit.Framework;

namespace LeetCodeRush.Simple.StringTest
{
    [TestFixture]
    public class 反转字符串
    {
        [TestCase("hello",
            ExpectedResult = "olleh")]
        [TestCase(null,
            ExpectedResult = null)]
        [TestCase("s",
            ExpectedResult = "s")]
        [TestCase("",
            ExpectedResult = "")]
        public string TestSample(string s)
        {
            return new Solution().ReverseString(s);
        }
        public class Solution
        {
            public string ReverseString(string s)
            {
                if (s == null || s.Length <= 1) return s;
                char[] c = s.ToCharArray();
                int l = s.Length;
                for (int i = 0; i < l / 2; i++)
                {
                    char t = c[i];
                    c[i] = c[l - i - 1];
                    c[l - i - 1] = t;
                }
                return
                    new string(c);
            }
        }
    }
}