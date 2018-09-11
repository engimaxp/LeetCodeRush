using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace LeetCodeRush.Advance.Arrays
{
    [TestFixture]
    public class 螺旋矩阵
    {
        /// <summary>
        /// 给定一个包含 m x n 个元素的矩阵（m 行, n 列），请按照顺时针螺旋顺序，返回矩阵中的所有元素。
        /// 示例 1:
        /// 
        /// 输入:
        /// [
        /// [ 1, 2, 3 ],
        /// [ 4, 5, 6 ],
        /// [ 7, 8, 9 ]
        /// ]
        /// 输出: [1,2,3,6,9,8,7,4,5]
        /// 示例 2:
        /// 
        /// 输入:
        /// [
        /// [1, 2, 3, 4],
        /// [5, 6, 7, 8],
        /// [9,10,11,12]
        /// ]
        /// 输出: [1,2,3,4,8,12,11,10,9,5,6,7]
        /// </summary>

        public class Solution
        {
            public IList<int> SpiralOrder(int[,] matrix)
            {
                var result = new List<int>();
                int m = matrix.GetLength(0);
                int n = matrix.GetLength(1);
                int mmin = 0;
                int mmax = m-1;
                int nmin = 0;
                int nmax = n - 1;
                int direction = 0;
                int i = 0;
                int j = 0;
                while (mmin <= mmax || nmin <= nmax)
                {
                    if (i > mmax)
                    {
                        direction = 1;
                        nmax--;
                        if( nmin > nmax) break;
                        i = mmax;
                        --j;
                    }
                    else if (i < mmin)
                    {
                        direction = 0;
                        nmin++;
                        if ( nmin > nmax) break;
                        i = mmin;
                        ++j;
                    }
                    else if (j > nmax)
                    {
                        direction = 2;
                        mmin++;
                        if (mmin > mmax) break;
                        j = nmax;
                        ++i;
                    }
                    else if (j < nmin)
                    {
                        direction = 3;
                        mmax--;
                        if (mmin > mmax) break;
                        j = nmin;
                        --i;
                    }
                    result.Add(matrix[i,j]);
                    switch (direction)
                    {
                        case 0://right
                        {
                            ++j;
                            break;
                        }
                        case 1://left
                        {
                            --j;
                            break;
                        }
                        case 2://down
                        {
                            ++i;
                            break;
                        }
                        case 3://up
                        {
                            --i;
                            break;
                        }
                    }
                }

                return result;
            }
        }
        [Test]
        public void TestMethod1()
        {
            int[,] matrix = new int[,]
            {
                {1, 2, 3},
                {4, 5, 6},
                { 7, 8, 9}
            };
            Assert.AreEqual(new int[]{ 1, 2, 3, 6, 9, 8, 7, 4, 5 }, new Solution().SpiralOrder(matrix));
        }
        [Test]
        public void TestMethod2()
        {
            int[,] matrix = new int[,]
            {
                {1, 2, 3, 4},
                {5, 6, 7, 8},
                { 9, 10, 11, 12}
            };
            Assert.AreEqual(new int[] { 1, 2, 3, 4, 8, 12, 11, 10, 9, 5, 6, 7 }, new Solution().SpiralOrder(matrix));
        }
        [Test]
        public void TestMethod3()
        {
            int[,] matrix = new int[,]
            {
                {1}
            };
            Assert.AreEqual(new int[] {1 }, new Solution().SpiralOrder(matrix));
        }
    }
}