using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace LeetCodeRush.Intermediate.Design
{
    [TestFixture]
    public class 插入删除获取随机数
    {

        public class RandomizedSet
        {
            private List<int> List { get; set; } = new List<int>();

            private Dictionary<int,int> NumsMap { get; set; } = new Dictionary<int, int>();

            private readonly Random random;
            /** Initialize your data structure here. */
            public RandomizedSet()
            {
                random = new Random();
            }

            /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
            public bool Insert(int val)
            {
                if (NumsMap.ContainsKey(val)) return false;
                List.Add(val);
                NumsMap[val] = List.Count-1;
                return true;
            }

            /** Removes a value from the set. Returns true if the set contained the specified element. */
            public bool Remove(int val)
            {
                if (!NumsMap.ContainsKey(val)) return false;
                var last = List[List.Count - 1];
                List[List.Count - 1] = List[NumsMap[val]];
                List[NumsMap[val]] = last;
                NumsMap[last] = NumsMap[val];
                List.RemoveAt(List.Count-1);
                NumsMap.Remove(val);
                return true;
            }

            /** Get a random element from the set. */
            public int GetRandom()
            {
                return List[random.Next(0, List.Count)];
            }
        }

        /**
         * Your RandomizedSet object will be instantiated and called as such:
         * RandomizedSet obj = new RandomizedSet();
         * bool param_1 = obj.Insert(val);
         * bool param_2 = obj.Remove(val);
         * int param_3 = obj.GetRandom();
         */
        [Test]
        public void TestMethod()
        {
            RandomizedSet obj = new RandomizedSet();
            Assert.IsTrue(obj.Insert(1));
            Assert.IsTrue(obj.Insert(2));

            Assert.IsFalse(obj.Insert(2));

            Assert.IsTrue(obj.Remove(1));
            Assert.IsFalse(obj.Remove(3));

            Assert.IsTrue(obj.Insert(1));
            Assert.IsTrue(obj.Insert(3));
            Assert.IsTrue(obj.Insert(4));
            Assert.IsTrue(obj.Insert(5));
            Assert.IsTrue(obj.Insert(6));

            int[] data = new int[6];
            for (int i = 0; i < 3000; i++)
            {
                data[obj.GetRandom() - 1]++;
            }
            Assert.IsNotNull(data);
        }
    }
}