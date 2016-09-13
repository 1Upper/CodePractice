/*
 124. Binary Tree Maximum Path Sum  QuestionEditorial Solution  My Submissions

 Given a binary tree, find the maximum path sum.

For this problem, a path is defined as any sequence of nodes from some starting node to any node in the tree along the parent-child connections. The path does not need to go through the root.

For example:
Given the below binary tree,

       1
      / \
     2   3
Return 6.

https://leetcode.com/problems/binary-tree-maximum-path-sum/

 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.BinaryTree
{
    class BinaryTreeMaximumPathSum
    {
        public int MaxPathSumFun(TreeNode root, ref int max)
        {
            if (root == null)
                return 0;

            int maxLeft = MaxPathSumFun(root.left, ref max);
            int maxRight = MaxPathSumFun(root.right, ref max);

            // current is max sum of node path in one side of root
            int current = Math.Max(root.val, Math.Max(root.val + maxLeft, root.val + maxRight));

            // max is for the possible max value on any path
            max = Math.Max(max, Math.Max(current, root.val + maxLeft + maxRight));

            return current;
        }

        public int MaxPathSum(TreeNode root)
        {
            int max = int.MinValue;

            MaxPathSumFun(root, ref max);
            return max;
        }
    }
}
