using System;
using NUnit.Framework;

namespace LeetCodeRush.Simple.ArrayTest
{
    [TestFixture]
    public class 加一
    {
        [TestCase(new[] { 1, 2, 3 },
            ExpectedResult = new[] { 1, 2, 4 })]
        [TestCase(new[] { 4, 3, 2, 1 },
            ExpectedResult = new[] { 4, 3, 2, 2 })]
        [TestCase(new[] { 1, 9,9,9 },
            ExpectedResult = new[] { 2,0,0,0 })]
        [TestCase(new[] { 9, 9, 9, 9 },
            ExpectedResult = new[] { 1,0, 0, 0, 0 })]
        [TestCase(new[] { 0 },
            ExpectedResult = new[] { 1 })]
        public int[] TestSample(int[] digits)
        {
            return new Solution().PlusOne(digits);
        }
        public class Solution
        {
            public int[] PlusOne(int[] digits)
            {
                int index = digits.Length - 1;
                do
                {
                    if (index < 0)
                    {
                        break;
                    }
                    if (index < digits.Length - 1)
                    {
                        digits[index + 1] = 0;
                    }
                    digits[index] = digits[index] + 1;
                } while (digits[index--] == 10);

                if (digits[0] == 10)
                {
                    digits[0] = 0;
                    var result = new int[digits.Length+1];
                    Array.Copy(digits,0,result,1,digits.Length);
                    result[0] = 1;
                    return result;
                }
                
                return digits;
            }
        }
    }
}
