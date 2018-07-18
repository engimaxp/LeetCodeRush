using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace LeetCodeRush.Simple.Tree
{
    [TestFixture]
    public class 二叉搜索树中第K小的元素
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
            public class TreeNodeWithCount
            {
                public TreeNodeWithCount left;
                public TreeNodeWithCount right;
                public int val;
                public int count;

                public TreeNodeWithCount(int val)
                {
                    this.val = val;
                    count = 1;
                }
                public static TreeNodeWithCount BuildTreeNode(TreeNode root)
                {
                    if (root == null) return null;
                    TreeNodeWithCount node = new TreeNodeWithCount(root.val);
                    node.left = BuildTreeNode(root.left);
                    node.right = BuildTreeNode(root.right);
                    if (node.left != null) node.count += node.left.count;
                    if (node.right != null) node.count += node.right.count;
                    return node;
                }
                public static int helper(TreeNodeWithCount node, int k)
                {
                    if (node.left != null)
                    {
                        int cnt = node.left.count;
                        if (k <= cnt)
                        {
                            return helper(node.left, k);
                        }
                        else if (k > cnt + 1)
                        {
                            return helper(node.right, k - 1 - cnt);
                        }
                        return node.val;
                    }
                    else
                    {
                        if (k == 1) return node.val;
                        return helper(node.right, k - 1);
                    }
                }

            }

            public int KthSmallest(TreeNode root, int k)
            {
                var tree = TreeNodeWithCount.BuildTreeNode(root);
                return TreeNodeWithCount.helper(tree, k);
            }
        }
        [Test]
        public void TestSample2()
        {
            var root = TreeNode.ConstructFromArray(new int?[] { 3, 1, 4, null, 2 });
            Assert.AreEqual(1, new Solution().KthSmallest(root,1));
        }
        [Test]
        public void TestSample3()
        {
            var root = TreeNode.ConstructFromArray(new int?[] { 5, 3, 6, 2, 4, null, null, 1 });
            Assert.AreEqual(3, new Solution().KthSmallest(root, 3));
        }
    }
}