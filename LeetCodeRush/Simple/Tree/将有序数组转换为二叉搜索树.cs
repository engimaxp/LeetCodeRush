using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace LeetCodeRush.Simple.Tree
{
    [TestFixture]
    public class 将有序数组转换为二叉搜索树
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
                return Create_tree(root, array, 0);
            }
            private static TreeNode Create_tree(TreeNode node, int?[] a, int index)
            {
                if (index >= a.Length)
                    return null;
                if (a[index].HasValue)
                {
                    node = new TreeNode(a[index].Value);
                    node.left = Create_tree(node.left, a, 2 * index + 1);
                    node.right = Create_tree(node.right, a, 2 * index + 2);
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
            public TreeNode SortedArrayToBST(int[] nums)
            {
                return SortedArrayToBST(nums, 0, nums.Length - 1);
            }
            public TreeNode SortedArrayToBST(int[] arr, int start, int end)
            {
                if (start > end) return null;

                int mid = start + (end - start) / 2;
                TreeNode root = new TreeNode(arr[mid])
                {
                    left = SortedArrayToBST(arr, start, mid - 1),
                    right = SortedArrayToBST(arr, mid + 1, end)
                };//newNode创建二叉树结点，具体代码请看文章 二叉树问题汇总（1）
                return root;
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
            var a = new Solution().SortedArrayToBST(new int[] {-10, -3, 0, 5, 9});
            Assert.IsNotNull(a);
        }
    }
}