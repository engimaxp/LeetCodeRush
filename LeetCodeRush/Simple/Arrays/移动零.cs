using NUnit.Framework;

namespace LeetCodeRush.Simple.ArrayTest
{
    [TestFixture]
    public class 移动零
    {
        [TestCase(new[] {0, 1, 0, 3, 12},
            ExpectedResult = new[] {1, 3, 12, 0, 0})]
        [TestCase(new[] {1, 2, 3, 4},
            ExpectedResult = new[] {1, 2, 3, 4})]
        [TestCase((int[]) null,
            ExpectedResult = null)]
        [TestCase(new int[0],
            ExpectedResult = new int[0])]
        [TestCase(new[] {1, 2, 3, 4, 0},
            ExpectedResult = new[] {1, 2, 3, 4, 0})]
        [TestCase(new[] {0, 0, 0, 0, 0},
            ExpectedResult = new[] {0, 0, 0, 0, 0})]
        public int[] TestSample(int[] nums)
        {
            new Solution().MoveZeroes(nums);
            return nums;
        }
        
        public class Solution
        {
            public void Swap(int i, int j, int[] array)
            {
                var temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }

            public void MoveZeroes(int[] nums)
            {
                if (nums == null || nums.Length == 0) return;
                var left = 0;
                var right = 0;
                while (left <= nums.Length - 1 && nums[left] != 0) left++;

                right = left + 1;
                while (right <= nums.Length - 1)
                {
                    if (nums[right] != 0)
                    {
                        Swap(left, right, nums);
                        left++;
                    }
                    right++;
                }
                
            }
        }
    }
}