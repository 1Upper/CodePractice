/*
 Implement an iterator over a binary search tree (BST). Your iterator will be initialized with the root node of a BST.
Calling next() will return the next smallest number in the BST.
Note: next() and hasNext() should run in average O(1) time and uses O(h) memory, where h is the height of the tree. 
        _______6______
       /              \
    ___2__          ___8__
   /      \        /      \
   0      _4       7       9
         /  \
         3   5
0 -> 2 -> 3 -> 4 -> 5 -> 6 -> 7 -> 8 -> 9
From <https://oj.leetcode.com/problems/binary-search-tree-iterator/> 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    class BSTIterator
    {
        private TreeNode curr;
        Stack<TreeNode> stack;

        public BSTIterator(TreeNode root)
        {
            stack = new Stack<TreeNode>();
            curr = root;
            
            while (curr != null)
            {
                stack.Push(curr);
                curr = curr.left;
            }            
        }

        /** @return whether we have a next smallest number */
        public bool HasNext()
        {
            // The inorder traversal is ended if st is empty.            return stack.Count > 0;
        }

        /** @return the next smallest number */
        public int Next()
        {
            // Since hasNext() is true before calling next(), st is not empty.            var next = stack.Pop();
            curr = next.right;

            // We should go left as deep as possible.
            while (curr != null)
            {
                stack.Push(curr);
                curr = curr.left;
            }

            return next.val;
        }
    }
}
