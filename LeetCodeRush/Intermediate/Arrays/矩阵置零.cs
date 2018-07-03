using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace LeetCodeRush.Intermediate.Arrays
{
    [TestFixture]
    public class 矩阵置零
    {
        public class Solution2
        {
            public string PrintM(int[,] matrix)
            {
                StringBuilder s = new StringBuilder();
                int lengthX = matrix.GetLength(0);
                int lengthY = matrix.GetLength(1);
                for (int i = 0; i < lengthX; i++)
                {
                    for (int j = 0; j < lengthY; j++)
                    {
                        s.Append(matrix[i,j] + " ");
                    }

                    s.Append(Environment.NewLine);
                }
                return s.ToString();
            }
            public void SetZeroes(int[,] matrix)
            {
                int lengthX = matrix.GetLength(0);
                int lengthY = matrix.GetLength(1);
                bool firstRow0 = false;
                bool firstColumn0 = false;
                for (int i = 0; i < lengthY; i++)
                {
                    if (matrix[0, i] == 0)
                    {
                        firstRow0 = true;
                        break;
                    }
                }
                for (int i = 0; i < lengthX; i++)
                {
                    if (matrix[i,0] == 0)
                    {
                        firstColumn0 = true;
                        break;
                    }
                }

                for (int i = 1; i < lengthX; i++)
                {
                    for (int j = 1; j < lengthY; j++)
                    {
                        if (matrix[i, j] == 0)
                        {
                            matrix[0, j] = 0;
                            matrix[i, 0] = 0;
                        }
                    }
                }

                for (int i = 1; i < lengthY; i++)
                {
                    if (matrix[0, i] == 0)
                    {
                        for (int j = 1; j < lengthX; j++)
                        {
                            matrix[j, i] = 0;
                        }
                    }
                }
                for (int i = 0; i < lengthX; i++)
                {
                    if (matrix[i,0] == 0)
                    {
                        for (int j = 1; j < lengthY; j++)
                        {
                            matrix[i,j] = 0;
                        }
                    }
                }

                if (firstRow0)
                {
                    for (int i = 0; i < lengthY; i++)
                    {
                        matrix[0, i] = 0;
                    }

                }
                if (firstColumn0)
                {
                    for (int i = 0; i < lengthX; i++)
                    {
                        matrix[i,0] = 0;
                    }

                }
            }
        }
        public class Solution
        {
            public void SetZeroes(int[,] matrix)
            {
                var firstRowContains0 = false;
                int x = matrix.GetLength(0);
                int y = matrix.GetLength(1);
                for (int i = 0; i < y; i++)
                {
                    if (matrix[0, i] == 0)
                    {
                        firstRowContains0 = true;
                        break;
                    }
                }

                for (int i = 1; i < x; i++)
                {
                    var thisRowContains0 = false;
                    for (int j = 0; j < y; j++)
                    {
                        if (matrix[i, j] == 0)
                        {
                            thisRowContains0 = true;
                            matrix[0, j] = 0;
                        }

                    }
                    if (thisRowContains0)
                    {
                        for (int k = 0; k < y; k++)
                        {
                            matrix[i, k] = 0;
                        }

                    }
                }

                for (int i = 0; i < y; i++)
                {
                    if (matrix[0, i] == 0)
                    {
                        for (int j = 0; j < x; j++)
                        {
                            matrix[j, i] = 0;
                        }
                    }
                }

                if (firstRowContains0)
                {
                    for (int i = 0; i < y; i++)
                    {
                        matrix[0, i] = 0;
                    }
                }
                
            }
        }
        [Test]
        public void TestMethod()
        {
            var input = new int[,]
            {
                {1, 1, 1},
                {1,0,1 },
                {1,1,1 }
            };
            new Solution().SetZeroes(input);
            Assert.IsNotNull(input);
        }
        [Test]
        public void TestMethod2()
        {
            var input = new int[,]
            {
                {0, 1, 2, 0},
                {3, 4, 5, 2},
                { 1, 3, 1, 5}
            };
            new Solution().SetZeroes(input);
            Assert.IsNotNull(input);
        }
        [Test]
        public void TestMethod3()
        {
            var input = new int[,]
            {
                {1,0},
            };
            new Solution().SetZeroes(input);
            Assert.IsNotNull(input);
        }
        [Test]
        public void TestMethod4()
        {
            var input = new int[,]
            {
                { 1, 1, 1},
                { 0, 1, 2}
            };
            new Solution().SetZeroes(input);
            Assert.IsNotNull(input);
        }
    }
}