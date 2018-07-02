using NUnit.Framework;

namespace LeetCodeRush.Simple.Misc
{
    [TestFixture]
    public class 汉明距离
    {
        public class Solution
        {
            public int HammingDistance(int x, int y)
            {
                var result = 0;
                while (x > 0 && y > 0)
                {
                    if ((x % 2 == 1) ^ (y % 2 == 1)) result++;

                    x = x >> 1;
                    y = y >> 1;
                }

                while (x > 0)
                {
                    if (x % 2 == 1) result++;
                    x >>= 1;
                }

                while (y > 0)
                {
                    if (y % 2 == 1) result++;
                    y >>= 1;
                }

                return result;
            }
        }

        [TestCase(1, 4, ExpectedResult = 2)]
        public int TestMethods(int x, int y)
        {
            return new Solution().HammingDistance(x, y);
        }
    }
}