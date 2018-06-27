using System;
using NUnit.Framework;

namespace LeetCodeRush.Simple.LinkedList
{
    [TestFixture]
    public class 环形链表
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
            public bool HasCycle(ListNode head)
            {
                if (head != null && head.next == null) return false;
                ListNode f = head;
                ListNode s = head;
                while (f != null)
                {
                    f = f.next?.next;
                    s = s.next;
                    if (f == s) return true;
                }

                return false;
            }
        }
        
    }
}