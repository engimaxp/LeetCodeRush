using System;
using NUnit.Framework;

namespace LeetCodeRush.Simple.StringTest
{
    [TestFixture]
    public class 有效的字母异位词
    {
        [TestCase("anagram", "nagaram",
            ExpectedResult = true)]
        [TestCase("rat", "car",
            ExpectedResult = false)]
        public bool TestSample(string s, string t)
        {
            return new Solution().IsAnagram(s,t);
        }
        public class Solution
        {
            public bool IsAnagram(string s, string t)
            {
                int[] a = new int[256];
                if (s.Length != t.Length) return false;
                for (int i = 0; i < s.Length; i++)
                {
                    a[s[i]]++;
                    a[t[i]]--;
                }

                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] > 0) return false;
                }
                return true;
            }
        }
    }
}