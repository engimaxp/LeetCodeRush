using System;
using NUnit.Framework;

namespace LeetCodeRush.Intermediate.Arrays
{
    [TestFixture]
    public class 最长回文子串
    {
        public class Solution
        {
            public string LongestPalindrome(string s)
            {
                int start = 0, end = 0;
                for (var i = 0; i < s.Length; i++)
                {
                    var len1 = ExpandAroundCenter(s, i, i);
                    var len2 = ExpandAroundCenter(s, i, i + 1);
                    var len = Math.Max(len1, len2);
                    if (len > end - start +1)
                    {
                        start = i - (len - 1) / 2;
                        end = i + len / 2;
                    }
                }

                return s.Substring(start, end-start + 1);
            }

            private static int ExpandAroundCenter(string s, int left, int right)
            {
                int L = left, R = right;
                while (L >= 0 && R < s.Length && s[L] == s[R])
                {
                    L--;
                    R++;
                }

                return R - L - 1;
            }
        }

        [TestCase("babad", ExpectedResult = "bab")]
        [TestCase("cbbd", ExpectedResult = "bb")]
        public string TestMethods(string s)
        {
            return new Solution().LongestPalindrome(s);
        }
    }
}