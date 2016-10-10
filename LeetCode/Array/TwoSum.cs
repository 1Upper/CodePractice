/*
Given an array of integers, return indices of the two numbers such that they add up to a specific target.

You may assume that each input would have exactly one solution.

Example:
Given nums = [2, 7, 11, 15], target = 9,

Because nums[0] + nums[1] = 2 + 7 = 9,
return [0, 1].

 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    class TwoSumI
    {
        public int[] TwoSum(int[] nums, int target)
        {
            SortedList<int, int> sortedList = new SortedList<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int index = sortedList.IndexOfValue(target - nums[i]);

                if (index >= 0)
                {
                    return new int[] { index, i };
                }

                sortedList[i] = nums[i];
            }

            return new int[] { };
        }
    }
}
