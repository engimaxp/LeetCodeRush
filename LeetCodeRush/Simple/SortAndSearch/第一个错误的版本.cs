using System;
using NUnit.Framework;

namespace LeetCodeRush.Simple.SortAndSearch
{
    [TestFixture]
    public class 第一个错误的版本
    {
//        [TestCase(4,ExpectedResult = 4)]
//        [TestCase(6, ExpectedResult = 4)]
//        [TestCase(5, ExpectedResult = 4)]
//        [TestCase(1000, ExpectedResult = 4)]

        [TestCase(2126753390, ExpectedResult = 1702766719)]

        public int TestSample(int x)
        {
            return new Solution().FirstBadVersion(x);
        }
        /* The isBadVersion API is defined in the parent class VersionControl.bool IsBadVersion(int version); */
        public abstract class VersionControl
        {
            public bool IsBadVersion(int version)
            {
                return version >= 1702766719;
            }
        }
        public class Solution : VersionControl
        {
            public int FirstBadVersion(int n)
            {
                int l = 0;
                int r = n;
                int m = (l + r) >> 1;
                while (m > l && m < r)
                {
                    if (IsBadVersion(m))
                    {
                        r = m;
                    }
                    else
                    {
                        l = m;
                    }
                    m = l + ((r - l) >> 1);
                }

                return r;
            }
        }
    }
}