using NUnit.Framework;

namespace LeetCodeRush.Intermediate.SortSearch
{
    [TestFixture]
    public class 分类颜色
    {
        public class Solution
        {
            public void SortColors(int[] nums)
            {
                int red = 0, blue = nums.Length - 1;
                for (int i = 0; i <= blue; ++i)
                {
                    if (nums[i] == 0)
                    {
                        Swap(i,red,nums);
                        red++;
                    }
                    else if (nums[i] == 2)
                    {
                        Swap(i,blue,nums);
                        i--;
                        blue--;
                    }
                }
            }

            public void Swap(int i, int j, int[] array)
            {
                var temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }

        }

        [Test]
        public void TestMethod()
        {
            var colors = new int[] {2, 0, 2, 1, 1, 0};
            new Solution().SortColors(colors);
            Assert.IsNotNull(colors);
        }
    }
}