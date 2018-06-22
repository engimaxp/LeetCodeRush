using NUnit.Framework;

namespace LeetCodeRush
{
    [TestFixture]
    public class 旋转图像
    {
        public class Solution
        {
            public void swap(int i, int j, int k, int l, int[,] array)
            {
                var temp = array[i, j];
                array[i, j] = array[k, l];
                array[k, l] = temp;
            }
            public void Rotate(int[,] matrix)
            {
                int n = matrix.GetLength(0);
                for (int i = 0; i < n - 1; ++i)
                {
                    for (int j = 0; j < n - i; ++j)
                    {
                        swap(i,j, n - 1 - j,n - 1 - i, matrix);
                    }
                }
                for (int i = 0; i < n / 2; ++i)
                {
                    for (int j = 0; j < n; ++j)
                    {
                        swap(i, j, n - 1 - i, j, matrix);
                    }
                }
            }
        }

        public class Solution2
        {
            public void swap(int i, int j,int k, int l, int[,] array)
            {
                var temp = array[i,j];
                array[i,j] = array[k,l];
                array[k, l] = temp;
            }
            public void Rotate(int[,] matrix)
            {
                int length = matrix.GetLength(0);
                for (int i = 0; i < length; i++)
                {
                    for (int j = i+1; j < length; j++)
                    {
                        if (i == j) continue;
                        swap(i, j, j, i, matrix);
                    }

                }

                int a = 0;
                while (a < length -1- a)
                {
                    for (int c = 0; c < length; c++)
                    {
                        swap(c,a, c, length -1- a,  matrix);
                    }
                        a++;
                }
            }
        }

        [Test]
        public void TestSample1()
        {
            int[,] matrix =
            {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9}
            };
            int[,] targetMatrix =
            {
                {7, 4, 1},
                {8, 5, 2},
                {9, 6, 3}
            };
            new Solution().Rotate(matrix);
            Assert.AreEqual(targetMatrix, matrix);
        }

        [Test]
        public void TestSample2()
        {
            int[,] matrix =
            {
                {5, 1, 9, 11},
                {2, 4, 8, 10},
                {13, 3, 6, 7},
                {15, 14, 12, 16}
            };
            int[,] targetMatrix =
            {
                {15, 13, 2, 5},
                {14, 3, 4, 1},
                {12, 6, 8, 9},
                {16, 7, 10, 11}
            };
            new Solution().Rotate(matrix);
            Assert.AreEqual(targetMatrix, matrix);
        }
    }
}