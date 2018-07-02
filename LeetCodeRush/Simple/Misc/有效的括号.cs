using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace LeetCodeRush.Simple.Misc
{
    [TestFixture]
    public class 有效的括号
    {
        public class Solution
        {
            public bool IsValid(string s)
            {
                Stack<char> a =  new Stack<char>();
                for (int i = 0; i < s.Length; i++)
                {
                    if(s[i] == '(') a.Push(')');
                    else if (s[i] == '{') a.Push('}');
                    else if (s[i] == '[') a.Push(']');
                    else if (a.Count == 0) return false;
                    else if (s[i] != a.Pop())
                    {
                        return false;
                    }
                }

                return a.Count == 0;
            }
        }
        [TestCase("()",ExpectedResult = true)]
        [TestCase("()[]{}", ExpectedResult = true)]
        [TestCase("(]", ExpectedResult = false)]
        [TestCase("([)]", ExpectedResult = false)]
        [TestCase("{[]}", ExpectedResult = true)]
        public bool TestMethod(string s)
        {
            return new Solution().IsValid(s);
        }
    }
}