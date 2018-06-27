using System;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace LeetCodeRush.Simple.LinkedList
{
    [TestFixture]
    public class 删除链表中的节点
    {
        [Test]
        public void TestSample()
        {
            var strs = new[] { 4, 5, 1, 9 };
            var result = new Solution(strs);
            Assert.AreEqual(new[] { 4, 5, 1, 9 }, result.ToArray());
        }
        [Test]
        public void TestSample1()
        {
            var strs = new[] {4, 5, 1, 9};
            var result = new Solution(strs);
            result.DeleteNode(result.getNum(5));
            Assert.AreEqual(new[] { 4, 1, 9 }, result.ToArray());
        }
        [Test]
        public void TestSample2()
        {
            var strs = new[] { 4, 5, 1, 9 };
            var result = new Solution(strs);
            result.DeleteNode(result.getNum(1));
            Assert.AreEqual(new[] { 4, 5, 9 }, result.ToArray());
        }
        /**
 * Definition for singly-linked list.
 */
  public class ListNode {
      public int val;
      public ListNode next;
      public ListNode(int x) { val = x; }
  }
        public class Solution
        {
            public Solution()
            {
                
            }

            public ListNode getNum(int n)
            {
                ListNode currentNode = head;
                for (int i = 0; i < length; i++)
                {
                    if (currentNode.val == n) return currentNode;
                    currentNode = currentNode.next;
                }

                return null;
            }
            public ListNode head { get; set; }
            private int length = 0;
            public Solution(int[] array)
            {
                ListNode currentNode = null;
                length = array.Length;
                for (int i = array.Length-1; i >=0; i--)
                {
                    head = new ListNode(array[i]);
                    if (currentNode != null)
                    {
                        head.next = currentNode;
                    }
                    currentNode = head;
                }
            }

            public int[] ToArray()
            {
                var array = new int[length];

                ListNode currentNode = head;
                for (int i = 0; i < length; i++)
                {
                    array[i] = currentNode.val;
                    currentNode = currentNode.next;
                }

                return array;
            }

            public void DeleteNode(ListNode node)
            {
                node.val = node.next.val;
                node.next = node.next.next;

                length = length - 1;
            }
        }
    }
}