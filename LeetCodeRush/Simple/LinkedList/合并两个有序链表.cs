using NUnit.Framework;

namespace LeetCodeRush.Simple.LinkedList
{
    [TestFixture]
    public class 合并两个有序链表
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
            public ListNode MergeTwoLists(ListNode l1, ListNode l2)
            {
                if (l1 == null)

                    return l2;

                if (l2 == null)

                    return l1;

                ListNode head, tmpa, tmpb;


                if (l1.val < l2.val)
                {
                    head = l1;

                    tmpa = l1.next;

                    tmpb = l2;
                }
                else
                {
                    head = l2;

                    tmpb = l2.next;

                    tmpa = l1;
                }


                var tmp = head;

                while (tmpa != null && tmpb != null)
                    if (tmpa.val < tmpb.val)
                    {
                        tmp.next = tmpa;

                        tmp = tmpa;

                        tmpa = tmpa.next;
                    }
                    else
                    {
                        tmp.next = tmpb;

                        tmp = tmpb;

                        tmpb = tmpb.next;
                    }


                tmp.next = tmpa ?? tmpb;

                return head;
            }
        }

        [Test]
        public void TestSample1()
        {
            var strs1 = ListNode.CreateListNodeFromArray(new[] {1, 2, 4});
            var strs2 = ListNode.CreateListNodeFromArray(new[] {1, 3, 4});
            var result = new Solution().MergeTwoLists(strs1, strs2);
            Assert.AreEqual("1->1->2->3->4->4", result.ToString());
        }

        [Test]
        public void TestSample2()
        {
            var strs1 = ListNode.CreateListNodeFromArray(new[] {1, 2, 4});
            Assert.AreEqual("1->2->4", strs1.ToString());
        }
    }
}