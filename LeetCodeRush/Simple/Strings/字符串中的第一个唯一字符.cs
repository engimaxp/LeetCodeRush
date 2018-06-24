using System;
using NUnit.Framework;

namespace LeetCodeRush.Simple.StringTest
{
    [TestFixture]
    public class 字符串中的第一个唯一字符
    {
        [TestCase("leetcode",
            ExpectedResult = 0)]
        [TestCase("loveleetcode",
            ExpectedResult = 2)]
        [TestCase("aabbcc",
            ExpectedResult = -1)]
        [TestCase("abacbc",
            ExpectedResult = -1)]
        public int TestSample(string s)
        {
            return new Solution().FirstUniqChar(s);
        }
        public class Solution
        {
            public int FirstUniqChar(string s)
            {
                int[] l =new int[256];
                for (int i = 0; i < l.Length; i++)
                {
                    l[i] = -1;
                }
                for (int i = 0; i < s.Length; i++)
                {
                    if (l[s[i]] != -2)
                    {
                        if (l[s[i]] != -1)
                        {
                            l[s[i]] = -2;
                        }
                        else
                        {
                            l[s[i]] = i;
                        }
                    }

                }
                Array.Sort(l);
                for (int i = 0; i < l.Length; i++)
                {
                    if (l[i] >= 0) return l[i];
                }

                return -1;
            }
        }
    }
}