using NUnit.Framework;

namespace LeetCodeRush.Intermediate.SortSearch
{
    [TestFixture]
    public class 搜索二维矩阵2
    {
        public class Solution
        {
            public bool SearchMatrix(int[,] matrix, int target)
            {
                if (matrix == null || matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0) return false;
                var m = matrix.GetLength(0);
                var n = matrix.GetLength(1);
                if (target < matrix[0, 0] || target > matrix[m - 1, n - 1]) return false;
                int x = m - 1, y = 0;
                while (true)
                {
                    if (matrix[x, y] > target) --x;
                    else if (matrix[x, y] < target) ++y;
                    else return true;
                    if (x < 0 || y >= n) break;
                }

                return false;
            }
        }

        [Test]
        public void TestMethod()
        {
            int[,] matrix =
            {
                {1, 4, 7, 11, 15},
                {2, 5, 8, 12, 19},
                {3, 6, 9, 16, 22},
                {10, 13, 14, 17, 24},
                {18, 21, 23, 26, 30}
            };
            Assert.AreEqual(true, new Solution().SearchMatrix(matrix, 5));
            Assert.AreEqual(false, new Solution().SearchMatrix(matrix, 20));
        }
    }
}