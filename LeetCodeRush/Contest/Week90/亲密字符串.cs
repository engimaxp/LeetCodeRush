using System;
using NUnit.Framework;

namespace LeetCodeRush.Contest.Week90
{
    [TestFixture]
    public class 亲密字符串
    {
        [TestCase("aaaaaaabc", "aaaaaaacb",
            ExpectedResult =true )]
        [TestCase("ab", "ab",
            ExpectedResult = false)]
        [TestCase("ab", "ba",
            ExpectedResult = true)]
        [TestCase("aa", "aa",
            ExpectedResult = true)]
        [TestCase("", "aa",
            ExpectedResult = false)]
        [TestCase("abab", "abab",
            ExpectedResult = true)]
        [TestCase("aabab", "aabab",
            ExpectedResult = true)]
        public bool TestSample(string A, string B)
        {
            return new Solution().BuddyStrings(A,B);
        }
        public class Solution
        {
            public bool BuddyStrings(string A, string B)
            {
                if (A == null || B == null) return false;
                if (A.Length != B.Length)
                {
                    return false;
                }

                if (A.Length <= 1) return false;
                if (A.Length == 2)
                {
                    if (A[0] == A[1])
                    {
                        return true;
                    }
                    else
                    {
                        if (A[0] == B[1] && B[0] == A[1])
                            return true;
                    }

                    return false;
                }
                if (A == B && A.Length > 2)
                {
                    for (int i = 0; i < A.Length; i++)
                    {
                        for (int j = i + 1; j < A.Length; j++)
                        {
                            if (A[i] == A[j]) return true;
                        }
                    }

                    return false;
                }

                bool findDiff = false;
                char diffA = ' ';
                char diffB = ' ';
                bool transferred = false;
                for (int i = 0; i < A.Length; i++)
                {
                    if (!findDiff)
                    {
                        if (A[i] != B[i])
                        {
                            findDiff = true;
                            diffA = A[i];
                            diffB = B[i];
                        }
                    }
                    else
                    {
                        if (A[i] != B[i])
                        {
                            if (!transferred)
                            {
                                if (A[i] == diffB && B[i] == diffA)
                                {
                                    transferred = true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }

                if (!transferred && findDiff)
                {
                    return false;
                }
                
                return findDiff;
            }
        }
    }
}