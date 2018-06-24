using System;
using System.Globalization;
using System.Text;
using NUnit.Framework;

namespace LeetCodeRush.Simple.StringTest
{
    [TestFixture]
    public class 数数并说
    {
        [TestCase(1, 
            ExpectedResult = "1")]
        [TestCase(4, 
            ExpectedResult = "1211")]
        public string TestSample(int n)
        {
            return new Solution().CountAndSay(n);
        }
        public class Solution
        {
            public string CountAndSay(int n)
            {
                string result = "1";
                for (int i = 0; i < n-1; i++)
                {
                    result = GetNext(result);
                }

                return result;
            }

            public string GetNext(string x)
            {
                if (x.Length == 1) return "11";
                StringBuilder s = new StringBuilder(){Capacity = 2*x.Length};
                int count = 1;
                int i = 0;
                for (;i < x.Length-1; i++)
                {
                    if (x[i] == x[i + 1])
                    {
                        count++;
                    }
                    else
                    {
                        s.Append(count.ToString());
                        s.Append(x[i]);
                        count = 1;
                    }
                }
                s.Append(count.ToString());
                s.Append(x[i]);
                return s.ToString();
            }
        }
    }
}