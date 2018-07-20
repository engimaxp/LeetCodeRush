using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace LeetCodeRush.Intermediate.back
{
    [TestFixture]
    public class 电话号码的字母组合
    {
        public class Solution
        {
            public IList<string> LetterCombinations(string digits)
            {
                var total = new List<string>();
                for (int i = 0; i < digits.Length; i++)
                {
                    var current = MapC(digits[i]);
                    if (total.Count == 0) total = current;
                    else
                    {
                        var temp = new List<string>();
                        for (int j = 0; j < total.Count; j++)
                        {
                            for (int k = 0; k < current.Count; k++)
                            {
                                temp.Add(total[j]+current[k]);
                            }
                        }

                        total = temp;
                    }
                }

                return total;
            }

            private List<string> MapC(char n)
            {
                switch (n)
                {
                    case '2': return new List<string>(){"a","b","c"};
                    case '3': return new List<string>() { "d", "e", "f" };
                    case '4': return new List<string>() { "g", "h", "i" };
                    case '5': return new List<string>() { "j", "k", "l" };
                    case '6': return new List<string>() { "m", "n", "o" };
                    case '7': return new List<string>() { "p", "q", "r", "s" };
                    case '8': return new List<string>() { "t", "u", "v" };
                    case '9': return new List<string>() { "w", "x", "y", "z" };
                    default: return Enumerable.Empty<string>().ToList();
                }

                
            }
        }

        [Test]
        public void TestMethod()
        {
            var result = new Solution().LetterCombinations("23");
            Assert.AreEqual(new string[]{ "ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf" },result.ToArray());
        }
        
    }
}