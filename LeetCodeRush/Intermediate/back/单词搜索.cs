using System;
using NUnit.Framework;

namespace LeetCodeRush.Intermediate.back
{
    [TestFixture]
    public class 单词搜索
    {
        public class Solution
        {
            public bool Exist(char[,] board, string word)
            {
                if (board == null || string.IsNullOrEmpty(word)) return false;
                int m = board.GetLength(0);
                int n = board.GetLength(1);
                if (m <= 0 || n <= 0) return false;
                bool[,] visited = new bool[m,n];
                for (int j = 0; j < m; j++)
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (Dfs(word, 0, j, i, board, visited, m - 1, n - 1))
                        {
                            return true;
                        }
                        visited = new bool[m, n];
                    }
                }

                return false;
            }

            private bool Dfs(string word, int index, int row, int col, char[,] board,bool[,] visited,int maxrow,int maxcol)
            {
                if (board[row, col] == word[index])
                {
                    visited[row, col] = true;
                    if (index == word.Length - 1)
                    {
                        //find
                        return true;
                    }
                    if(row-1>=0&& !visited[row - 1, col])
                        if(Dfs(word,index+1,row-1,col,board,(bool[,])visited.Clone(),maxrow,maxcol)) return true;

                    if ( row + 1 <= maxrow&& !visited[row + 1, col])
                        if (Dfs(word, index + 1, row + 1, col, board, (bool[,])visited.Clone(), maxrow, maxcol)) return true;

                    if ( col - 1 >= 0&& !visited[row, col - 1])
                        if (Dfs(word, index + 1, row, col - 1, board, (bool[,])visited.Clone(), maxrow, maxcol)) return true;

                    if ( col+1 <= maxcol&& !visited[row, col + 1])
                        if (Dfs(word, index + 1, row, col + 1, board, (bool[,])visited.Clone(), maxrow, maxcol)) return true;

                }

                return false;
            }
        }
        [TestCase("ABCCED",ExpectedResult = true)]
        [TestCase("SEE", ExpectedResult = true)]
        [TestCase("ABCB", ExpectedResult = false)]
        public bool TestMethod(string word)
        {
            var result = new Solution().Exist(new[,]
            {
                {'A', 'B', 'C', 'E'},
                {'S', 'F', 'C', 'S'},
                { 'A', 'D', 'E', 'E'}
            }, word);
            return result;
        }
        [TestCase("AAB", ExpectedResult = true)]
        public bool TestMethod2(string word)
        {
            var result = new Solution().Exist(new[,]
            {
                {'C', 'A', 'A'},
                {'A', 'A', 'A'},
                {'B', 'C', 'D'}
            }, word);
            return result;
        }
        [TestCase("ABCESEEEFS", ExpectedResult = true)]
        public bool TestMethod3(string word)
        {
            var result = new Solution().Exist(new[,]
            {
                {'A', 'B', 'C', 'E'},
                {'S', 'F', 'E', 'S'},
                {'A', 'D', 'E', 'E'}
            }, word);
            return result;
        }
    }
}