/*

167. Two Sum II - Input array is sorted

Given an array of integers that is already sorted in ascending order, find two numbers such that they add up
to a specific target number.

The function twoSum should return indices of the two numbers such that they add up to the target, where index1
 must be less than index2. Please note that your returned answers (both index1 and index2) are not zero-based.

You may assume that each input would have exactly one solution.

Input: numbers={2, 7, 11, 15}, target=9
Output: index1=1, index2=2

 */

using System;
using NUnit.Framework;

namespace LeetCode
{
    public class TwoSumII
    {
        public static int[] TwoSum(int[] numbers, int target) 
        {
            if (numbers == null || numbers.Length == 0)
                return null;
            
            int i = 0; 
            int j = numbers.Length -1;
            while (i< j)
            {
                if ((numbers[i] + numbers[j]) < target)
                {
                    ++i;
                }
                else if (numbers[i] + numbers[j] > target)
                {
                    --j;
                }
                else{
                    return new int[]{i+1, j+1};
                }
            }
            
            return null;
        }
    }
    
    [TestFixture]
    public class UTTwoSumII
    {
        [Test]
        public void TestMethod()
        {
            int[] input = {2, 7, 11, 15};
            var result = TwoSumII.TwoSum(input, 9);
            // TODO: Add your test.
            
            Assert.IsTrue(result[0] == 1);
            Assert.IsTrue(result[1] == 2);
        }
    }
}
