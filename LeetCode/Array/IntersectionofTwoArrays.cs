/*
  Intersection of Two Arrays  QuestionEditorial Solution  My Submissions

Example:
Given nums1 = [1, 2, 2, 1], nums2 = [2, 2], return [2].

Note:
Each element in the result must be unique.
The result can be in any order.
Subscribe to see which companies ask
https://leetcode.com/problems/intersection-of-two-arrays/
*/
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    public class IntersectionofTwoArrays
    {
        public static int[] Intersection(int[] nums1, int[] nums2)
        {
            List<int> list = new List<int>(nums1);
            HashSet<int> result = new HashSet<int>();
            
            foreach(int i in nums2)
            {
                if (list.Contains(i))
                    result.Add(i);
            }

            return result.ToArray();
        }
    }

    [TestFixture]
    public class UTIntersectionofTwoArrays
    {
        [Test]
        public void TestIntersectionOfTwoArrays()
        {
            int[] arr1 = { 1, 2, 2, 1 };
            int[] arr2 = { 2, 2 };

            var result = IntersectionofTwoArrays.Intersection(arr1, arr2);

            Assert.IsTrue(result.Length == 1);
            Assert.IsTrue(result[0] == 2);
        }
    }
}
