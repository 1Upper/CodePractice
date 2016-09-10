/*
Find the kth largest element in an unsorted array. Note that it is the kth 
largest element in the sorted order, not the kth distinct element.

For example,
Given [3,2,1,5,6,4] and k = 2, return 5.

Note: 
You may assume k is always valid, 1 ≤ k ≤ array's length.

https://leetcode.com/problems/kth-largest-element-in-an-array/
 */
using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace LeetCode
{
    public class KthLargestElementInAnArray
    {
        public static int FindKthLargest(int[] nums, int k) 
        {
            List<int> list = new List<int>(nums);
            list.Sort();
            return list[nums.Length - k];
        }
    }
    
    [TestFixture]
    public class UTKthLargestElementInAnArray
    {
        [Test]
        public void TestMethod()
        {
            int[] input = {3,2,1,5,6,4};
            var n = KthLargestElementInAnArray.FindKthLargest(input, 2);
            Assert.IsTrue(n == 5);
        }
    }
}
