using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace LeetCodeRush.Advance.Arrays
{
    [TestFixture]
    public class 最小窗口子字符串
    {
        /// <summary>
        /// 给定一个字符串 S 和一个字符串 T，请在 S 中找出包含 T 所有字母的最小子串。

        /// 示例：
        /// 
        /// 输入: S = "ADOBECODEBANC", T = "ABC"
        /// 输出: "BANC"
        /// 说明：
        /// 
        /// 如果 S 中不存这样的子串，则返回空字符串 ""。
        /// 如果 S 中存在这样的子串，我们保证它是唯一的答案。
        /// </summary>
        public class Solution
        {
            public string MinWindow(string s, string t)
            {
                if (t.Length > s.Length) return "";
                string res = "";
                int left = 0, count = 0, minLen = s.Length + 1;
                int[] tm = new int[256], sm= new int[256];
                for (int i = 0; i < t.Length; ++i) ++tm[t[i]];
                for (int right = 0; right < s.Length; ++right)
                {
                    if (tm[s[right]] != 0)
                    {
                        ++sm[s[right]];
                        if (sm[s[right]] <= tm[s[right]]) ++count;
                        while (count == t.Length)
                        {
                            if (right - left + 1 < minLen)
                            {
                                minLen = right - left + 1;
                                res = s.Substring(left, minLen);
                            }
                            if (tm[s[left]] != 0)
                            {
                                --sm[s[left]];
                                if (sm[s[left]] < tm[s[left]]) --count;
                            }
                            ++left;
                        }
                    }
                }
                return res;
            }
        }
        [Test]
        public void TestMethod()
        {
            Assert.AreEqual("BANC", new Solution().MinWindow("ADOBECODEBANC","ABC"));
        }
    }
}