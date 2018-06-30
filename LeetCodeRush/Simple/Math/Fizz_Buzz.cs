using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace LeetCodeRush.Simple.Calculate
{
    [TestFixture]
    public class Fizz_Buzz
    {
        public class Solution
        {
            public IList<string> FizzBuzz(int n)
            {
                var array = new List<string>();
                for (int i = 0; i < n; i++)
                {
                    if ((i + 1) % 3 == 0)
                    {
                        if ((i + 1) % 5 == 0)
                        {
                            array.Add("FizzBuzz");
                        }
                        else
                        {
                            array.Add("Fizz");
                        }
                    }else if ((i + 1) % 5 == 0)
                    {
                        array.Add("Buzz");
                    }
                    else
                    {
                        array.Add((i + 1).ToString());
                    }
                }

                return array;
            }
        }

        [Test]
        public void TestMethods()
        {
            var result = new Solution().FizzBuzz(15);
            Assert.IsNotNull(result);
        }
    }
}