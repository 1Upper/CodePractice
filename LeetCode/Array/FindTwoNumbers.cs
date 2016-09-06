/*
Given an array of integers, find two numbers such that they add up to a specific target number.
The function twoSum should return indices of the two numbers such that they add up to the target, where index1 must be less than index2. Please note that your returned answers (both index1 and index2) are not zero-based.
You may assume that each input would have exactly one solution.
Input: numbers={2, 7, 11, 15}, target=9
Output: index1=1, index2=2 

From <https://oj.leetcode.com/problems/two-sum/> 
 */

using NUnit.Framework;
using System;

namespace InterviewProject
{
    /// <summary>
    /// Description of Array.
    /// </summary>
    public static class FindTwoNumbers
    {
        public static void FindTwoNumbersInTarget(int[] numbers, int target, ref int i, ref int j)
        {
            if (numbers == null ||  numbers.Length == 0)
            {
                return;
            }
            
            for (i = 0;i< numbers.Length;i++)
            {
                for (j=i;j<numbers.Length; j++)
                {
                    if (numbers[i] + numbers[j] == target)
                    {
                        i++;
                        j++;
                        return;
                    }
                }
            }
            
            i = -1;
            j = -1;
        }
    }

    [TestFixture]
    public class UTFindTwoNumbersWithValidNumbers
    {
        [Test]
        public void TestFindTwoNumbersWithValidNumbers()
        {
            int[] testArray = { -10, -9, -8, -7, -6, -5, -4, -3, -2, -1, -0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int indexA = -1;
            int indexB = -1;
            const int Target = 5;

            FindTwoNumbers.FindTwoNumbersInTarget(testArray, Target, ref indexA, ref indexB);

            Assert.IsTrue(indexA == 6, "indexA={0}", indexA);
            Assert.IsTrue(indexB == 21, "indexB={0}", indexB);
        }

        [Test]
        public void TestFindTwoNumbersWithInvalidNumbers()
        {
            int[] testArray = { -10, -9, -8, -7, -6, -5, -4, -3, -2, -1, -0 };
            int indexA = -1;
            int indexB = -1;
            const int Target = 5;

            FindTwoNumbers.FindTwoNumbersInTarget(testArray, Target, ref indexA, ref indexB);

            Assert.IsTrue(indexA == -1, "indexA={0}", indexA);
            Assert.IsTrue(indexB == -1, "indexB={0}", indexB);
        }
    }
}
