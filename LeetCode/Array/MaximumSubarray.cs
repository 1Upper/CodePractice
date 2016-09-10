/*
 53. Maximum Subarray  QuestionEditorial Solution  My Submissions
Total Accepted: 132817
Total Submissions: 352491
Difficulty: Medium
Find the contiguous subarray within an array (containing at least one number) which has the largest sum.

For example, given the array [-2,1,-3,4,-1,2,1,-5,4],
the contiguous subarray [4,-1,2,1] has the largest sum = 6.
https://leetcode.com/problems/maximum-subarray/
 */
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    class MaximumSubarray
    {
        public static int MaxSubArray(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 0;
            }

            int result = nums[0];

            int pervMaxSum = nums[0];
            int pervSum = nums[0];

            int currMaxSum = 0;

            for (int i = 1; i < nums.Length; i++)
            {
                currMaxSum = Math.Max(nums[i], pervMaxSum + nums[i]);

                pervMaxSum = pervMaxSum <= 0 ? nums[i] : pervMaxSum + nums[i];

                result = Math.Max(currMaxSum, result);
            }

            return result;
        }
    }

    [TestFixture]
    class UTMaximumSubarray
    {
        [Test]
        public void TestMaximumSubarray()
        {
            int[] array = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };

            var value = MaximumSubarray.MaxSubArray(array);


            Assert.IsTrue(value == 6);  
        }
    }
}
