using System;
using System.Text;
using NUnit.Framework;

namespace LeetCodeRush.Simple.Design
{
    [TestFixture]
    public class Shuffle_an_Array
    {
        public class Solution
        {
            private readonly int[] original = null;
            public Solution(int[] nums)
            {
                original = nums;
            }

            /** Resets the array to its original configuration and return it. */
            public int[] Reset()
            {
                if (original == null) return null;
                var reset = new int[original.Length];
                Array.Copy(original, reset,original.Length);
                return reset;
            }

            Random random = new Random();
            /** Returns a random shuffling of the array. */
            public int[] Shuffle()
            {
                if (original == null) return null;
                var shuffle = new int[original.Length];
                Array.Copy(original, shuffle, original.Length);

                for (int i = 0; i < shuffle.Length; i++)
                {
                    int j = random.Next(i, shuffle.Length); 
                    var temp = shuffle[i];
                    shuffle[i] = shuffle[j];
                    shuffle[j] = temp;
                }

                return shuffle;
            }
        }

        /**
         * Your Solution object will be instantiated and called as such:
         * Solution obj = new Solution(nums);
         * int[] param_1 = obj.Reset();
         * int[] param_2 = obj.Shuffle();
         */

        [Test]
        public void TestSample1()
        {
            var array = new int[] {1, 2, 3};
            var solution = new Solution(array);
            Assert.AreEqual(array,solution.Reset());
        }
        [Test]
        public void TestSample2()
        {
            var array = new int[] { 1, 2, 3 };
            var solution = new Solution(array);
            Assert.AreEqual(array, solution.Reset());
            Assert.AreNotEqual(array, solution.Shuffle());
            Assert.AreEqual(array, solution.Reset());
        }

        public string IntarrayToString(int[] array)
        {
            StringBuilder s = new StringBuilder();
            for (int i = 0; i < array.Length; i++)
            {
                s.Append(array[i]);
            }

            return s.ToString();
        }
        [Test]
        public void TestSample3()
        {
            var array = new int[] { 1, 2, 3 };
            var dic = new string[]
            {"123","132","213","231","321","312"
            };
            var p = new int[6];
            var solution = new Solution(array);
            for (int j = 0; j < 1000; j++)
            {
                var shuffle = solution.Shuffle();
                for (int i = 0; i < dic.Length; i++)
                {
                    if (dic[i].Equals(IntarrayToString(shuffle))) p[i]++;
                }
            }
            Assert.IsNotNull(p);
        }
    }
}