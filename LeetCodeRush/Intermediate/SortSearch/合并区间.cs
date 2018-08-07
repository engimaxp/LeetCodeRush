using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace LeetCodeRush.Intermediate.SortSearch
{
    [TestFixture]
    public class 合并区间
    {
        /**
 * Definition for an interval.
         **/
        public class Interval
        {
            public int end;
            public int start;

            public Interval()
            {
                start = 0;
                end = 0;
            }

            public Interval(int s, int e)
            {
                start = s;
                end = e;
            }

            public override string ToString()
            {
                return $"{nameof(end)}: {end}, {nameof(start)}: {start}";
            }
        }

        public class Solution
        {
            public IList<Interval> Merge(IList<Interval> intervals)
            {
                if(intervals == null || intervals.Count == 0) return new List<Interval>();
                List<Interval> result = new List<Interval>();
                var length = intervals.Count;
                int[] starts = new int[length];
                int[] ends = new int[length];
                for (int i = 0; i < length; i++)
                {
                    starts[i] = intervals[i].start;
                    ends[i] = intervals[i].end;
                }
                Array.Sort(starts);
                Array.Sort(ends);
                for (int i = 0,j = 0; i < length; i++)
                {
                    if (length - 1 == i || starts[i + 1] > ends[i])
                    {
                        result.Add(new Interval(starts[j],ends[i]));
                        j = i + 1;
                    }
                }

                return result;
            }
        }

        [Test]
        public void TestMethod1()
        {
            var result = new Solution().Merge(new List<Interval>()
            {
                new Interval(1, 3),
                new Interval(2, 6),
                new Interval(8, 10),
                new Interval(15, 18),
            });
            Assert.IsNotNull(result);//[[1,6],[8,10],[15,18]]
        }
        [Test]
        public void TestMethod2()
        {
            var result = new Solution().Merge(new List<Interval>()
            {
                new Interval(1, 4),
                new Interval(4,5),
            });
            Assert.IsNotNull(result);//[[1,5]]
        }
    }
}