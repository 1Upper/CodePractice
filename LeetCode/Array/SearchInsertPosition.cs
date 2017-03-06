/*
35. Search Insert Position Add to List
Description  Submission  Solutions
Total Accepted: 151997
Total Submissions: 388022
Difficulty: Easy
Contributors: Admin
Given a sorted array and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order.

You may assume no duplicates in the array.

Here are few examples.
[1,3,5,6], 5 → 2
[1,3,5,6], 2 → 1
[1,3,5,6], 7 → 4
[1,3,5,6], 0 → 0

https://leetcode.com/problems/search-insert-position/?tab=Description
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace LeetCode.Array
{
    class SearchInsertPosition
    {
        private int SearchInsertBinary(int[] nums, int start, int end, int target)
        {
            if (start > end)
            {
                return end + 1;
            }

            int mid = (start + end)/2;

            if (target < nums[mid])
                return SearchInsertBinary(nums, start, mid - 1, target);
            else if (target > nums[mid])
                return SearchInsertBinary(nums, mid + 1, end, target);
            else
                return mid;
        }

        public int SearchInsert(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }

            return SearchInsertBinary(nums, 0, nums.Length - 1, target);
        }
    }

    [TestFixture]
    class UT_SearchInsertPosition
    {
        [Test]
        public void TestSearchInsert1()
        {
            int[] input = {1, 3, 5, 6};
            SearchInsertPosition sp = new SearchInsertPosition();
            Assert.AreEqual(2, sp.SearchInsert(input, 5));
        }
        [Test]
        public void TestSearchInsert2()
        {
            int[] input = { 1, 3, 5, 6 };
            SearchInsertPosition sp = new SearchInsertPosition();
            Assert.AreEqual(1, sp.SearchInsert(input, 2));
        }
        [Test]
        public void TestSearchInsert3()
        {
            int[] input = { 1, 3, 5, 6 };
            SearchInsertPosition sp = new SearchInsertPosition();
            Assert.AreEqual(4, sp.SearchInsert(input, 7));
        }
        [Test]
        public void TestSearchInsert4()
        {
            int[] input = { 1, 3, 5, 6 };
            SearchInsertPosition sp = new SearchInsertPosition();
            Assert.AreEqual(0, sp.SearchInsert(input, 0));
        }
    }
}
