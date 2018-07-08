using System;
using NUnit.Framework;

namespace LeetCodeRush.Contest.Week92
{
    [TestFixture]
    public class 转置矩阵
    {
        [Test]
        public void TestMethods()
        {
            var array = new int[][]{ new int[]{1,2,3}, new int[] {4,5,6}, new int[] { 7,8,9 }, };
            var result = new Solution().Transpose(array);
            Assert.IsNotNull(result);
        }

        [Test]
        public void TestMethods2()
        {
            var array = new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }};
            var result = new Solution().Transpose(array);
            Assert.IsNotNull(result);
        }

        [Test]
        public void TestMethods3()
        {
            var array = new int[][] { new int[] { 0,1 } };
            var result = new Solution().Transpose(array);
            Assert.IsNotNull(result);
        }
        public class Solution
        {
            public int[][] Transpose(int[][] A)
            {
                if (A == null || A.Length == 0) return null;
                if (A[0] == null || A[0].Length == 0) return null;
                int xlength = A.GetLength(0);
                int ylength = A[0].GetLength(0);
                int[][] result = new int[ylength][];
                for (int i = 0; i < ylength; i++)
                {
                    result[i] = new int[xlength];
                    for (int j = 0; j < xlength; j++)
                    {
                        result[i][j] = A[j][i];
                    }
                }

                return result;
            }
        }
    }
}