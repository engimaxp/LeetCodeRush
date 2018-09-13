using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace LeetCodeRush.Advance.Arrays
{
    [TestFixture]
    public class SlidingWindowMaximum
    {
        /// <summary>
        ///     给定一个数组 nums，有一个大小为 k 的滑动窗口从数组的最左侧移动到数组的最右侧。你只可以看到在滑动窗口 k 内的数字。滑动窗口每次只向右移动一位。
        ///     返回滑动窗口最大值。
        ///     示例:
        ///     输入: nums = [1,3,-1,-3,5,3,6,7], 和 k = 3
        ///     输出: [3,3,5,5,6,7]
        ///     解释:
        ///     滑动窗口的位置 最大值
        ///     ---------------               -----
        ///     [1  3  -1] -3  5  3  6  7       3
        ///     1 [3  -1  -3] 5  3  6  7       3
        ///     1  3 [-1  -3  5] 3  6  7       5
        ///     1  3  -1 [-3  5  3] 6  7       5
        ///     1  3  -1  -3 [5  3  6] 7       6
        ///     1  3  -1  -3  5 [3  6  7]      7
        ///     注意：
        ///     你可以假设 k 总是有效的，1 ≤ k ≤ 输入数组的大小，且输入数组不为空。
        ///     进阶：
        ///     你能在线性时间复杂度内解决此题吗？
        /// </summary>
        public class Solution
        {
            /// <summary>
            /// 使用双向队列来完成
            /// 队列内只包含窗口内的最大值坐标，和最大值右侧的坐标
            /// 1窗口滑动前按以上从队尾添加坐标
            /// 2窗口滑动后，每滑动一次就可以增加一个返回值
            /// 3窗口滑动后，检查每次新加进的元素和队尾元素相比，如果新元素较大，就舍掉这些队尾元素，因为只需直到最大的元素位置就可以了
            /// 4当队首元素离开窗口时，要去除，由于这样的队列其实是【坐标代表元素】从大到小排列的，所以，从队首拿出来的坐标肯定是最大值
            /// </summary>
            /// <param name="nums"></param>
            /// <param name="k"></param>
            /// <returns></returns>
            public int[] MaxSlidingWindow(int[] nums, int k)
            {
                var res = new List<int>();
                Deque<int> q = new Deque<int>();
                for (var i = 0; i < nums.Length; ++i)
                {
                    if (!q.IsEmpty() && q.GetFirst() == i - k) q.RemoveFirst();
                    while (!q.IsEmpty() && nums[q.GetLast()] < nums[i]) q.RemoveLast();
                    q.AddLast(i);
                    if (i >= k - 1) res.Add(nums[q.GetFirst()]);
                }

                return res.ToArray();
            }

            public class Deque<Item>
            {
                private Node<Item> first;
                private Node<Item> last;
                private int n;

                public Item GetLast()
                {
                    if (n == 0) return default(Item);
                    return last.item;
                }
                public Item GetFirst()
                {
                    if (n == 0) return default(Item);
                    return first.item;
                }

                public Deque() // construct an empty deque
                {
                    n = 0;
                    first = null;
                    last = null;
                }

                public bool IsEmpty() // is the deque empty?
                {
                    return first == null;
                }

                public int Size() // return the number of items on the deque
                {
                    return n;
                }

                public void AddFirst(Item item) // add the item to the front
                {
                    if (item == null) throw new NotImplementedException();

                    var oldfirst = first;
                    first = new Node<Item>
                    {
                        item = item,
                        Next = oldfirst
                    };

                    if (oldfirst == null)
                        last = first;
                    else
                        oldfirst.Prev = first;

                    n++;
                }

                public void AddLast(Item item) // add the item to the end
                {
                    if (item == null) throw new NotImplementedException();

                    var oldlast = last;
                    last = new Node<Item>
                    {
                        item = item,
                        Prev = oldlast
                    };

                    if (oldlast == null)
                        first = last;
                    else
                        oldlast.Next = last;

                    n++;
                }

                public Item RemoveFirst() // remove and return the item from the front
                {
                    if (IsEmpty()) throw new NotImplementedException();

                    Item item = first.item;
                    first = first.Next;

                    if (first == null)
                        last = null;
                    else
                        first.Prev = null;

                    n--;

                    return item;
                }

                public Item RemoveLast() // remove and return the item from the end
                {
                    if (IsEmpty()) throw new NotImplementedException();

                    Item item = last.item;
                    last = last.Prev;

                    if (last == null)
                        first = null;
                    else
                        last.Next = null;

                    n--;

                    return item;
                }
            }

            public class Node<Item>
            {
                public Item item;
                public  Node<Item> Next { get; set; }
                public  Node<Item> Prev { get; set; }
            }
            
        }

        [Test]
        public void TestMethod()
        {
            Assert.AreEqual(new[] {3, 3, 5, 5, 6, 7},
                new Solution().MaxSlidingWindow(new[] {1, 3, -1, -3, 5, 3, 6, 7}, 3));
        }
    }
}