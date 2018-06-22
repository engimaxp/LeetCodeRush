using NUnit.Framework;

namespace LeetCodeRush
{
    [TestFixture]
    public class 旋转数组
    {
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7 },3, ExpectedResult = new []{ 5, 6, 7, 1, 2, 3, 4 })]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7 }, 10, ExpectedResult = new[] { 5, 6, 7, 1, 2, 3, 4 })]
        [TestCase(new[] { -1, -100, 3, 99 }, 2, ExpectedResult = new []{ 3, 99, -1, -100 })]
        [TestCase(new[] { 1,1,2,2,3,3 }, 1, ExpectedResult = new int[]{ 3, 1,1,2, 2, 3})]
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 0, ExpectedResult = new int[]{ 1, 2, 3, 4, 5 })]
        [TestCase(new int[0], 1, ExpectedResult = new int[0])]
        [TestCase((int[])null, 1, ExpectedResult = (int[])null)]
        public int[] TestSample(int[] nums, int k)
        {
            new Solution().Rotate(nums,k);
            return nums;
        }
        public class Solution
        {
            public void Rotate(int[] nums, int k)
            {
                if (nums == null || nums.Length <= 1) return;
                if (k > nums.Length)
                {
                    k = k % nums.Length;
                }
                if (k <= 0) return;
                
                reverse(nums.Length - k, nums.Length - 1, nums);

                reverse(0, nums.Length - k - 1, nums);

                reverse(0, nums.Length - 1, nums);

            }

            public void reverse(int i, int j, int[] array)
            {
                while (i < j)
                {
                    swap(i, j, array);
                    i++;
                    j--;
                }
            }

            public void swap(int i, int j, int[] array)
            {
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }

    }
}
