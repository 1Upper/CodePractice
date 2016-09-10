
/*
 80. Remove Duplicates from Sorted Array II  QuestionEditorial Solution  My Submissions
Total Accepted: 87484
Total Submissions: 257423
Difficulty: Medium
Follow up for "Remove Duplicates":
What if duplicates are allowed at most twice?

For example,
Given sorted array nums = [1,1,1,2,2,3],

Your function should return length = 5, with the first five elements of nums being 1, 1, 2, 2 and 3. It doesn't matter what you leave beyond the new length.

Subscribe to see which companies asked this question
https://leetcode.com/problems/remove-duplicates-from-sorted-array-ii/

 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Array
{
    class RemoveDuplicatesfromSortedArrayII
    {
        public int RemoveDuplicates(int[] nums)
        {

            int curr = 0;
            int next = 1;
            int rep = 1;
            for (; next < nums.Length; next++)
            {
                if (nums[curr] == nums[next] && rep > 0)
                {
                    curr++;
                    nums[curr] = nums[next];

                    rep--;
                }

                else if (nums[curr] != nums[next])
                {
                    curr++;
                    nums[curr] = nums[next];

                    rep = 1;
                }
            }

            return nums.Length == 0 ? 0 : curr + 1;
        }
    }
}
