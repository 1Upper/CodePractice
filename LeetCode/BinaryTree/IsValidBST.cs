/*
 Given a binary tree, determine if it is a valid binary search tree (BST).

Assume a BST is defined as follows:

The left subtree of a node contains only nodes with keys less than the node's key.
The right subtree of a node contains only nodes with keys greater than the node's key.
Both the left and right subtrees must also be binary search trees.
Example 1:
    2
   / \
  1   3
Binary tree [2,1,3], return true.
Example 2:
    1
   / \
  2   3
Binary tree [1,2,3], return false.

https://leetcode.com/problems/validate-binary-search-tree/
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    class ValidBST
    {
        void InorderTraversal(TreeNode root, IList<int> result)
        {
            if (root == null) return;

            InorderTraversal(root.left, result);

            result.Add(root.val);

            InorderTraversal(root.right, result);
            
        }

        public bool IsValidBST(TreeNode root)
        {
            IList<int> valueList = new List<int>();

            InorderTraversal(root, valueList);

            for (int i = 0; i <= valueList.Count -2; i++)
            {
                if (valueList[i] >= valueList[i + 1])
                    return false;
            }

            return true;
        }
    }
}
