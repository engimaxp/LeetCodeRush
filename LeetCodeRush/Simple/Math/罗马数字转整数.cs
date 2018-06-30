using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace LeetCodeRush.Simple.Calculate
{
    [TestFixture]
    public class 罗马数字转整数
    {
        public class Solution
        {
            public int RomanToInt(string s)
            {
                s = s.Replace("IV", "IIII");
                s = s.Replace("IX", "VIIII");
                s = s.Replace("XL", "XXXX");
                s = s.Replace("XC", "LXXXX");
                s = s.Replace("CD", "CCCC");
                s = s.Replace("CM", "DCCCC");
                var array = s.ToCharArray();
                var result = 0;
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == 'I') result++;
                    else if (array[i] == 'V') result+=5;
                    else if (array[i] == 'X') result += 10;
                    else if (array[i] == 'L') result += 50;
                    else if (array[i] == 'C') result += 100;
                    else if (array[i] == 'D') result += 500;
                    else if (array[i] == 'M') result += 1000;
                }

                return result;
            }
        }
        [Test]
        public void TestMethods()
        {
            Assert.AreEqual(3, new Solution().RomanToInt("III"));
            Assert.AreEqual(4, new Solution().RomanToInt("IV"));
            Assert.AreEqual(9, new Solution().RomanToInt("IX"));
            Assert.AreEqual(58, new Solution().RomanToInt("LVIII"));
            Assert.AreEqual(1994, new Solution().RomanToInt("MCMXCIV"));
        }
    }
}