using System;
using System.Globalization;
using NUnit.Framework;

namespace LeetCodeRush.Simple.StringTest
{
    [TestFixture]
    public class 实现strStr
    {
        [TestCase("hello", "ll",
            ExpectedResult = 2)]
        [TestCase("aaaaa", "bba",
            ExpectedResult = -1)]
        [TestCase("mississippi", "issip"
            ,
            ExpectedResult = 4)]
        public int TestSample(string haystack, string needle)
        {
            return new Solution().StrStr(haystack, needle);
        }
        //KMP
        public class Solution
        {
            public int StrStr(string haystack, string needle)
            {
                if (string.IsNullOrEmpty(needle)) return 0;
                if (haystack.Length < needle.Length)
                {
                    return -1;
                }

                int M = needle.Length;
                int R = 256;
                int[,] dfa = new int[R,M];
                dfa[needle[0], 0] = 1;
                int X = 0;
                for (int j = 1; j < M; j++)
                {
                    for (int c = 0; c < R; c++)
                    {
                        dfa[c, j] = dfa[c, X];
                    }

                    dfa[needle[j], j] = j + 1;
                    X = dfa[needle[j], X];
                }

                int N = haystack.Length;
                int P = needle.Length;
                int x = 0, y = 0;
                for ( ;x < N && y < P; x++)
                {
                    y = dfa[haystack[x], y];
                }

                if (y == P) return x - P;
                else return -1;
            }
        }
        //Naive
        public class Solution2
        {
            public int StrStr(string haystack, string needle)
            {
                if (string.IsNullOrEmpty(needle)) return 0;
                if (haystack.Length < needle.Length)
                {
                    return -1;
                }
                int j = 0;
                for (int i = 0; i < haystack.Length; i++)
                {
                    j = 0;
                    if (haystack[i] == needle[j])
                    {
                        int temp = i;
                        while (temp < haystack.Length && j < needle.Length
                                                        && haystack[temp++] == needle[j++])
                        {
                            if (j == needle.Length)
                            {
                                return i;
                            }
                        }
                    }
                }
                return -1;
            }
        }
    }
}