using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace LeetCodeRush.Simple.Tree
{
    [TestFixture]
    public class 每个节点的右向指针
    {
        public class TreeLinkNode
        {
            public TreeLinkNode left;
            public TreeLinkNode right;
            public TreeLinkNode next;
            public int val;

            public TreeLinkNode(int x)
            {
                val = x;
            }

            public static TreeLinkNode ConstructFromArray(int?[] array)
            {
                var root = new TreeLinkNode(0);
                return create_tree(root, array, 0);
            }

            private static TreeLinkNode create_tree(TreeLinkNode node, int?[] a, int index)
            {
                if (index >= a.Length)
                    return null;
                if (a[index].HasValue)
                {
                    node = new TreeLinkNode(a[index].Value);
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
            public void connect(TreeLinkNode root)
            {
                if (root==null) return;
                TreeLinkNode start = root, cur = null;
                while (start.left!=null)
                {
                    cur = start;
                    while (cur!=null)
                    {
                        cur.left.next = cur.right;
                        if (cur.next!=null) cur.right.next = cur.next.left;
                        cur = cur.next;
                    }
                    start = start.left;
                }
            }
        }
        [Test]
        public void TestSample2()
        {
            var root = TreeLinkNode.ConstructFromArray(new int?[] {1,2,3,4,5,6,7});
            new Solution().connect(root);
            Assert.AreEqual(6,root.left.right.next.val);
        }
    }
}