using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace LeetCodeRush.Intermediate.Arrays
{
    [TestFixture]
    public class 字谜分组
    {
        public class Solution
        {
            public IList<IList<string>> GroupAnagrams(string[] strs)
            {
                if (strs == null || strs.Length == 0)
                {
                    return new List<IList<String>>();
                }
                Dictionary<String, List<String>> map = new Dictionary<String, List<String>>();
                for (var i = 0; i < strs.Length; i++ )
                {
                    var s = strs[i];
                    char[] ca = s.ToCharArray();
                    Array.Sort(ca);
                    String keyStr = new String(ca);
                    if (!map.ContainsKey(keyStr))
                        map.Add(keyStr, new List<String>());
                    map[keyStr].Add(s);
                }

                var result = new List<IList<string>>();
                foreach (var mapKey in map.Keys)
                {
                    result.Add(map[mapKey]);
                }
                return result;
            }
        }

        [Test]
        public void TestMethods()
        {
            var result = new Solution().GroupAnagrams(new string[]{"eat", "tea", "tan", "ate", "nat", "bat"});
            Assert.IsNotNull(result);
        }
    }
}