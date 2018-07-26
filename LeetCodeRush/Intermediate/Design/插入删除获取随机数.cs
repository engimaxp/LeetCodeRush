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
            private List<int> list { get; set; } = new List<int>();

            private Dictionary<int,int> numsMap { get; set; } = new Dictionary<int, int>();

            private Random random;
            /** Initialize your data structure here. */
            public RandomizedSet()
            {
                random = new Random();
            }

            /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
            public bool Insert(int val)
            {
                if (numsMap.ContainsKey(val)) return false;
                list.Add(val);
                numsMap[val] = list.Count-1;
                return true;
            }

            /** Removes a value from the set. Returns true if the set contained the specified element. */
            public bool Remove(int val)
            {
                if (!numsMap.ContainsKey(val)) return false;
                var last = list[list.Count - 1];
                list[list.Count - 1] = list[numsMap[val]];
                list[numsMap[val]] = last;
                numsMap[last] = numsMap[val];
                list.RemoveAt(list.Count-1);
                numsMap.Remove(val);
                return true;
            }

            /** Get a random element from the set. */
            public int GetRandom()
            {
                return list[random.Next(0, list.Count)];
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