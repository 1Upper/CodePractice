/*
 Given a sorted array, remove the duplicates in place such that each element appear only once and return the new length.
Do not allocate extra space for another array, you must do this in place with constant memory. 
For example,
Given input array nums = [1,1,2], 
Your function should return length = 2, with the first two elements of nums being 1 and 2 respectively. It doesn't matter what you leave beyond the new length. 

From <https://leetcode.com/problems/remove-duplicates-from-sorted-array/> 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    class RemoveDuplicatesfromSortedArray
    {
        public int RemoveDuplicates(int[] nums)
        {

            int curr = 0;
            int next = 1;
            for (; next < nums.Length; next++)
            {
                if (nums[curr] != nums[next])
                {
                    curr++;
                    nums[curr] = nums[next];
                }
            }

            return nums.Length == 0 ? 0 : curr + 1;
        }
    }
}
