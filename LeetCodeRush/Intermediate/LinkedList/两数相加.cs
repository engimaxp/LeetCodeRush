using System;
using NUnit.Framework;

namespace LeetCodeRush.Intermediate.LinkedList
{
    [TestFixture]
    public class 两数相加
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
            public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
            {
                var result = new ListNode(0);
                var current = result;
                bool add1 = false;
                while (l1!=null && l2!=null)
                {
                    var add1int = add1 ? 1 : 0;
                    add1 = false;
                    if (l1.val + l2.val + add1int >= 10)
                    {
                        current.next = new ListNode((l1.val + l2.val + add1int) % 10);
                        add1 = true;
                    }
                    else
                    {
                        current.next = new ListNode(l1.val + l2.val + add1int);
                    }
                    current = current.next;
                    l1 = l1.next;
                    l2 = l2.next;
                }
                
                if (l1 == null)
                {
                    while (l2!=null)
                    {
                        var add1int = add1 ? 1 : 0;
                        add1 = false;
                        if ( l2.val + add1int == 10)
                        {
                            current.next = new ListNode(0);
                            add1 = true;
                        }
                        else
                        {
                            current.next = new ListNode( l2.val + add1int);
                        }
                        current = current.next;
                        l2 = l2.next;
                    }
                }
                else if (l2 == null)
                {
                    while (l1 != null)
                    {
                        var add1int = add1 ? 1 : 0;
                        add1 = false;
                        if (l1.val + add1int == 10)
                        {
                            current.next = new ListNode(0);
                            add1 = true;
                        }
                        else
                        {
                            current.next = new ListNode(l1.val + add1int);
                        }
                        current = current.next;
                        l1 = l1.next;
                    }
                }

                if (add1)
                {
                    current.next = new ListNode(1);
                }
                return result.next;
            }
        }
        [Test]
        public void TestMethod()
        {
            var l1 = ListNode.CreateListNodeFromArray(new[] {2, 4, 3});
            var l2 = ListNode.CreateListNodeFromArray(new[] { 5,6,4 });
            var result = new Solution().AddTwoNumbers(l1,l2);
            Assert.AreEqual("7->0->8",result.ToString());
        }

        [Test]
        public void TestMethod2()
        {
            var l1 = ListNode.CreateListNodeFromArray(new[] { 5});
            var l2 = ListNode.CreateListNodeFromArray(new[] { 6 ,9});
            var result = new Solution().AddTwoNumbers(l1, l2);
            Assert.AreEqual("1->0->1", result.ToString());
        }
    }
}