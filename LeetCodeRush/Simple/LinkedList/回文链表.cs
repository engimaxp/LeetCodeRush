using System;
using NUnit.Framework;

namespace LeetCodeRush.Simple.LinkedList
{
    [TestFixture]
    public class 回文链表
    {
        public class ListNode
        {
            public ListNode next;
            public int val;

            public ListNode(int x)
            {
                val = x;
            }

            public override string ToString()
            {
                if (next == null) return val.ToString();
                else return val + "->" + next;
            }

            public static ListNode CreateListNodeFromArray(int[] array)
            {
                if (array.Length == 1) return new ListNode(array[0]);

                ListNode currentNode = null;
                ListNode head = null;
                for (var i = array.Length - 1; i >= 0; i--)
                {
                    head = new ListNode(array[i]);
                    if (currentNode != null) head.next = currentNode;
                    currentNode = head;
                }

                return head;
            }
        }

        public class Solution
        {
            public static ListNode ReverseList2(ListNode head)
            {
                if (head == null)
                {
                    return null;
                }

                ListNode reverseHead = null;
                // 指针1：当前节点
                ListNode currentNode = head;
                // 指针2：当前节点的前一个节点
                ListNode prevNode = null;

                while (currentNode != null)
                {
                    // 指针3：当前节点的后一个节点
                    ListNode nextNode = currentNode.next;
                    if (nextNode == null)
                    {
                        reverseHead = currentNode;
                    }
                    // 将当前节点的后一个节点指向前一个节点
                    currentNode.next = prevNode;
                    // 将前一个节点指向当前节点
                    prevNode = currentNode;
                    // 将当前节点指向后一个节点
                    currentNode = nextNode;
                }

                return reverseHead;
            }
            public bool IsPalindrome(ListNode head)
            {
                ListNode f = head;
                ListNode s = head;
                while (f != null)
                {
                    f = f.next?.next;
                    s = s.next;
                }

                var pHead = ReverseList2(s);


                while (head != pHead && pHead!=null)
                {
                    if (head == null) return false;
                    if (head.val != pHead.val)
                    {
                        return false;
                    }
                    head = head.next;
                    pHead = pHead.next;
                }
                return true;
            }
        }

        [Test]
        public void TestSample1()
        {
            var strs1 = ListNode.CreateListNodeFromArray(new[] {1, 2});
            var result = new Solution().IsPalindrome(strs1);
            Assert.AreEqual(false, result);
        }

        [Test]
        public void TestSample2()
        {
            var strs1 = ListNode.CreateListNodeFromArray(new[] {1, 2, 2,1});
            var result = new Solution().IsPalindrome(strs1);
            Assert.AreEqual(true, result);
        }
        [Test]
        public void TestSample3()
        {
            var strs1 = ListNode.CreateListNodeFromArray(new[] { 1, 2,3,4,4,3, 2, 1 });
            var result = new Solution().IsPalindrome(strs1);
            Assert.AreEqual(true, result);
        }
    }
}