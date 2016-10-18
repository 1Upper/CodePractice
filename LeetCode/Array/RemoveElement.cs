/*
 Remove Element   QuestionEditorial Solution  My Submissions
Total Accepted: 151099
Total Submissions: 418789
Difficulty: Easy
Contributors: Admin
Given an array and a value, remove all instances of that value in place and return the new length.

Do not allocate extra space for another array, you must do this in place with constant memory.

The order of elements can be changed. It doesn't matter what you leave beyond the new length.

Example:
Given input array nums = [3,2,2,3], val = 3

Your function should return length = 2, with the first two elements of nums being 2.

Hint:

Try two pointers.Show More Hint 

 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Array
{
    class RemoveElement
    {
        public int GetRemoveElement(int[] nums, int val)
        {
            if (nums.Length < 1)
                return 0;

            int p1 = 0;
            int p2 = 0;

            while (p2 < nums.Length)
            {
                if (nums[p2] == val)
                {
                    p2 ++;
                }
                else if (p1 == p2)
                {
                    p2 ++;
                    p1 ++;
                }
                else
                {
                    nums[p1++] = nums[p2++];
                }
            }

            return p1;
        }
    }
}
