using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace LeetCodeRush.Advance.Arrays
{
    [TestFixture]
    public class 四数相加II
    {
        /// <summary>
        /// 给定四个包含整数的数组列表 A , B , C , D ,计算有多少个元组 (i, j, k, l) ，使得 A[i] + B[j] + C[k] + D[l] = 0。
        /// 为了使问题简单化，所有的 A, B, C, D 具有相同的长度 N，且 0 ≤ N ≤ 500 。所有整数的范围在 -228 到 228 - 1 之间，最终结果不会超过 231 - 1 。
        /// 
        /// 例如:
        /// 
        /// 输入:
        /// A = [ 1, 2]
        /// B = [-2,-1]
        /// C = [-1, 2]
        /// D = [ 0, 2]
        /// 
        /// 输出:
        /// 2
        /// 
        /// 解释:
        /// 两个元组如下:
        /// 1. (0, 0, 0, 1) -> A[0] + B[0] + C[0] + D[1] = 1 + (-2) + (-1) + 2 = 0
        /// 2. (1, 1, 0, 0) -> A[1] + B[1] + C[0] + D[0] = 2 + (-1) + (-1) + 0 = 0
        /// </summary>
        public class Solution
        {
            public int FourSumCount(int[] A, int[] B, int[] C, int[] D)
            {
                Dictionary<int, int> map = new Dictionary<int,int>();

                int count = 0;
                for (int i = 0; i < A.Length; i++)
                {
                    for (int j = 0; j < B.Length; j++)
                    {
                        int sum = A[i] + B[j];
                        if (map.ContainsKey(sum))
                        {
                            map[sum]++;
                        }
                        else
                        {
                            map.Add(sum,1);
                        }
                    }
                }

                for (int i = 0; i < C.Length; i++)
                {
                    for (int j = 0; j < D.Length; j++)
                    {
                        map.TryGetValue(-C[i] - D[j], out var cs);
                        count += cs;
                    }
                }
                return count;
            }
        }
        [Test]
        public void TestMethod()
        {
            Assert.AreEqual(2, new Solution().FourSumCount(
                new int[] { 1, 2 },
                new int[] { -2, -1 },
                new int[] { -1, 2 },
                new int[] { 0, 2 }
                ));
        }
    }
}