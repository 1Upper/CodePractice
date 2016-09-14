/*
 230. Kth Smallest Element in a BST  QuestionEditorial Solution  My Submissions

 Given a binary search tree, write a function kthSmallest to find the kth smallest element in it.

Note: 
You may assume k is always valid, 1 ≤ k ≤ BST's total elements.

Follow up:
What if the BST is modified (insert/delete operations) often and you need to find the kth smallest frequently? How would you optimize the kthSmallest routine?

Hint:

Try to utilize the property of a BST.
What if you could modify the BST node's structure?Show More Hint 
https://leetcode.com/problems/kth-smallest-element-in-a-bst/
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.BinaryTree
{
    class KthSmallestElementinBST
    {
        void InorderTraversal(TreeNode root, IList<int> result, int k)
        {
            if (root == null) return;

            InorderTraversal(root.left, result, k);

            if (result.Count < k)
            {
                result.Add(root.val);
            }
            else
            {
                return;
            }

            InorderTraversal(root.right, result, k);

        }

        public int KthSmallest(TreeNode root, int k)
        {
            IList<int> valueList = new List<int>();

            InorderTraversal(root, valueList, k);

            return (valueList.Count >= k) ? valueList[k - 1] : -1;
        }
    }
}
