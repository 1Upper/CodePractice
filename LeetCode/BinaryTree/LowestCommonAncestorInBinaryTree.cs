/*
 Given a binary tree, find the lowest common ancestor (LCA) of two given nodes in the tree. 
According to the definition of LCA on Wikipedia: “The lowest common ancestor is defined between two nodes 
v and w as the lowest node in T that has both v and w as descendants (where we allow a node to be a descendant of itself).” 
        _______3______       /              \    ___5__          ___1__   /      \        /      \   6      _2       0       8         /  \         7   4
For example, the lowest common ancestor (LCA) of nodes 5 and 1 is 3. Another example is LCA of nodes 5 and 4 is 5, 
since a node can be a descendant of itself according to the LCA definition.

From <https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree/> 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    class LowestCommonAncestorInBinaryTree
    {
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            // == Operator (C# Reference)
            // For predefined value types, the equality operator (==) returns true if the values of its operands are equal, 
            // false otherwise.
            // For reference types other than string, == returns true if its two operands refer to the same object.
            // For the string type, == compares the values of the strings.
            // When testing for null using == comparisons within your operator== overrides, make sure you use the base object 
            // class operator. If you don't, infinite recursion will occur resulting in a stackoverflow.
            // https://msdn.microsoft.com/en-us/library/53k8ybth.aspx
            if (root == null || p == root || q == root)
            {
                return root;
            }

            TreeNode left = LowestCommonAncestor(root.left, p, q);

            TreeNode right = LowestCommonAncestor(root.right, p, q);

            // If left is NULL, the lowest common ancestor must be in 
            // the right subtree and right is the answer.
            // If left is not NULL, then 
            // (1) if right is NULL, the lowest common ancestor must 
            // be in the left subtree and left is the answer;
            // (2) if right is also not NULL, p and q must be in different 
            // subtrees and root is the answer.


            if (left == null)
            {
                return right;
            }
            else if (right == null)
            {
                return left;
            }
            else
            {
                return root;
            }
        }
    }
}
