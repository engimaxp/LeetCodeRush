using System;
using NUnit.Framework;

namespace LeetCodeRush.Simple.Tree
{
    [TestFixture]
    public class 二叉树的最大深度
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
                TreeNode root = new TreeNode(0);
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
            public int MaxDepth(TreeNode root)
            {
                if (root == null) return 0;
                int max = 1;
                if (root.left != null)
                {
                    max = Math.Max(MaxDepth(root.left)+1,max);
                }

                if (root.right != null)
                {
                    max = Math.Max(MaxDepth(root.right)+1, max);
                }

                return max;
            }
        }

        [Test]
        public void TestSample()
        {
            var root = TreeNode.ConstructFromArray(new int?[] {3, 9, 20, null, null, 15, 7});
            Assert.AreEqual(15,root.right.left.val);
        }
        [Test]
        public void TestSample2()
        {
            var root = TreeNode.ConstructFromArray(new int?[] { 3, 9, 20, null, null, 15, 7 });
            Assert.AreEqual(3, new Solution().MaxDepth(root));
        }
    }
}