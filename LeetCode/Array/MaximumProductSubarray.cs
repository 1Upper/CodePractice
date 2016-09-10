/*
 152. Maximum Product Subarray  QuestionEditorial Solution  My Submissions
Total Accepted: 70940
Total Submissions: 302879
Difficulty: Medium
Find the contiguous subarray within an array (containing at least one number) which has the largest product.

For example, given the array [2,3,-2,4],
the contiguous subarray [2,3] has the largest product = 6.
https://leetcode.com/problems/maximum-product-subarray/
 */
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    public class MaximumProductSubarray
    {
        public static int Max(int a1, int a2, int a3)
        {
            return Math.Max(a1, Math.Max(a2, a3));
        }

        public static int Min(int a1, int a2, int a3)
        {
            return Math.Min(a1, Math.Min(a2, a3));
        }

        public static int MaxProduct(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 0;
            }

            int result = nums[0];

            // Maximum product for the subarray A[0,...,i - 1] which uses A[i - 1].
            int prevMaxProduct = nums[0];

            // Minimum product for the subarray A[0,...,i - 1] which uses A[i - 1]. 
            // Note that the minimum product is needed because of negative numbers.
            int prevMinProduct = nums[0];

            int currMaxProduct = 0;
            int currMinProduct = 0;

            for (int i = 1; i < nums.Length; i++)
            {
                // The max product comes with 3 possibilities
                // 1: the product of [0....i], there might be negative numbers among of those numbers.
                // 2: the product of [0....x], x < i. 
                // 3: the product of [x....i], 
                // the min product might become max product.

                currMaxProduct = Max(nums[i], prevMaxProduct * nums[i], prevMinProduct * nums[i]);

                currMinProduct = Min(nums[i], prevMinProduct * nums[i], prevMaxProduct * nums[i]);

                result = Math.Max(currMaxProduct, result);

                prevMaxProduct = currMaxProduct;
                prevMinProduct = currMinProduct;
            }

            return result;
        }

    }

    [TestFixture]
    public class UTMaximumProductSubarray
    {
        [Test]
        public void TestMaximuProductSubarray()
        {
            int[] nums = { 2, 3, -2, 4 };

            int result = MaximumProductSubarray.MaxProduct(nums);


            Assert.IsTrue(result == 6);
        }

        [Test]
        public void TestMaximuProductSubarray1()
        {
            int[] nums = { 2, 3, -2, -4 };

            int result = MaximumProductSubarray.MaxProduct(nums);


            Assert.IsTrue(result == 48);
        }
    }
}
