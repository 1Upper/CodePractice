/*
Suppose a sorted array is rotated at some pivot unknown to you beforehand.
(i.e., 0 1 2 4 5 6 7 might become 4 5 6 7 0 1 2).
You are given a target value to search. If found in the array return its index, otherwise return -1.
You may assume no duplicate exists in the array.

From <https://leetcode.com/problems/search-in-rotated-sorted-array/> 
 */

using NUnit.Framework;
using System;

namespace LeetCode
{
    /// <summary>
    /// Description of Class1.
    /// </summary>
    public static class SearchinRotatedSortedArray
    {
        public static int Search(int[] nums, int target) 
        {
            int start = 0;
            int end = nums.Length-1;
            int mid = (start + end) /2;
            
            while (mid != start && mid != end) 
            {
                if (nums[mid] == target)
                {
                    return mid;
                }
                else if (nums[mid] < target)
                {
                    if (nums[mid] > nums[start])
                    {
                        start = mid;
                    }
                    else
                    {
                        if (nums[end] >= target)
                        {
                            start = mid;
                        }
                        else
                        {
                            end = mid;
                        }
                    }
                }
                else if (nums[mid] > target)
                {
                    if (nums[mid] < nums[end])
                    {
                        end = mid;
                    }
                    else
                    {
                        if (nums[start] > target)
                        {
                            start = mid;
                        }
                        else
                        {
                            end = mid;
                        }
                    }
                }
                
                mid = (start + end) /2;
            }
            
            if (nums[start] == target)
                return start;
            else if (nums[end] == target)
                return end;
            else
                return -1;
        }
    }

    [TestFixture]
    public class UTSearchinRotatedSortedArray
    {
        [Test]
        public void TestSigleElementArrayNoTarget()
        {
            int[] test = { 1 };
            const int target = 0;

            var result = SearchinRotatedSortedArray.Search(test, target);

            Assert.IsTrue(result == -1);
        }

        [Test]
        public void TestTwoElementsArrayWithTarget()
        {
            int[] test2 = { 1, 3 };
            const int target = 3;
            var result = SearchinRotatedSortedArray.Search(test2, target);

            Assert.IsTrue(result == 1);
        }

        [Test]
        public void TestThreeElementsArrayWithTarget()
        {
            int[] test2 = { 1, 3, 5 };
            const int target = 5;
            var result = SearchinRotatedSortedArray.Search(test2, target);

            Assert.IsTrue(result == 2);
        }

        [Test]
        public void TestSigleElementArrayNoTarget2()
        {
            int[] test = { 1 };
            const int target = 2;

            var result = SearchinRotatedSortedArray.Search(test, target);

            Assert.IsTrue(result == -1);
        }

        [Test]
        public void TestTwoElementsArrayNoTarget()
        {
            int[] test2 = { 1, 3 };
            const int target = 0;
            var result = SearchinRotatedSortedArray.Search(test2, target);

            Assert.IsTrue(result == -1);
        }

        [Test]
        public void TestSevenElementsArrayWithTarget()
        {
            int[] test2 = { 4, 5, 6, 7, 0, 1, 2 };
            const int target = 0;
            var result = SearchinRotatedSortedArray.Search(test2, target);

            Assert.IsTrue(result == 4);
        }

        [Test]
        public void TestEightElementsArrayWithTarget()
        {
            int[] test2 = { 4, 5, 6, 7, 8, 1, 2, 3 };
            const int target = 8;
            var result = SearchinRotatedSortedArray.Search(test2, target);

            Assert.IsTrue(result == 4);
        }

        [Test]
        public void TestThreeElementsArrayWithTarget2()
        {
            int[] test2 = { 3, 5, 1 };
            const int target = 3;
            var result = SearchinRotatedSortedArray.Search(test2, target);

            Assert.IsTrue(result == 0);
        }
    }
}
