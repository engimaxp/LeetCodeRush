using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace LeetCodeRush.Intermediate.Arrays
{
    [TestFixture]
    public class 无重复字符的最长子串
    {
        public class Solution2
        {
            //双指针法，指针1作为字串开始位置，指针2作为字串结束为止，将指针2遍历过的元素依次放入Dictionary中
            //如果遍理过程中Dictionary存在该元素，则1跳到Dictionary[i]+1位置，重新开始循环，循环前记录最长子串的长度
            public int LengthOfLongestSubstring(string s)
            {
                if (string.IsNullOrEmpty(s)) return 0;
                int i = 0;
                int j = i;
                int max = 1;
                while (i < s.Length)
                {
                    int maxlength = 1;
                    Dictionary<char, int> dic = new Dictionary<char, int> {{s[i], i}};
                    while (++j<s.Length)
                    {
                        if (dic.ContainsKey(s[j]))
                        {
                            if (maxlength > max) max = maxlength;
                            i = dic[s[j]];
                            j = i;
                            break;
                        }
                        else
                        {
                            dic.Add(s[j],j);
                            maxlength++;
                        }
                    }

                    if (maxlength > max) max = maxlength;
                    if (j >= s.Length)
                    {
                        break;
                    }
                    i++;
                    j++;
                }
                return max;
            }
        }
        public class Solution
        {
            public int LengthOfLongestSubstring(String s)
            {
                int n = s.Length, ans = 0;
                int[] index = new int[128]; // current index of character
                // try to extend the range [i, j]
                for (int j = 0, i = 0; j < n; j++)
                {
                    i = Math.Max(index[s[j]], i);
                    ans = Math.Max(ans, j - i + 1);
                    index[s[j]] = j + 1;
                }
                return ans;
            }
        }
        [TestCase("", ExpectedResult = 0)]
        [TestCase("a", ExpectedResult = 1)]
        [TestCase("au", ExpectedResult = 2)]
        [TestCase("abcabcbb", ExpectedResult = 3)]
        [TestCase("bbbbb", ExpectedResult = 1)]
        [TestCase("pwwkew", ExpectedResult = 3)]
        public int TestMethods(string s)
        {
            return new Solution().LengthOfLongestSubstring(s);
        }
    }
}