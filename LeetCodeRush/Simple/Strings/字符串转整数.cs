using System;
using NUnit.Framework;

namespace LeetCodeRush.Simple.StringTest
{
    [TestFixture]
    public class 字符串转整数
    {
        [TestCase("42", 
            ExpectedResult = 42)]
        [TestCase("   -42",
            ExpectedResult = -42)]
        [TestCase("4193 with words",
            ExpectedResult = 4193)]
        [TestCase("words and 987",
            ExpectedResult = 0)]
        [TestCase("-91283472332",
            ExpectedResult = -2147483648)]
        [TestCase("",
            ExpectedResult = 0)]
        [TestCase("  0000000000012345678",
            ExpectedResult = 12345678)]
        [TestCase("010",
            ExpectedResult = 10)]
        [TestCase("2147483648",
            ExpectedResult = 2147483647)]
        [TestCase("0-1",
            ExpectedResult = 0)]
        public int TestSample(string str)
        {
            return new Solution().MyAtoi(str);
        }
        public class Solution
        {
            public int MyAtoi(string str)
            {
                

                var array = new char[str.Length];
                int index = 0;
                bool zeroflag = false;
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] != ' ')
                    {
                        if (str[i] == '-' || str[i] == '+' || (str[i] <= '9' && str[i] >= '0'))
                        {
                            if (i == str.Length - 1)
                            {
                                if (str[i] == '-' || str[i] == '+') return 0;
                                if (str[i] <= '9' && str[i] >= '0') return str[i] - '0';
                            }
                            else
                            {
                                if (str[i] != '0')
                                {
                                    array[index] = str[i];
                                    if (array[index] != '+' && array[index] != '-') zeroflag = true;
                                    index++;
                                }

                                for (int j = i + 1; j < str.Length; j++)
                                {
                                    if (!zeroflag && str[j] == '0') continue;
                                    if (str[j] > '9' || str[j] < '0')
                                    {
                                        break;
                                    }

                                    zeroflag = true;
                                    array[index] = str[j];
                                    index++;
                                }
                            }
                            break;
                        }
                        return 0;
                    }

                }

                if (index == 0) return 0;

                if (index == 1)
                {
                    if (array[0] == '-' || array[0] == '+') return 0;
                    if (array[0] <= '9' && array[0] >= '0') return array[0] - '0';
                }

                if (array[0] == '-')
                {
                    if (index > 11) return int.MinValue;
                }else if (array[0] == '+')
                {
                    if (index > 11) return int.MaxValue;
                }else
                {
                    if (index > 10) return int.MaxValue;
                }

                char[] c = null;
                if (array[0] == '+')
                {
                    c = new char[index-1];
                    Array.Copy(array,1,c,0,index-1);
                }
                else
                {
                    c = new char[index];
                    Array.Copy(array, c, index);
                }
                if (c[0] == '-' && c.Length == 11)
                {
                    if (CompareLessThan((-2147483648).ToString().ToCharArray(), c)) return int.MinValue;
                }
                else if (c.Length == 10)
                {
                    if (CompareLessThan(2147483647.ToString().ToCharArray(), c)) return int.MaxValue;
                }
                return Convert.ToInt32(new string(c));
            }
            public bool CompareLessThan(char[] a, char[] b)
            {
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] < b[i])
                    {
                        return true;
                    }

                    if (a[i] > b[i])
                    {
                        return false;
                    }
                }

                return false;
            }
        }
    }
}