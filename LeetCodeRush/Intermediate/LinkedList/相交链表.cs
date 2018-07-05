using System;
using NUnit.Framework;

namespace LeetCodeRush.Intermediate.LinkedList
{
    [TestFixture]
    public class 相交链表
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
            public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
            {
                ListNode p1 = headA;
                ListNode p2 = headB;
                int length1 = 0;
                int length2 = 0;
                while (p1!=null)
                {
                    p1 = p1.next;
                    length1++;
                }
                while (p2 != null)
                {
                    p2 = p2.next;
                    length2++;
                }

                if (length1 > length2)
                {
                    p1 = headA;
                    p2 = headB;
                }
                else
                {
                    p1 = headB;
                    p2 = headA;
                }

                int diff = Math.Abs(length1 - length2);
                for (int i = 0; i < diff; i++)
                {
                    p1 = p1.next;
                }

                while (p1!=null)
                {
                    if (p1 == p2) return p1;
                    p1 = p1.next;
                    p2 = p2.next;
                }

                return null;
            }
        }
        [Test]
        public void TestMethod()
        {
            var l1 = ListNode.CreateListNodeFromArray(new[] {1,2,3,4,5});
            var l2 = ListNode.CreateListNodeFromArray(new[] { 1, 2, 3, 4, 5,6 });
            var result = new Solution().GetIntersectionNode(l1,l2);
            Assert.AreEqual("1->3->5->2->4", result.ToString());
        }

        [Test]
        public void TestMethod2()
        {
            var l1 = ListNode.CreateListNodeFromArray(new[] { 2,1,3,5,6,4,7});
            var l2 = ListNode.CreateListNodeFromArray(new[] { 1, 2, 3, 4, 5 });
            var result = new Solution().GetIntersectionNode(l1, l2);
            Assert.AreEqual("2->3->6->7->1->5->4", result.ToString());
        }
    }
}