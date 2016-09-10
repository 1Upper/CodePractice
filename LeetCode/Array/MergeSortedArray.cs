/*
 88. Merge Sorted Array  QuestionEditorial Solution  My Submissions
Total Accepted: 118592
Total Submissions: 384638
Difficulty: Easy
Given two sorted integer arrays nums1 and nums2, merge nums2 into nums1 as one sorted array.

Note:
You may assume that nums1 has enough space (size that is greater or equal to m + n) to hold additional elements from nums2. The number of elements initialized in nums1 and nums2 are m and n respectively.

 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    public class MergeSortedArray
    {
        public void Insert(int[] nums1, int m, int insertNum, int n)
        {
            for (int i = m; i > n; i--)
            {
                nums1[i] = nums1[i - 1];
            }
            nums1[n] = insertNum;
        }

        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int i1 = 0, i2 = 0;

            while (i1 < m && i2 < n)
            {
                if (nums1[i1] <= nums2[i2])
                {
                    i1++;
                }
                else
                {
                    Insert(nums1, m, nums2[i2], i1);
                    m++;
                    i2++;
                }
            }

            for (int i = i2; i < n; i++)
            {
                nums1[i1++] = nums2[i];
            }
        }
    }
}