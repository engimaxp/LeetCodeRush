using NUnit.Framework;

namespace LeetCodeRush.Simple.Tree
{
    [TestFixture]
    public class 对称二叉树
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

            public bool IsSymmetric(TreeNode root)
            {
                return isSymmetrical(root, root);
            }
            private bool isSymmetrical(TreeNode left, TreeNode right)
            {
                if (left == null && right == null)
                {
                    return true;
                }
                if (left == null || right == null)
                {
                    return false;
                }
                if (left.val != right.val)
                {
                    return false;
                }
                return isSymmetrical(left.left, right.right) && isSymmetrical(left.right, right.left);
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
            var root = TreeNode.ConstructFromArray(new int?[] { 1, 2, 2, 3, 4, 4, 3 });
            Assert.AreEqual(true, new Solution().IsSymmetric(root));
        }
        [Test]
        public void TestSample3()
        {
            var root = TreeNode.ConstructFromArray(new int?[] { 1, 2, 2, null, 3, null, 3 });
            Assert.AreEqual(false, new Solution().IsSymmetric(root));
        }
    }
}