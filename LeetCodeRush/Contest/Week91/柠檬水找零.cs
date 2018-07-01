using System;
using NUnit.Framework;

namespace LeetCodeRush.Contest.Week91
{
    [TestFixture]
    public class 柠檬水找零
    {
        [Test]
        public void TestMethods()
        {
            var array = new int[]{ 5, 5, 5, 10, 20};
            var result = new Solution().LemonadeChange(array);
            Assert.AreEqual(true,result);
        }
        [Test]
        public void TestMethods2()
        {
            var array = new int[] { 5, 5, 10 };
            var result = new Solution().LemonadeChange(array);
            Assert.AreEqual(true, result);
        }
        [Test]
        public void TestMethods3()
        {
            var array = new int[] { 10, 10 };
            var result = new Solution().LemonadeChange(array);
            Assert.AreEqual(false, result);
        }
        [Test]
        public void TestMethods4()
        {
            var array = new int[] { 5, 5, 10, 10, 20 };
            var result = new Solution().LemonadeChange(array);
            Assert.AreEqual(false, result);
        }
        //当第i项大于5时，至第i-1的和必须大于等于（第i项-5）且手里5元的数量大于等于1张
        public class Solution
        {
            public bool LemonadeChange(int[] bills)
            {
                int max = 0;
                int fives = 0;
                int tens = 0;
                for (int i = 0; i < bills.Length; i++)
                {
                    if (bills[i] == 5)
                    {
                        fives++;
                        max += 5;
                        continue;
                    }
                    else if (bills[i] == 10)
                    {
                        tens++;
                        fives--;
                    }
                    else if (bills[i] == 20)
                    {
                        if (tens > 0)
                        {
                            tens--;
                            fives--;
                        }
                        else
                        {
                            fives -= 3;
                        }
                    }
                    if (max< (bills[i] - 5)|| fives < 0)
                    {
                        return false;
                    }

                    max += 5;

                }

                return true;
            }
        }
    }
}