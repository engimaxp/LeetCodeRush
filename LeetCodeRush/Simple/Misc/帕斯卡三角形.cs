using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace LeetCodeRush.Simple.Misc
{
    [TestFixture]
    public class 帕斯卡三角形
    {
        public class Solution
        {
            public IList<IList<int>> Generate(int numRows)
            {
                var result = new List<IList<int>>();
                for (int i = 1; i <= numRows; i++)
                {
                    if(i == 1) result.Add(new List<int>(){1});
                    else
                    {
                        var temp = new List<int>();
                        for (int j = 0; j < i; j++)
                        {
                            if (j == 0 || j == i-1) temp.Add(1);
                            else
                            {
                                temp.Add(result[i - 2][j] + result[i - 2][j - 1]);
                            }
                        }
                        result.Add(temp);
                    }
                }
                return result;
            }
        }

        [Test]
        public void TestMethod()
        {
            var a = new Solution().Generate(5);
            Assert.IsNotNull(a);
        }
    }
}