/*
 238. Product of Array Except Self  QuestionEditorial Solution  My Submissions
Total Accepted: 61017
Total Submissions: 135166
Difficulty: Medium
Given an array of n integers where n > 1, nums, return an array output such that output[i] is equal to the product of all the elements of nums except nums[i].

Solve it without division and in O(n).

For example, given [1,2,3,4], return [24,12,8,6].

Follow up:
Could you solve it with constant space complexity? (Note: The output array does not count as extra space for the purpose of space complexity analysis.)
https://leetcode.com/problems/product-of-array-except-self/
 */
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    class ProductofArrayExceptSelf
    {
        public static int[] ProductExceptSelf(int[] nums)
        {
            int[] result = new int[nums.Length];
            result[nums.Length - 1] = 1;

            for (int i = nums.Length -2 ; i >= 0 ; i--)
            {
                result[i] = nums[i + 1] * result[i + 1];
            }

            int left = nums[0];
            for (int i = 1; i <= nums.Length -1; i++)
            {
                result[i] = left * result[i];
                left = left * nums[i];
            }

            return result;
        }
    }

    [TestFixture]
    public class UTProductofArrayExceptSelf
    {
        [Test]
        public void TestProductOfArrayExceptSelf1()
        {
            int[] input = new int[] { 1, 2, 3, 4 };

            var result = ProductofArrayExceptSelf.ProductExceptSelf(input);

            Assert.IsTrue(result[0] == 24);
            Assert.IsTrue(result[1] == 12);
            Assert.IsTrue(result[2] == 8);
            Assert.IsTrue(result[3] == 6);
        }
    }

}
