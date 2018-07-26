using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace LeetCodeRush.Intermediate.Design
{
    [TestFixture]
    public class 二叉树的序列化与反序列化
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

        public class Codec
        {
            // 前序中序遍历确定一颗二叉树
            public string Serialize(TreeNode root)
            {
                    if (root == null)
                        return "";
                    if (root.left == null && root.right == null)
                        return root.val + "";
                    if (root.right == null)
                        return root.val + "(" + Serialize(root.left) + ")";
                    return root.val + "(" + Serialize(root.left) + ")(" + Serialize(root.right) + ")";
            }

            // Decodes your encoded data to tree.
            public TreeNode Deserialize(string data)
            {
                if (string.IsNullOrEmpty(data)) return null;
                var leftTreeStart = data.IndexOf("(",StringComparison.CurrentCultureIgnoreCase);
                if(leftTreeStart<0) return new TreeNode(int.Parse(data));
                int pos = 1;
                int leftTreeEnd = leftTreeStart;
                var result = new TreeNode(int.Parse(data.Substring(0,leftTreeStart)));

                while (pos >0 && leftTreeEnd<data.Length)
                {
                    leftTreeEnd++;
                    if (data[leftTreeEnd] == '(')
                        pos++;
                    if (data[leftTreeEnd] == ')')
                        pos--;
                }
                result.left = Deserialize(data.Substring(leftTreeStart+1, leftTreeEnd - leftTreeStart -1));
                if (leftTreeEnd < data.Length - 1)
                {
                    result.right = Deserialize(data.Substring(leftTreeEnd+2, data.Length - leftTreeEnd -3));
                }

                //用递归的方法来实现，第一个值为根节点，第一个括号到其对应的右括号A位置中间的内容为左子节点，A位置+1到结尾为右子节点
                return result;
            }
        }
        
        [Test]
        public void TestMethods()
        {
            var root = TreeNode.ConstructFromArray(new int?[] {1, 2, 3, null, null, 4, 5});
            
            Codec codec = new Codec();
            var serlizeresult = codec.Serialize(root);
            var result = codec.Deserialize(serlizeresult);

            Assert.IsNotNull(result);
        }


        [Test]
        public void TestMethods2()
        {
            var root = TreeNode.ConstructFromArray(new int?[] {1, 10, null, 9, 11, null, 8, 12, null, 7, null, null, 13, null, 6, 14, null, 5, null, null, 15, null, 4, 16, null, 3, null, null, 17, null, 2, 18, null, 1, null, null, 19 });

            Codec codec = new Codec();
            var serlizeresult = codec.Serialize(root);
            var result = codec.Deserialize(serlizeresult);

            Assert.IsNotNull(result);
        }
    }
}