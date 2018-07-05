using System;
using NUnit.Framework;

namespace LeetCodeRush.Intermediate.LinkedList
{
    [TestFixture]
    public class 奇偶链表
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
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
            public ListNode OddEvenList(ListNode head)
            {
                if (head == null) return null;
                ListNode odd = head, even = head.next, evenHead = even;
                while (even != null && even.next != null)
                {
                    odd.next = even.next;
                    odd = odd.next;
                    even.next = odd.next;
                    even = even.next;
                }
                odd.next = evenHead;
                return head;
            }
        }
        [Test]
        public void TestMethod()
        {
            var l1 = ListNode.CreateListNodeFromArray(new[] {1,2,3,4,5});
            var result = new Solution().OddEvenList(l1);
            Assert.AreEqual("1->3->5->2->4", result.ToString());
        }

        [Test]
        public void TestMethod2()
        {
            var l1 = ListNode.CreateListNodeFromArray(new[] { 2,1,3,5,6,4,7});
            var result = new Solution().OddEvenList(l1);
            Assert.AreEqual("2->3->6->7->1->5->4", result.ToString());
        }
    }
}