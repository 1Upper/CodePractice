/*
Given a binary search tree (BST), find the lowest common ancestor (LCA) of two given nodes in the BST. 
According to the definition of LCA on Wikipedia: “The lowest common ancestor is defined between two 
nodes v and w as the lowest node in T that has both v and w as descendants (where we allow a node to 
be a descendant of itself).” 
        _______6______       /              \    ___2__          ___8__   /      \        /      \   0      _4       7       9         /  \         3   5
For example, the lowest common ancestor (LCA) of nodes 2 and 8 is 6. Another example is LCA of nodes 2 and 4 is 2, since a node can be a descendant of itself according to the LCA definition.

From <https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-search-tree/> 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterviewProject.Array
{

    /// Definition for a binary tree node.
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    public class LowestCommonAncestor
    {
        //public static bool ExistTreeNode(TreeNode root, TreeNode target)
        //{
        //    if (root == null)
        //    {
        //        return false;
        //    }
        //    else if (root.val == target.val)
        //    {
        //        return true;
        //    }
        //    else if (root.val < target.val)
        //    {
        //        return ExistTreeNode(root.left, target);
        //    }
        //    else
        //    {
        //        return ExistTreeNode(root.right, target);
        //    }
        //}

        public static TreeNode GetLowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            TreeNode current = root;

            while (current != null)
            {
                if (current == p || current == q)
                {
                    return current;
                }
                else if (p.val < current.val && q.val < current.val)
                {
                    current = current.left;
                }
                else if (p.val > current.val && q.val > current.val)
                {
                    current = current.right;
                }
                else
                {
                    return current;
                }
            }

            return null;
        }
    }
}
