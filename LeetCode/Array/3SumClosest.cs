/*
 https://leetcode.com/problems/3sum-closest/
 Given an array S of n integers, find three integers in S such that the sum is closest to a given number, target. 
 Return the sum of the three integers. You may assume that each input would have exactly one solution.

 For example, given array S = {-1 2 1 -4}, and target = 1.

 The sum that is closest to the target is 2. (-1 + 2 + 1 = 2).
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    class _3SumClosest
    {
        public int ThreeSumClosest(int[] nums, int target)
        {
            if (nums.Length < 3)
            {
                return -1;
            }

            System.Array.Sort<int>(nums);
            int bestMatch = nums[0] + nums[1] + nums[2];

            for (int i = 0; i < nums.Length - 2; i++)
            {
                int start = i + 1;
                int end = nums.Length - 1;
                while (start < end)
                {
                    int newMatch = nums[i] + nums[start] + nums[end];

                    if (newMatch == target)
                    {
                        return newMatch;
                    }
                    else if (newMatch < target)
                    {
                        start++;
                    }
                    else
                    {
                        end--;
                    }

                    if (Math.Abs(newMatch - target) < Math.Abs(bestMatch - target))
                    {
                        bestMatch = newMatch;
                    }
                }
            }

            return bestMatch;
        }
    }
}
