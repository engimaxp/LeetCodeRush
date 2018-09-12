using System;
using System.Runtime.CompilerServices;
using NUnit.Framework;

namespace LeetCodeRush.Advance.Arrays
{
    [TestFixture]
    public class 生命游戏
    {
        /// <summary>
        /// 根据百度百科，生命游戏，简称为生命，是英国数学家约翰·何顿·康威在1970年发明的细胞自动机。
        /// 给定一个包含 m × n 个格子的面板，每一个格子都可以看成是一个细胞。每个细胞具有一个初始状态 live（1）即为活细胞， 或 dead（0）即为死细胞。每个细胞/与 /其/八个相邻位置（水平，垂直，对角线）的细胞都遵循以下四条生存定律：
        /// 
        /// 如果活细胞周围八个位置的活细胞数少于两个，则该位置活细胞死亡；
        /// 如果活细胞周围八个位置有两个或三个活细胞，则该位置活细胞仍然存活；
        /// 如果活细胞周围八个位置有超过三个活细胞，则该位置活细胞死亡；
        /// 如果死细胞周围正好有三个活细胞，则该位置死细胞复活；
        /// 根据当前状态，写一个函数来计算面板上细胞的下一个（一次更新后的）状态。下一个状态是通过将上述规则同时应用于当前状态下的每个细胞所形成的，其中细胞的 //出/生和死亡是同时发生的。
        /// 
        /// 示例:
        /// 
        /// 输入: 
        /// [
        /// [0,1,0],
        /// [0,0,1],
        /// [1,1,1],
        /// [0,0,0]
        /// ]
        /// 输出: 
        /// [
        /// [0,0,0],
        /// [1,0,1],
        /// [0,1,1],
        /// [0,1,0]
        /// ]
        /// 进阶:
        /// 
        /// 你可以使用原地算法解决本题吗？请注意，面板上所有格子需要同时被更新：你不能先更新某些格子，然后使用它们的更新后的值再更新其他格子。
        /// 本题中，我们使用二维数组来表示面板。原则上，面板是无限的，但当活细胞侵占了面板边界时会造成问题。你将如何解决这些问题？
        /// </summary>
        public class Solution
        {
            public void GameOfLife(int[][] board)
            {
                for (int i = 0; i < board.Length; i++)
                {
                    for (int j = 0; j < board[0].Length; j++)
                    {
                        IsAlive(i,j,board);
                    }
                }
                for (int i = 0; i < board.Length; i++)
                {
                    for (int j = 0; j < board[0].Length; j++)
                    {
                        if (board[i][j] == 2) board[i][j] = 0;
                        if (board[i][j] == 3) board[i][j] = 1;
                    }
                }
            }

            public void IsAlive(int x, int y, int[][] board)
            {
                int live = NeighbourLiveCell(x, y, board);
                if (board[x][y] == 0)
                {
                    if (live == 3) board[x][y] = 3;
                }
                else
                {
                    if (live >= 2 && live <= 3) board[x][y] = 1;
                    else board[x][y] = 2;
                }
            }

            public int Clive(int val)
            {
                if (val <= 1) return val;
                else if (val == 2) return 1;
                else return 0;
            }

            /// <summary>
            /// result > 3 -> result = 4
            /// </summary>
            public int NeighbourLiveCell(int x, int y, int[][] board)
            {
                int result = 0;
                for (int i = x-1; i < x+2; i++)
                {
                    if(i<0||i>board.Length-1)continue;
                    for (int j = y-1; j < y+2; j++)
                    {
                        if (j < 0 || j > board[0].Length - 1) continue;
                        if (i == x && j == y) continue;
                        result += Clive(board[i][j]);
                        if (result > 3) return 4;
                    }
                }

                return result;
            }
        }
        [Test]
        public void TestMethod1()
        {
            int[][] board = new int[][]
            {
                new int[]{ 0,1,0   },
                new int[]{ 0,0,1   },
                new int[]{ 1,1,1   },
                new int[]{ 0,0,0   },
            };
            new Solution().GameOfLife(board);
            Assert.AreEqual(new int[] { 0,0,0 }, board[0]);
            Assert.AreEqual(new int[] { 1,0,1 }, board[1]);
            Assert.AreEqual(new int[] { 0,1,1 }, board[2]);
            Assert.AreEqual(new int[] { 0, 1, 0 }, board[3]);
        }
    }
}