using NUnit.Framework;

namespace LeetCodeRush.Simple.LinkedList
{
    [TestFixture]
    public class 删除链表的倒数第N个节点
    {
        [Test]
        public void TestSample1()
        {
            var strs = new[] {1,2,3,4,5};
            var result = new Solution(strs);
            result.Head = result.RemoveNthFromEnd(result.Head,2);
            Assert.AreEqual(new[] { 1,2,3,5 }, result.ToArray());
        }
        [Test]
        public void TestSample2()
        {
            var strs = new[] { 1 };
            var result = new Solution(strs);
            result.Head = result.RemoveNthFromEnd(result.Head,1);
            Assert.AreEqual(new int[0], result.ToArray());
        }
        [Test]
        public void TestSample3()
        {
            var strs = new[] { 1,2 };
            var result = new Solution(strs);
            result.Head = result.RemoveNthFromEnd(result.Head, 1);
            Assert.AreEqual(new[] { 1 }, result.ToArray());
        }
        public class ListNode {
      public int val;
      public ListNode next;
      public ListNode(int x) { val = x; }

            public override string ToString()
            {
                string result = this.val.ToString();
                ListNode cur = this;
                while (cur.next != null)
                {
                    result += " -> " + cur.next.val;
                }

                return result;
            }
        }
        public class Solution
        {
            public Solution()
            {
                
            }

            public ListNode GetNum(int n)
            {
                ListNode currentNode = Head;
                for (int i = 0; i < length; i++)
                {
                    if (currentNode.val == n) return currentNode;
                    currentNode = currentNode.next;
                }

                return null;
            }
            public ListNode Head { get; set; }
            private int length = 0;
            public Solution(int[] array)
            {
                ListNode currentNode = null;
                length = array.Length;
                if (length == 1)
                {
                    Head = new ListNode(array[0]);
                    return;
                }
                for (int i = array.Length-1; i >=0; i--)
                {
                    Head = new ListNode(array[i]);
                    if (currentNode != null)
                    {
                        Head.next = currentNode;
                    }
                    currentNode = Head;
                }
            }


            public int[] ToArray()
            {
                var array = new int[length];

                ListNode currentNode = Head;
                for (int i = 0; i < length; i++)
                {
                    array[i] = currentNode.val;
                    currentNode = currentNode.next;
                }

                return array;
            }
            public ListNode RemoveNthFromEnd(ListNode head, int n)
            {
                length--;
                if (head == null)
                {
                    return head;
                }
                ListNode myHead = new ListNode(0)
                {
                    next = head
                };

                ListNode f = myHead;
                ListNode s = myHead;
                for (int i = 0; i < n; i++)
                {
                    f = f.next;
                }

                while (f.next!=null)
                {
                    f = f.next;
                    s = s.next;
                }

                f = s.next;
                s.next = s.next.next;
                f = null;
                return myHead.next;
            }
        }
        
    }
}