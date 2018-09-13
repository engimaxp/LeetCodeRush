using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace LeetCodeRush.Advance.Arrays
{
    [TestFixture]
    public class 基本计算器II
    {
        /// <summary>
        /// 实现一个基本的计算器来计算一个简单的字符串表达式的值。

        /// 字符串表达式仅包含非负整数，+， - ，*，/ 四种运算符和空格  。 整数除法仅保留整数部分。
        /// 
        /// 示例 1:
        /// 
        /// 输入: "3+2*2"
        /// 输出: 7
        /// 示例 2:
        /// 
        /// 输入: " 3/2 "
        /// 输出: 1
        /// 示例 3:
        /// 
        /// 输入: " 3+5 / 2 "
        /// 输出: 5
        /// 说明：
        /// 
        /// 你可以假设所给定的表达式都是有效的。
        /// 请不要使用内置的库函数 eval。
        /// </summary>
        public class Solution
        {
            public int Calculate(string s)
            {
                Stack<int> numberstack = new Stack<int>();
                int i = 0;
                //-1 + -2 -
                while (i<s.Length)
                {
                    char c = s[i];
                    if( c == ' ' )
                    {
                        i++;
                        continue;
                    }
                    else if (c == '+'  )
                    {
                        numberstack.Push(-1);
                    }
                    else if (c == '-')
                    {
                        numberstack.Push(-2);
                    }
                    else if (c == '*' || c == '/')
                    {
                        int number = 0;
                        while (++i < s.Length)
                        {
                            if (s[i] == ' ')
                            {
                                continue;
                            }
                            if (s[i] == '*' || s[i] == '/' || s[i] == '+' || s[i] == '-')
                            {
                                i--;
                                break;
                            }
                            number = number * 10 + (s[i] - '0');
                        }

                        if (c == '*')
                        {
                            numberstack.Push(numberstack.Pop() * number);
                        }

                        else if (c == '/')
                        {
                            numberstack.Push(numberstack.Pop() / number);
                        }
                    }
                    else
                    {
                        if (numberstack.Count>0 && numberstack.Peek() >= 0)
                        {
                            int pop = numberstack.Pop();
                            numberstack.Push(pop * 10 + (c - '0'));
                        }
                        else
                        {
                            numberstack.Push(c-'0');
                        }
                    }

                    i++;
                }

                Stack<int> sstack = new Stack<int>();
                for (int j = 0; numberstack.Count>0; j++)
                {
                    sstack.Push(numberstack.Pop());
                }

                int result = sstack.Pop();
                while (sstack.Count > 0)
                {
                    int icon = sstack.Pop();
                    if (icon == -1)
                    {
                        result = result + sstack.Pop();
                    }
                    else if (icon == -2)
                    {
                        result = result - sstack.Pop();
                    }
                }

                return result;
            }
        }
        [Test]
        public void TestMethod1()
        {
            Assert.AreEqual(7, new Solution().Calculate("3+2*2"));
        }
        [Test]
        public void TestMethod2()
        {
            Assert.AreEqual(1, new Solution().Calculate(" 3/2 "));
        }
        [Test]
        public void TestMethod3()
        {
            Assert.AreEqual(5, new Solution().Calculate(" 3+5 / 2 "));
        }
        [Test]
        public void TestMethod4()
        {
            Assert.AreEqual(1, new Solution().Calculate("1-1+1"));
        }

        [Test]
        public void TestMethod5()
        {
            Assert.AreEqual(-2147483647, new Solution().Calculate("0-2147483647"));
        }
    }
}