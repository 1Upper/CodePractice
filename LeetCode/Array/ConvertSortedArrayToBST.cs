/*
108. Convert Sorted Array to Binary Search Tree  QuestionEditorial Solution  My Submissions
Total Accepted: 88291
Total Submissions: 226148
Difficulty: Medium
Given an array where elements are sorted in ascending order, convert it to a height balanced BST.
https://leetcode.com/problems/convert-sorted-array-to-binary-search-tree/
 */
using System;
using NUnit.Framework;

namespace LeetCode
{
    public class ConvertSortedArrayToBST
    {
        protected static TreeNode SortedArrayToBST(int[] nums, int start, int end)
        {
            if (start > end)
            {
                return null;
            }
            
            int mid = (start+end)/2;
            TreeNode node = new TreeNode(nums[mid]);
            node.left = SortedArrayToBST(nums, start, mid -1);
            node.right = SortedArrayToBST(nums, mid + 1, end);
            
            return node;
        }
        
        public static TreeNode SortedArrayToBST(int[] nums) 
        {
            if (nums.Length == 0) {
                return null;
            }
            
            return SortedArrayToBST(nums, 0, nums.Length - 1);
        }
    }
    [TestFixture]
    public class UTConvertSortedArrayToBST
    {
        [Test]
        public void TestMethod()
        {
            int[] array = {1,2,3,4,5};
            TreeNode node = ConvertSortedArrayToBST.SortedArrayToBST(array);
            
            Assert.IsTrue(node.val == 3);
            Assert.IsTrue(node.left.val == 1);
            Assert.IsTrue(node.right.val == 4);            
        }
    }
}
