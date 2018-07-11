using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace LeetCodeRush.Simple.Tree
{
    [TestFixture]
    public class 从前序与中序遍历序列构造二叉树
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

            public override string ToString()
            {
                return $"{nameof(val)}: {val}";
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
            public TreeNode BuildTree(int[] preorder, int[] inorder)
            {
                if (preorder.Length == 0 || inorder.Length == 0)
                {
                    return null;
                }
                TreeNode result = new TreeNode(preorder[0]);
                if (preorder.Length == 1)
                {
                    return result;
                }
                int top_pos = 0;
                for (top_pos = 0; top_pos < inorder.Length; top_pos++)
                {
                    if (inorder[top_pos] == preorder[0])
                    {
                        break;
                    }
                }
                int[] left_preorder = new int[top_pos];
                int[] left_inorder = new int[top_pos];
                int[] right_preorder = new int[preorder.Length - top_pos - 1];
                int[] right_inorder = new int[preorder.Length - top_pos - 1];
                for (int i = 0; i < top_pos; i++)
                {
                    left_preorder[i] = preorder[i + 1];
                    left_inorder[i] = inorder[i];
                }
                result.left = BuildTree(left_preorder, left_inorder);
                for (int i = 0; i < preorder.Length - top_pos - 1; i++)
                {
                    right_preorder[i] = preorder[i + top_pos + 1];
                    right_inorder[i] = inorder[i + top_pos + 1];
                }
                result.right = BuildTree(right_preorder, right_inorder);
                return result;

            }
        }
        [Test]
        public void TestSample2()
        {
            var root = new Solution().BuildTree(new int[] { 3, 9, 20, 15, 7 },new int[]{ 9, 3, 15, 20, 7 });
            Assert.IsNotNull(root);
        }
    }
}