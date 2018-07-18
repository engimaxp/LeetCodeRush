using System;
using NUnit.Framework;

namespace LeetCodeRush.Simple.Tree
{
    [TestFixture]
    public class 岛屿的个数
    {
        public class TreeNode
        {
            public TreeNode left;
            public TreeNode right;
            public int val;

            public TreeNode(int x)
            {
                val = x;
            }

            public static TreeNode ConstructFromArray(int?[] array)
            {
                var root = new TreeNode(0);
                return create_tree(root, array, 0);
            }

            private static TreeNode create_tree(TreeNode node, int?[] a, int index)
            {
                if (index >= a.Length)
                    return null;
                if (a[index].HasValue)
                {
                    node = new TreeNode(a[index].Value);
                    node.left = create_tree(node.left, a, 2 * index + 1);
                    node.right = create_tree(node.right, a, 2 * index + 2);
                }
                else
                {
                    node = null;
                }

                return node;
            }
        }

        public class Solution
        {
            public int NumIslands(char[,] grid)
            {
                if (grid.Length == 0)
                    return 0;
                int m = grid.GetLength(0), n = grid.GetLength(1);
                int count = 0;
                for (int i = 0; i < m; ++i)
                {
                    for (int j = 0; j < n; ++j)
                    {
                        if (grid[i,j] == '1')
                        {
                            ++count;
                            dfs(grid, i, j);
                        }
                    }// for
                }// for
                return count;
            }
            public void dfs(char[,] grid, int x, int y)
            {
                if ((x < 0) || (y < 0) || (x >= grid.GetLength(0)) || (y >= grid.GetLength(1)) || grid[x,y] == '0')
                    return;
                grid[x,y] = '0';
                dfs(grid, x - 1, y);
                dfs(grid, x, y - 1);
                dfs(grid, x + 1, y);
                dfs(grid, x, y + 1);
            }

        }

        [Test]
        public void TestSample2()
        {
            var root = new char[,]{{'1','1','1','1','0'},
                    {'1','1','0','1','0'},
                    {'1','1','0','0','0'},
                    {'0','0','0','0','0'}}
                ;
            Assert.AreEqual(1, new Solution().NumIslands(root));
        }
        [Test]
        public void TestSample3()
        {
            var root = new char[,] {{'1','1','0','0','0'},
                {'1','1','0','0','0'},
                {'0','0','1','0','0'},
                {'0','0','0','1','1'}};
            Assert.AreEqual(3, new Solution().NumIslands(root));
        }
    }
}