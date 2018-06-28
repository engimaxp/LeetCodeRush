using System;
using NUnit.Framework;

namespace LeetCodeRush.Simple.Tree
{
    [TestFixture]
    public class 验证二叉搜索树
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
            //Moris 中序遍历，若为有序则正确
            public bool IsValidBST(TreeNode root)
            {
                if (root==null) return true;
                TreeNode cur = root;
                TreeNode parent = null;
                while (cur!=null)
                {
                    if (cur.left == null)
                    {
                        if (parent!=null && parent.val >= cur.val) return false;
                        parent = cur;
                        cur = cur.right;
                    }
                    else
                    {
                        var pre = cur.left;
                        while (pre.right!=null && pre.right != cur) pre = pre.right;
                        if (pre.right == null)
                        {
                            pre.right = cur;
                            cur = cur.left;
                        }
                        else
                        {
                            pre.right = null;
                            if (parent.val >= cur.val) return false;
                            parent = cur;
                            cur = cur.right;
                        }
                    }
                }
                return true;
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
            var root = TreeNode.ConstructFromArray(new int?[] { 2,1,3 });
            Assert.AreEqual(true, new Solution().IsValidBST(root));
        }
        [Test]
        public void TestSample3()
        {
            var root = TreeNode.ConstructFromArray(new int?[] {5,1,4,null,null,3,6 });
            Assert.AreEqual(false, new Solution().IsValidBST(root));
        }
        [Test]
        public void TestSample4()
        {
            var root = TreeNode.ConstructFromArray(new int?[] {10, 5, 15, null, null, 6, 20 });
            Assert.AreEqual(false, new Solution().IsValidBST(root));
        }
    }
}