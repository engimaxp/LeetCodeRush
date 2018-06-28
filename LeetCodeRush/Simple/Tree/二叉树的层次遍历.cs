using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace LeetCodeRush.Simple.Tree
{
    [TestFixture]
    public class 二叉树的层次遍历
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
            public IList<IList<int>> LevelOrder(TreeNode root)
            {
                var result = new List<IList<int>>();
                var cur_list = new Queue<TreeNode>();
                if (root != null)
                cur_list.Enqueue(root);
                var next_list = new Queue<TreeNode>();

                while (cur_list.Count > 0)
                {
                    var level = new List<int>();

                    while (cur_list.Count >0)
                    {
                        var temp = cur_list.Dequeue();
                        level.Add(temp.val);
                        if (temp.left != null)
                            next_list.Enqueue(temp.left);
                        if (temp.right != null)
                            next_list.Enqueue(temp.right);
                    }

                    result.Add(level);

                    var temp2 = cur_list;
                    cur_list = next_list;
                    next_list = temp2;
                }

                return result;

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
            var assert = new List<IList<int>>()
            {
                new List<int>(){3},
                new List<int>(){9,20},
                new List<int>(){15,7},
            };
            Assert.AreEqual(assert, new Solution().LevelOrder(root));
        }
    }
}