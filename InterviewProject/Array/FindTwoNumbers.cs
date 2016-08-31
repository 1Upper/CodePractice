/*
Given an array of integers, find two numbers such that they add up to a specific target number.
The function twoSum should return indices of the two numbers such that they add up to the target, where index1 must be less than index2. Please note that your returned answers (both index1 and index2) are not zero-based.
You may assume that each input would have exactly one solution.
Input: numbers={2, 7, 11, 15}, target=9
Output: index1=1, index2=2 

From <https://oj.leetcode.com/problems/two-sum/> 
 */
 
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
}
