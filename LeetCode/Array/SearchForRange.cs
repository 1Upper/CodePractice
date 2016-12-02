/*
 34. Search for a Range   
Given a sorted array of integers, find the starting and ending position of a given target value.

Your algorithm's runtime complexity must be in the order of O(log n).

If the target is not found in the array, return [-1, -1].

For example,
Given [5, 7, 7, 8, 8, 10] and target value 8,
return [3, 4].

解题思路: 典型的折半查找算法， 先找到第一个，然后再两边的子串中查找，知道找不到为止。所以算法复杂度是log(n)
小心各种边界条件。。。
*/

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    class SearchForRange
    {
        int FindInArray(int[] array, int start, int end, int target, bool findLeft)
        {
            if (start > end)
            {
                return -1;
            }

            int index = (start + end) / 2;

            if (array[index] == target)
            {
                if (findLeft)
                    if (index == start) return index;
                    else return array[index - 1] == target ? FindInArray(array, start, end - 1, target, findLeft) : index;
                else
                    if (index == end) return index;
                    else return array[index + 1] == target ? FindInArray(array, index + 1, end, target, findLeft) : index;
            }
            else if (array[index] > target)
            {
                return FindInArray(array, start, index - 1, target, findLeft);
            }
            else
            {
                return FindInArray(array, index + 1, end, target, findLeft);
            }
        }


        public int[] SearchRange(int[] nums, int target)
        {
            int left = FindInArray(nums, 0, nums.Length - 1, target, true);
            int right = FindInArray(nums, Math.Max(0,left), nums.Length - 1, target, false);

            return new int[] { left, right};
        }
    }

    [TestFixture]
    public class UTSearchForRange
    {
        [Test]
        public void TestSearchForRange1()
        {
            int[] input = new int[] {1,2,3,4,8,8,8,9};
            SearchForRange rangeFinder = new SearchForRange();

            var results = rangeFinder.SearchRange(input, 8);

            Assert.AreEqual(4, results[0]);
            Assert.AreEqual(6, results[1]);
        }

        [Test]
        public void TestSearchForRange2()
        {
            int[] input = new int[] { 1, 2, 3, 4, 7, 9 };
            SearchForRange rangeFinder = new SearchForRange();

            var results = rangeFinder.SearchRange(input, 8);

            Assert.AreEqual(-1, results[0]);
            Assert.AreEqual(-1, results[1]);
        }

        [Test]
        public void TestSearchForRange3()
        {
            int[] input = new int[] { 1 };
            SearchForRange rangeFinder = new SearchForRange();

            var results = rangeFinder.SearchRange(input, 8);

            Assert.AreEqual(-1, results[0]);
            Assert.AreEqual(-1, results[1]);
        }

        [Test]
        public void TestSearchForRange4()
        {
            int[] input = new int[] { };
            SearchForRange rangeFinder = new SearchForRange();

            var results = rangeFinder.SearchRange(input, 8);

            Assert.AreEqual(-1, results[0]);
            Assert.AreEqual(-1, results[1]);
        }


        [Test]
        public void TestSearchForRange5()
        {
            int[] input = new int[] { 1 };
            SearchForRange rangeFinder = new SearchForRange();

            var results = rangeFinder.SearchRange(input, 1);

            Assert.AreEqual(0, results[0]);
            Assert.AreEqual(0, results[1]);
        }

        [Test]
        public void TestSearchForRange6()
        {
            int[] input = new int[] { 1, 4 };
            SearchForRange rangeFinder = new SearchForRange();

            var results = rangeFinder.SearchRange(input, 4);

            Assert.AreEqual(1, results[0]);
            Assert.AreEqual(1, results[1]);
        }

        [Test]
        public void TestSearchForRange7()
        {
            int[] input = new int[] { 4, 4 };
            SearchForRange rangeFinder = new SearchForRange();

            var results = rangeFinder.SearchRange(input, 4);

            Assert.AreEqual(0, results[0]);
            Assert.AreEqual(1, results[1]);
        }
    }
}
