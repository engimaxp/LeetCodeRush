using NUnit.Framework;

namespace LeetCodeRush.Simple.ArrayTest
{
    [TestFixture]
    public class 有效的数独
    {
        public class Solution
        {
            public bool IsValidSudoku(char[,] board)
            {
                var rowFlag = new bool[9,9];
                var colFlag = new bool[9,9];
                var cellFlag = new bool[9,9];

                for (int i = 0; i < 9; ++i)
                {
                    for (int j = 0; j < 9; ++j)
                    {
                        if (board[i,j] >= '1' && board[i,j] <= '9')
                        {
                            int c = board[i,j] - '1';
                            if (rowFlag[i,c] || colFlag[c,j] || cellFlag[3 * (i / 3) + j / 3,c]) return false;
                            rowFlag[i,c] = true;
                            colFlag[c,j] = true;
                            cellFlag[3 * (i / 3) + j / 3,c] = true;
                        }
                    }
                }
                return true;
            }
        }

        public class Solution2
        {
            public bool IsValidSudoku(char[,] board)
            {
                for (var i = 0; i < 9; i++)
                for (var j = 0; j < 9; j++)
                {
                    if (board[i, j] == '.') continue;
                    if (!ValidHo(i, j, board)) return false;
                    if (!ValidVe(i, j, board)) return false;
                    if (!ValidBlock(i, j, board)) return false;
                }

                return true;
            }

            private bool ValidBlock(int i, int j, char[,] board)
            {
                int x = i % 3, y = j % 3;
                int a = x, b = y;
                if (x + y == 4) return true;
                while (x + y < 4)
                {
                    x++;
                    if (x == 3)
                    {
                        x = 0;y++;}

                    if (board[i - a + x, j - b + y] == board[i, j]) return false;
                }

                return true;
            }

            private bool ValidVe(int i, int j, char[,] board)
            {
                for (var k = j + 1; k < 9; k++)
                    if (board[i, j] == board[i, k])
                        return false;

                return true;
            }

            private bool ValidHo(int i, int j, char[,] board)
            {
                for (var k = i + 1; k < 9; k++)
                    if (board[i, j] == board[k, j])
                        return false;

                return true;
            }
        }

        [Test]
        public void TestSample1()
        {
            char[,] input =
            {
                {'5', '3', '.', '.', '7', '.', '.', '.', '.'},
                {'6', '.', '.', '1', '9', '5', '.', '.', '.'},
                {'.', '9', '8', '.', '.', '.', '.', '6', '.'},
                {'8', '.', '.', '.', '6', '.', '.', '.', '3'},
                {'4', '.', '.', '8', '.', '3', '.', '.', '1'},
                {'7', '.', '.', '.', '2', '.', '.', '.', '6'},
                {'.', '6', '.', '.', '.', '.', '2', '8', '.'},
                {'.', '.', '.', '4', '1', '9', '.', '.', '5'},
                {'.', '.', '.', '.', '8', '.', '.', '7', '9'}
            };
            Assert.IsTrue(new Solution().IsValidSudoku(input));
        }

        [Test]
        public void TestSample2()
        {
            char[,] input =
            {
                {'8', '3', '.', '.', '7', '.', '.', '.', '.'},
                {'6', '.', '.', '1', '9', '5', '.', '.', '.'},
                {'.', '9', '8', '.', '.', '.', '.', '6', '.'},
                {'8', '.', '.', '.', '6', '.', '.', '.', '3'},
                {'4', '.', '.', '8', '.', '3', '.', '.', '1'},
                {'7', '.', '.', '.', '2', '.', '.', '.', '6'},
                {'.', '6', '.', '.', '.', '.', '2', '8', '.'},
                {'.', '.', '.', '4', '1', '9', '.', '.', '5'},
                {'.', '.', '.', '.', '8', '.', '.', '7', '9'}
            };
            Assert.IsFalse(new Solution().IsValidSudoku(input));
        }
    }
}