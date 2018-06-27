using NUnit.Framework;

namespace LeetCodeRush.Simple.LinkedList
{
    [TestFixture]
    public class 反转链表
    {
        [Test]
        public void TestSample1()
        {
            var strs = new[] {1,2,3,4,5};
            var result = new Solution(strs);
            result.head = result.ReverseList(result.head);
            Assert.AreEqual(new[] { 5,4,3,2,1 }, result.ToArray());
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
                if (length == 1)
                {
                    head = new ListNode(array[0]);
                    return;
                }
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
            public ListNode ReverseList(ListNode head)
            {

                if (head == null || head.next == null)
                {
                    return head;
                }

                ListNode myHead = ReverseList(head.next);
                head.next.next = head;
                head.next = null;
                return myHead;
            }
        }

        public class Solution2
        {
            public Solution2()
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
            public Solution2(int[] array)
            {
                ListNode currentNode = null;
                length = array.Length;
                if (length == 1)
                {
                    head = new ListNode(array[0]);
                    return;
                }
                for (int i = array.Length - 1; i >= 0; i--)
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
            public ListNode ReverseList(ListNode head)
            {
                if (head == null || head.next == null)
                {
                    return head;
                }

                ListNode myHead = null;
                var cur = head;
                while (cur != null)
                {
                    var temp = myHead;
                    myHead = new ListNode(cur.val) { next = temp };
                    cur = cur.next;
                }

                return myHead;
            }
        }
    }
}