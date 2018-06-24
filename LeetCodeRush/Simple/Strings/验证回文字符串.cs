using System;
using NUnit.Framework;

namespace LeetCodeRush.Simple.StringTest
{
    [TestFixture]
    public class 验证回文字符串
    {
        [TestCase("A man, a plan, a canal: Panama", 
            ExpectedResult = true)]
        [TestCase("race a car",
            ExpectedResult = false)]
        public bool TestSample(string s)
        {
            return new Solution().IsPalindrome(s);
        }
        /// <summary>
        /// 如果使用Solution2在处理超长非字母数字串时会耗时过长
        /// </summary>
        public class Solution
        {
            public bool IsPalindrome(string s)
            {
                int index = 0;
                var array = new char[s.Length];
                for (int k = 0; k < s.Length; k++)
                {
                    if ((s[k] >= 'A' && s[k] <= 'Z') || (s[k] >= 'a' && s[k] <= 'z') || (s[k] >= '0' && s[k] <= '9'))
                    {
                        if (s[k] >= 'A' && s[k] <= 'Z')
                        {
                            array[index]  = (char)(s[k] + 32);
                            index++;
                        }
                        else
                        {
                            array[index] = s[k];
                            index++;
                        }
                    }
                }

                if (array.Length <= 1) return true;

                for (int i = 0; i < index; i++)
                {
                    if (array[i] != array[index - i - 1]) return false;
                }

                return true;

            }
        }
        public class Solution2
        {
            public bool IsPalindrome(string s)
            {
                var c = s.ToCharArray();
                int i = 0;
                int j = c.Length - 1;
                while (i <= j)
                {
                    if (c[i] >= 65 && c[i] <= 90) c[i] = (char)(c[i] + 32);
                    if ((c[i] < 97 || c[i] > 122) && (c[i] < 48 || c[i] > 57))
                    {
                        i++;
                        continue;
                    }
                    if (c[j] >= 65 && c[j] <= 90) c[j] = (char)(c[j] + 32);
                    if ((c[j] < 97 || c[j] > 122) && (c[j] < 48 || c[j] > 57))
                    {
                        j--;
                        continue;
                    }

                    if (c[i] != c[j])
                    {
                        return false;
                    }
                    i++;
                    j--;
                }

                return true;

            }
        }
    }
}