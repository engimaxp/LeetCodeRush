using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace LeetCodeRush.Simple.Tree
{
    [TestFixture]
    public class 中序遍历二叉树
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
            public IList<int> InorderTraversal(TreeNode root)
            {
                var result = new List<int>();
                var stack = new Stack<TreeNode>();
                var p = root;
                while (p != null || stack.Count > 0)
                {
                    while (p != null)
                    {
                        stack.Push(p);
                        p = p.left;
                    }

                    if (stack.Count > 0)
                    {
                        p = stack.Pop();
                        result.Add(p.val);
                        p = p.right;
                    }
                }

                return result;
            }
        }

        [Test]
        public void TestSample2()
        {
            var root = TreeNode.ConstructFromArray(new int?[] {1, null, 2, null, null, 3});
            Assert.AreEqual(new[] {1, 3, 2}, new Solution().InorderTraversal(root).ToArray());
        }
    }
}