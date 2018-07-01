using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace LeetCodeRush.Contest.Week91
{
    [TestFixture]
    public class 二叉树中所有距离为K的结点
    {
        [Test]
        public void TestMethods()
        {
            var array = new int?[]{ 3, 5, 1, 6, 2, 0, 8, null, null, 7, 4 };
            var root = TreeNode.ConstructFromArray(array);
            var result = new Solution().DistanceK(root,new TreeNode(5), 2);
            Assert.IsNotNull(result);
        }

        [Test]
        public void TestMethods2()
        {
            var array = new int?[] {0,1,null,null,2,null,3,null,4 };
            var root = TreeNode.ConstructFromArray(array);
            var result = new Solution().DistanceK(root, new TreeNode(3), 0);
            Assert.IsNotNull(result);
        }

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
            public IList<int> DistanceK(TreeNode root, TreeNode target, int K)
            {
                List<int> results = new List<int>();
                FindTarget(root, target, results, K);
                return results;
            }

            public int FindTarget(TreeNode root,TreeNode target, IList<int> result, int K)
            {
                if (root == null) return 0;

                if (root.left != null)
                {
                    var findOnLeft = FindTarget(root.left, target, result, K);
                    if (findOnLeft != 0)
                    {
                        if (findOnLeft == K) result.Add(root.val);
                        else if (findOnLeft < K)
                            FindDistanceK(root.right, K - findOnLeft-1, result);
                        return findOnLeft + 1;
                    }
                }
                if (root.right != null)
                {
                    var findOnRight = FindTarget(root.right, target, result, K);
                    if (findOnRight != 0)
                    {
                        if (findOnRight == K) result.Add(root.val);
                        else if (findOnRight < K)
                            FindDistanceK(root.left, K - findOnRight-1, result);
                        return findOnRight + 1;
                    }
                }

                if (root.val == target.val)
                {
                    if (K == 0)
                    {
                        result.Add(root.val);
                        return 0;
                    }
                    FindDistanceK(root.left, K - 1, result);
                    FindDistanceK(root.right, K - 1, result);
                    //start find in both left right tree
                    return 1;
                }

                return 0;
            }
            public void FindDistanceK(TreeNode node, int K, IList<int> result)
            {
                if (node == null) return;
                if (K == 0)
                {
                    result.Add(node.val);
                    return;
                }

                if (node.left != null)
                {
                    FindDistanceK(node.left, K - 1, result);
                }

                if (node.right != null)
                {
                    FindDistanceK(node.right, K - 1, result);
                }
            }
        }
    }
}