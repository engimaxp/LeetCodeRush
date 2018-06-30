using System;
using NUnit.Framework;

namespace LeetCodeRush.Simple.StringTest
{
    [TestFixture]
    public class 颠倒整数
    {
        [TestCase(123,
            ExpectedResult = 321)]
        [TestCase(-123,
            ExpectedResult = -321)]
        [TestCase(120,
            ExpectedResult = 21)]
        [TestCase(0,
            ExpectedResult = 0)]
        [TestCase(1,
            ExpectedResult = 1)]
        [TestCase(-1,
            ExpectedResult = -1)]
        [TestCase(1111111147,
            ExpectedResult = 0)]
        [TestCase(2147483647,
            ExpectedResult = 0)]
        [TestCase(-2147483648,
            ExpectedResult = 0)]
        [TestCase(7463847412,
            ExpectedResult = 2147483647)]
        [TestCase(-8463847412,
            ExpectedResult = -2147483648)]
        [TestCase(7463897412,
            ExpectedResult = 0)]
        [TestCase(-8463947412,
            ExpectedResult = 0)]
        [TestCase(7463847412000,
            ExpectedResult = 2147483647)]
        [TestCase(-8463847412000,
            ExpectedResult = -2147483648)]
        [TestCase(7463897412000,
            ExpectedResult = 0)]
        [TestCase(-8463947412000,
            ExpectedResult = 0)]
        [TestCase(-2147483412,
            ExpectedResult = -2143847412)]
        public Int64 TestSample(Int64 x)
        {
            return new Solution().Reverse(x);
        }
        public class Solution
        {
            public Int64 Reverse(Int64 x)
            {

                var array = x.ToString().ToCharArray();
                int i = array[0] == '-'?1:0;
                int j = array.Length - 1;
                int tlength = array.Length ;
                bool zeroDetect = false;
                while (i < j)
                {
                    if (!zeroDetect && array[j] == '0')
                    {
                        j--;
                        tlength--;
                    }
                    else
                    {
                        zeroDetect = true;
                        Swaq(i, j, array);
                        i++;
                        j--;
                    }
                }

                var c = new char[tlength];
                Array.Copy(array, c, tlength);

                if (c[0] == '-')
                {
                    if (c.Length>11) return 0;
                }
                else
                {
                    if (c.Length > 10) return 0;
                }

                

                if (c[0] == '-' && c.Length == 11)
                {
                    if (CompareLessThan((-2147483648).ToString().ToCharArray(), c)) return 0;
                }
                else if(c.Length == 10)
                {
                    if (CompareLessThan(2147483647.ToString().ToCharArray(), c)) return 0;
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

            public void Swaq(int i, int j,char[] c)
            {
                var temp = c[i];
                c[i] = c[j];
                c[j] = temp;
            }
        }
    }
}