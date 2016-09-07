/*
There are two sorted arrays A and B of size m and n respectively. Find the median of the 
two sorted arrays. The overall run time complexity should be O(log (m+n)).

From <https://oj.leetcode.com/problems/median-of-two-sorted-arrays/> 
 */
using NUnit.Framework;
using System;

namespace LeetCode
{
    public static class MedianOfTwoSortedArray
    {
        public static double GetMedianOfTwoSortedArray(int[] nums1, int[] nums2)
        {
            if (nums1 == null || nums2 == null)
            {
                throw new ArgumentException();
            }
            
            int[] nums3 = new int[nums1.Length + nums2.Length];
            int i=0,j=0,k=0;
            for (; i < nums1.Length && j < nums2.Length;)
            {
                if (nums1[i] < nums2[j])
                {
                    nums3[k] =  nums1[i];
                    k++;
                    i++;
                }
                else
                {
                    nums3[k] = nums2[j];
                    k++;
                    j++;
                }
            }
            
            if (i>= nums1.Length)
            {
                while (j<nums2.Length) {
                    nums3[k] = nums2[j];
                    k++;
                    j++;
                }
            }
            
            if (j >= nums2.Length)
            {
                while (i<nums1.Length)
                {
                    nums3[k] = nums1[i];
                    i++;
                    k++;
                }
            }
            
            if ((nums3.Length - 1) %2 == 0)
            {
                return nums3[(nums3.Length - 1)/2];
            }
            else
            {
                return (double)(nums3[nums3.Length/2] + nums3[nums3.Length/2 - 1])/2;
            }
        }
    }

    [TestFixture]
    public class UTMedianOfTwoSortedArray
    {
        [Test]
        public void GetMedianOfTwoSortedArray()
        {
            int[] arr1 = { 1, 2 };
            int[] arr2 = { 3, 4 };

            double value = MedianOfTwoSortedArray.GetMedianOfTwoSortedArray(arr1, arr2);
            Assert.IsTrue(value == 2.5);
        }

        [Test]
        public void GetMedianOfTwoSortedArray2()
        {
            int[] arr1 = { 1, 2 };
            int[] arr2 = { };

            double value = MedianOfTwoSortedArray.GetMedianOfTwoSortedArray(arr1, arr2);
            Assert.IsTrue(value == 1.5);
        }
    }
}